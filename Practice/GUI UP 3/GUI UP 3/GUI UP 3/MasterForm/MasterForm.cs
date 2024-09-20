using GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_EKZ_TRBZD.MasterForm
{
    public partial class MasterForm : Form
    {
        private string userFullName;
        private string userRole;
        private int userID;
        private int selectedRequestID;

        DataBase database = new DataBase();

        public MasterForm(string fullName, string role, int userid)
        {
            InitializeComponent();

            this.userFullName = fullName;
            this.userRole = role;
            this.userID = userid;
        }

        private void btn_back_to_menu_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
              "Вы уверены, что хотите вернуться в меню?", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void MasterForm_Load(object sender, EventArgs e)
        {
            fio_label.Text = $"ФИО: {userFullName} - {userRole}";
            label_requests.Visible = false;

            const string imagePath = "images/base_photo.jpg";

            btn_reset_filters.Visible = false;

            if (File.Exists(imagePath))
            {
                pictureBox_photo.Image = Image.FromFile(imagePath);
            }
            else
            {
                MessageBox.Show("Изображение не найдено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadAllRequestsForMaster();
            UpdateRequestCount(userID);
        }

        private void btn_found_requests_by_user_Click(object sender, EventArgs e)
        {
            string searchText = textBox_found_requests.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Введите текст для поиска.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadAllRequestsForMaster();
                return;
            }

            string query = @"
            SELECT 
                r.requestID, 
                r.startDate, 
                r.problemDescription, 
                r.requestStatus, 
                r.completionDate, 
                rp.partName, 
                m.fio AS masterName, 
                c.fio AS clientName, 
                dm.modelName, 
                dt.typeName
            FROM Requests r
            LEFT JOIN RepairParts rp ON r.repairParts = rp.partID
            LEFT JOIN Users m ON r.masterID = m.userID
            LEFT JOIN Users c ON r.clientID = c.userID
            LEFT JOIN DeviceModels dm ON r.modelID = dm.modelID
            LEFT JOIN DeviceTypes dt ON dm.typeID = dt.typeID
            WHERE r.masterID = @userID 
              AND (r.problemDescription LIKE '%' + @searchText + '%' 
                   OR rp.partName LIKE '%' + @searchText + '%'
                   OR m.fio LIKE '%' + @searchText + '%'
                   OR c.fio LIKE '%' + @searchText + '%'
                   OR dm.modelName LIKE '%' + @searchText + '%'
                   OR dt.typeName LIKE '%' + @searchText + '%')";

            using (SqlCommand command = new SqlCommand(query, database.GetConnection()))
            {
                command.Parameters.AddWithValue("@userID", userID);
                command.Parameters.AddWithValue("@searchText", searchText);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();

                try
                {
                    adapter.Fill(table);
                    dataGridView_requests_by_master.DataSource = table;
                    btn_reset_filters.Visible = true;
                    label_requests.Visible = true;

                    int recordCount = table.Rows.Count;
                    label_requests.Text = $"Количество записей: {recordCount}";

                    if (recordCount == 0)
                    {
                        MessageBox.Show("Не найдено заявок по заданным критериям.", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox_found_requests.Clear();
                        LoadAllRequestsForMaster();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Ошибка при выполнении запроса: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_reset_filters_Click(object sender, EventArgs e)
        {
            textBox_found_requests.Text = string.Empty;
            LoadAllRequestsForMaster();
            label_requests.Visible = false;
            btn_reset_filters.Visible = false;
        }

        private void SetupDataGridViewColumns()
        {
            dataGridView_requests_by_master.Columns["requestID"].HeaderText = "Номер заявки";
            dataGridView_requests_by_master.Columns["startDate"].HeaderText = "Дата начала";
            dataGridView_requests_by_master.Columns["problemDescription"].HeaderText = "Описание проблемы";
            dataGridView_requests_by_master.Columns["requestStatus"].HeaderText = "Статус заявки";
            dataGridView_requests_by_master.Columns["completionDate"].HeaderText = "Дата завершения";
            dataGridView_requests_by_master.Columns["partName"].HeaderText = "Запчасти";
            dataGridView_requests_by_master.Columns["masterName"].HeaderText = "ФИО мастера";
            dataGridView_requests_by_master.Columns["clientName"].HeaderText = "ФИО клиента";
            dataGridView_requests_by_master.Columns["modelName"].HeaderText = "Модель устройства";
            dataGridView_requests_by_master.Columns["typeName"].HeaderText = "Тип устройства";

            dataGridView_requests_by_master.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void LoadAllRequestsForMaster()
        {
            string query = @"
            SELECT 
                r.requestID,
                r.startDate,
                r.problemDescription,
                r.requestStatus,
                r.completionDate,
                rp.partName,
                m.fio AS masterName,
                c.fio AS clientName,
                dm.modelName,
                dt.typeName
            FROM Requests r
            LEFT JOIN RepairParts rp ON r.repairParts = rp.partID
            LEFT JOIN Users m ON r.masterID = m.userID
            LEFT JOIN Users c ON r.clientID = c.userID
            LEFT JOIN DeviceModels dm ON r.modelID = dm.modelID
            LEFT JOIN DeviceTypes dt ON dm.typeID = dt.typeID
            WHERE r.masterID = @userID";

            using (SqlCommand command = new SqlCommand(query, database.GetConnection()))
            {
                command.Parameters.AddWithValue("@userID", userID);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();

                try
                {
                    adapter.Fill(table);
                    dataGridView_requests_by_master.DataSource = table;
                    SetupDataGridViewColumns();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Ошибка при выполнении запроса: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateRequestCount(int userID)
        {
            string countQuery = @"
            SELECT COUNT(*) 
            FROM Requests 
            WHERE masterID = @UserID";

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
                            label_count_of_requests.Text = $"Кол-во заявок: {requestCount}";
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

        private void btn_add_repair_parts_Click(object sender, EventArgs e)
        {
            if (dataGridView_requests_by_master.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите заявку из таблицы.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dataGridView_requests_by_master.SelectedRows[0];
            int requestID = Convert.ToInt32(selectedRow.Cells["requestID"].Value);
            string requestStatus = selectedRow.Cells["requestStatus"].Value.ToString();

            if (requestStatus == "Готова к выдаче")
            {
                MessageBox.Show("Запчасти не могут быть добавлены к заявке со статусом 'Готова к выдаче'.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Add_repair_parts addRepairPartsForm = new Add_repair_parts(requestID);
            addRepairPartsForm.ShowDialog();
            LoadAllRequestsForMaster();
        }

        private void btn_close_work_Click(object sender, EventArgs e)
        {
            if (dataGridView_requests_by_master.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите заявку из таблицы.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataGridViewRow selectedRow = dataGridView_requests_by_master.SelectedRows[0];
            int requestID = Convert.ToInt32(selectedRow.Cells["requestID"].Value);
            string requestStatus = selectedRow.Cells["requestStatus"].Value.ToString();

            if (requestStatus == "Закрыта" || requestStatus == "Готова к выдаче")
            {
                MessageBox.Show("Заявка уже закрыта или готова к выдаче.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Вы уверены, что хотите закрыть выбранную заявку?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                string updateQuery = @"
                UPDATE Requests
                SET requestStatus = 'Закрыта',
                    completionDate = GETDATE()
                WHERE requestID = @requestID";

                using (SqlCommand command = new SqlCommand(updateQuery, database.GetConnection()))
                {
                    command.Parameters.AddWithValue("@requestID", requestID);

                    try
                    {
                        database.openConnection();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Заявка успешно закрыта.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadAllRequestsForMaster();
                        }
                        else
                        {
                            MessageBox.Show("Не удалось закрыть заявку. Попробуйте еще раз.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Ошибка при выполнении запроса: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        database.closeConnection();
                    }
                }
            }
        }

        private void btn_watch_comments_Click(object sender, EventArgs e)
        {
            Comments_by_master comments_form = new Comments_by_master(userID);
            this.Hide();
            comments_form.ShowDialog();
        }
    }
}
