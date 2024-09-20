using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;

namespace GUI
{
    public partial class ClientForm : Form
    {
        private string userFullName;
        private string userRole;
        private int userID;

        DataBase database = new DataBase();

        public ClientForm(string fullName, string role, int id)
        {
            InitializeComponent();
            userFullName = fullName;
            userRole = role;
            userID = id;

            label_count_of_reports.Visible = false;
            btn_reset_filters.Visible = false;
            pictureBox_QR_code.Visible = false;
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            fio_label.Text = $"ФИО: {userFullName} - {userRole}";

            const string imagePath = "images/base_photo.jpg";

            if (File.Exists(imagePath))
            {
                pictureBox_base_photo.Image = Image.FromFile(imagePath);
            }
            else
            {
                MessageBox.Show("Изображение не найдено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadUserRequests(userID);
            UpdateRequestCount(userID);
        }

        private void btn_back_to_menu_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите вернуться в меню?", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btn_create_request_Click(object sender, EventArgs e)
        {
            Create_request_form requestForm = new Create_request_form(userFullName, userID);
            this.Hide();
            requestForm.ShowDialog();

            LoadUserRequests(userID);
            UpdateRequestCount(userID);

            this.Show();
        }

        private void btn_edit_request_Click(object sender, EventArgs e)
        {
            if (dataGridView_all_requests_by_user.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите заявку для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string requestStatus = dataGridView_all_requests_by_user.SelectedRows[0].Cells["requestStatus"].Value.ToString();

            if (requestStatus != "Новая")
            {
                MessageBox.Show("Редактировать можно только заявки со статусом 'Новая'.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int requestID = (int)dataGridView_all_requests_by_user.SelectedRows[0].Cells["requestID"].Value;
            string deviceModel = dataGridView_all_requests_by_user.SelectedRows[0].Cells["modelName"].Value.ToString();
            string problemDescription = dataGridView_all_requests_by_user.SelectedRows[0].Cells["problemDescription"].Value.ToString();
            string deviceType = GetDeviceTypeByModel(deviceModel);

            Edit_request_form requestForm = new Edit_request_form(requestID, userFullName, deviceType, deviceModel, problemDescription, userID);
            this.Hide();
            requestForm.ShowDialog();
            LoadUserRequests(userID);
            UpdateRequestCount(userID);
            this.Show();
        }

        private string GetDeviceTypeByModel(string modelName)
        {
            string deviceType = null;
            string query = "SELECT DeviceTypes.typeName FROM DeviceModels " + "JOIN DeviceTypes ON DeviceModels.typeID = DeviceTypes.typeID " + "WHERE DeviceModels.modelName = @ModelName";

            using (SqlCommand command = new SqlCommand(query, database.GetConnection()))
            {
                command.Parameters.AddWithValue("@ModelName", modelName);

                try
                {
                    database.GetConnection().Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        deviceType = result.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при получении типа устройства: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    database.GetConnection().Close();
                }
            }

            return deviceType;
        }

        private void SetupDataGridViewColumns()
        {
            dataGridView_all_requests_by_user.Columns["requestID"].HeaderText = "Номер заявки";
            dataGridView_all_requests_by_user.Columns["startDate"].HeaderText = "Дата начала";
            dataGridView_all_requests_by_user.Columns["problemDescription"].HeaderText = "Описание проблемы";
            dataGridView_all_requests_by_user.Columns["requestStatus"].HeaderText = "Статус заявки";
            dataGridView_all_requests_by_user.Columns["completionDate"].HeaderText = "Дата завершения";
            dataGridView_all_requests_by_user.Columns["modelName"].HeaderText = "Модель устройства";
            dataGridView_all_requests_by_user.Columns["typeName"].HeaderText = "Тип устройства";

            dataGridView_all_requests_by_user.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void LoadUserRequests(int clientID)
        {
            string query = @"
            SELECT r.requestID, 
                   r.startDate, 
                   r.problemDescription, 
                   r.requestStatus, 
                   r.completionDate, 
                   dm.modelName, 
                   dt.typeName
            FROM Requests r
            INNER JOIN DeviceModels dm ON r.modelID = dm.modelID
            INNER JOIN DeviceTypes dt ON dm.typeID = dt.typeID
            WHERE r.clientID = @clientID";

            using (SqlCommand command = new SqlCommand(query, database.GetConnection()))
            {
                command.Parameters.AddWithValue("@clientID", clientID);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                dataGridView_all_requests_by_user.DataSource = table;

                SetupDataGridViewColumns();
            }
        }

        private void btn_found_requests_by_user_Click(object sender, EventArgs e)
        {
            string searchText = textBox_found_requests.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Введите текст для поиска.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadUserRequests(userID);
                return;
            }

            string query = @"
            SELECT r.requestID, 
                    r.startDate, 
                    r.problemDescription, 
                    r.requestStatus, 
                    r.completionDate, 
                    dm.modelName, 
                    dt.typeName
            FROM Requests r
            INNER JOIN DeviceModels dm ON r.modelID = dm.modelID
            INNER JOIN DeviceTypes dt ON dm.typeID = dt.typeID
            WHERE r.clientID = @clientID AND 
                    (r.problemDescription LIKE '%' + @searchText + '%' OR 
                    dm.modelName LIKE '%' + @searchText + '%' OR 
                    dt.typeName LIKE '%' + @searchText + '%')";

            using (SqlCommand command = new SqlCommand(query, database.GetConnection()))
            {
                command.Parameters.AddWithValue("@clientID", userID);
                command.Parameters.AddWithValue("@searchText", searchText);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                dataGridView_all_requests_by_user.DataSource = table;

                SetupDataGridViewColumns();

                btn_reset_filters.Visible = true;
                label_count_of_reports.Visible = true;

                int recordCount = table.Rows.Count;
                label_count_of_reports.Text = $"Количество записей: {recordCount}";

                if (recordCount == 0)
                {
                    MessageBox.Show("Не найдено заявок по заданным критериям.", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUserRequests(userID);
                }
            }
        }

        private void btn_reset_filters_Click(object sender, EventArgs e)
        {
            textBox_found_requests.Text = string.Empty;
            LoadUserRequests(userID);
            label_count_of_reports.Visible = false;
            btn_reset_filters.Visible = false;
        }

        private void UpdateRequestCount(int userID)
        {
            string countQuery = @"
            SELECT COUNT(*) 
            FROM Requests 
            WHERE clientID = @UserID";

            using (SqlCommand countCommand = new SqlCommand(countQuery, database.GetConnection()))
            {
                countCommand.Parameters.AddWithValue("@UserID", userID);

                try
                {
                    database.openConnection();
                    using (SqlDataReader reader = countCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int requestCount = reader.GetInt32(0);
                            label_requests.Text = $"Кол-во заявок: {requestCount}";
                        }
                    }
                    database.closeConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при получении количества заявок: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_show_qr_Click(object sender, EventArgs e)
        {
            string googleFormsUrl = "https://docs.google.com/forms";

            QRCodeEncoder qrEncoder = new QRCodeEncoder();

            Bitmap qrCodeImage = qrEncoder.Encode(googleFormsUrl);

            pictureBox_QR_code.Image = qrCodeImage;

            qrEncoder.QRCodeScale = 8;

            pictureBox_QR_code.Visible = true;

        }

        private void btn_hide_picture_Click(object sender, EventArgs e)
        {
            pictureBox_QR_code.Visible = false;
        }
    }
}
