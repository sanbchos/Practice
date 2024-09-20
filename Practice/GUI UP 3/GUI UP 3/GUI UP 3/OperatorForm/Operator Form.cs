using ClassLibrary;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Windows.Forms;

namespace GUI
{
    public partial class OperatorForm : Form
    {
        private string userFullName;
        private string userRole;
        private int userID;
        private int selectedRequestID;

        DataBase database = new DataBase();

        public OperatorForm(string fullName, string role, int userid)
        {
            InitializeComponent();

            userFullName = fullName;
            userRole = role;
            userID = userid;
        }

        private void OperatorForm_Load(object sender, EventArgs e)
        {
            fio_label.Text = $"ФИО: {userFullName} - {userRole}";
            label_requests.Visible = false;

            const string imagePath = "images/base_photo.jpg";

            btn_reset_filters.Visible = false ;

            if (File.Exists(imagePath))
            {
                pictureBox_photo.Image = Image.FromFile(imagePath);
            }
            else
            {
                MessageBox.Show("Изображение не найдено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadAllRequestsForOperator();
            UpdateRequestCount(userID);
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

        private void btn_auth_history_Click(object sender, EventArgs e)
        {
            HistoryForm historyForm = new HistoryForm();
            historyForm.ShowDialog();
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

        private void btn_found_requests_by_user_Click(object sender, EventArgs e)
        {
            string searchText = textBox_found_requests.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Введите текст для поиска.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadAllRequestsForOperator();
                return;
            }

            string query = @"
            SELECT r.requestID, 
                   r.startDate, 
                   r.problemDescription, 
                   r.requestStatus, 
                   r.completionDate, 
                   r.repairParts,
                   u.fio AS clientName, 
                   m.fio AS masterName, 
                   dm.modelName, 
                   dt.typeName
            FROM Requests r
            INNER JOIN Users u ON r.clientID = u.userID
            LEFT JOIN Users m ON r.masterID = m.userID
            INNER JOIN DeviceModels dm ON r.modelID = dm.modelID
            INNER JOIN DeviceTypes dt ON dm.typeID = dt.typeID
            WHERE (CAST(r.requestID AS NVARCHAR) LIKE '%' + @searchText + '%' OR 
                   r.requestStatus LIKE '%' + @searchText + '%' OR 
                   r.problemDescription LIKE '%' + @searchText + '%' OR 
                   r.repairParts LIKE '%' + @searchText + '%' OR 
                   u.fio LIKE '%' + @searchText + '%' OR 
                   m.fio LIKE '%' + @searchText + '%' OR 
                   dm.modelName LIKE '%' + @searchText + '%' OR 
                   dt.typeName LIKE '%' + @searchText + '%')";


            using (SqlCommand command = new SqlCommand(query, database.GetConnection()))
            {
                command.Parameters.AddWithValue("@searchText", searchText);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                dataGridView_all_requests_by_operator.DataSource = table;

                btn_reset_filters.Visible = true;
                label_requests.Visible = true;
                int recordCount = table.Rows.Count;
                label_requests.Text = $"Количество записей: {recordCount}";

                if (recordCount == 0)
                {
                    MessageBox.Show("Не найдено заявок по заданным критериям.", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox_found_requests.Clear();
                    LoadAllRequestsForOperator();
                }
            }
        }

        private void SetupDataGridViewColumns()
        {
      
            dataGridView_all_requests_by_operator.Columns["requestID"].HeaderText = "Номер заявки";
            dataGridView_all_requests_by_operator.Columns["startDate"].HeaderText = "Дата начала";
            dataGridView_all_requests_by_operator.Columns["problemDescription"].HeaderText = "Описание проблемы";
            dataGridView_all_requests_by_operator.Columns["requestStatus"].HeaderText = "Статус заявки";
            dataGridView_all_requests_by_operator.Columns["completionDate"].HeaderText = "Дата завершения";
            dataGridView_all_requests_by_operator.Columns["partName"].HeaderText = "Запчасти";
            dataGridView_all_requests_by_operator.Columns["masterName"].HeaderText = "ФИО мастера";
            dataGridView_all_requests_by_operator.Columns["clientName"].HeaderText = "ФИО клиента";
            dataGridView_all_requests_by_operator.Columns["modelName"].HeaderText = "Модель устройства";
            dataGridView_all_requests_by_operator.Columns["typeName"].HeaderText = "Тип устройства";

            dataGridView_all_requests_by_operator.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    
        }

        private void LoadAllRequestsForOperator()
        {
            string query = @"
            SELECT r.requestID, 
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
            LEFT JOIN Users m ON r.masterID = m.userID
            LEFT JOIN Users c ON r.clientID = c.userID
            LEFT JOIN DeviceModels dm ON r.modelID = dm.modelID
            LEFT JOIN DeviceTypes dt ON dm.typeID = dt.typeID
            LEFT JOIN RepairParts rp ON r.repairParts = rp.partID";

            using (SqlCommand command = new SqlCommand(query, database.GetConnection()))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                dataGridView_all_requests_by_operator.DataSource = table;
                SetupDataGridViewColumns();
            }
        }

        private void btn_reset_filters_Click(object sender, EventArgs e)
        {
            textBox_found_requests.Text = string.Empty;
            LoadAllRequestsForOperator();
            label_requests.Visible = false;
            btn_reset_filters.Visible = false;
        }

        private void btn_close_request_Click(object sender, EventArgs e)
        {
            if (dataGridView_all_requests_by_operator.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите заявку для закрытия.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dataGridView_all_requests_by_operator.SelectedRows[0];
            selectedRequestID = Convert.ToInt32(selectedRow.Cells["requestID"].Value);
            string status = selectedRow.Cells["requestStatus"].Value.ToString();
            string masterName = selectedRow.Cells["masterName"].Value.ToString();

            if (string.IsNullOrEmpty(masterName))
            {
                MessageBox.Show("Мастер должен быть назначен для закрытия заявки.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (status == "Новая" || status == "Закрыта")
            {
                MessageBox.Show("Эту заявку нельзя закрыть, так как ее статус: " + status, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"
            UPDATE Requests
            SET requestStatus = 'Закрыта', 
                completionDate = @completionDate
            WHERE requestID = @requestID";

            using (SqlCommand command = new SqlCommand(query, database.GetConnection()))
            {
                command.Parameters.AddWithValue("@completionDate", DateTime.Now);
                command.Parameters.AddWithValue("@requestID", selectedRequestID);

                database.openConnection();
                int rowsAffected = command.ExecuteNonQuery();
                database.closeConnection();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Заявка успешно закрыта.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllRequestsForOperator();
                }
                else
                {
                    MessageBox.Show("Произошла ошибка при закрытии заявки.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_edit_request_Click(object sender, EventArgs e)
        {
            if (dataGridView_all_requests_by_operator.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите заявку для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dataGridView_all_requests_by_operator.SelectedRows[0];

            selectedRequestID = Convert.ToInt32(selectedRow.Cells["requestID"].Value);
            string startDate = dataGridView_all_requests_by_operator.SelectedRows[0].Cells["startDate"].Value.ToString();
            string deviceType = dataGridView_all_requests_by_operator.SelectedRows[0].Cells["typeName"].Value.ToString();
            string deviceModel = dataGridView_all_requests_by_operator.SelectedRows[0].Cells["modelName"].Value.ToString();
            string problemDescription = dataGridView_all_requests_by_operator.SelectedRows[0].Cells["problemDescription"].Value.ToString();
            string requestStatus = dataGridView_all_requests_by_operator.SelectedRows[0].Cells["requestStatus"].Value.ToString();
            string completionDate = dataGridView_all_requests_by_operator.SelectedRows[0].Cells["completionDate"].Value.ToString();
            string repairParts = dataGridView_all_requests_by_operator.SelectedRows[0].Cells["partName"].Value.ToString();
            string master = dataGridView_all_requests_by_operator.SelectedRows[0].Cells["masterName"].Value.ToString();

            if (requestStatus != "Новая" && requestStatus != "В процессе ремонта")
            {
                MessageBox.Show("Только заявки со статусом 'Новая' или 'В процессе ремонта' могут быть изменены.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Edit_request_form_operator editForm = new Edit_request_form_operator(selectedRequestID, startDate, problemDescription, requestStatus, completionDate, repairParts, master);
            editForm.ShowDialog();
            LoadAllRequestsForOperator();
        }

        private void btn_CalculateAverageRepairTime_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox_modelID.Text, out int modelID))
            {
                try
                {
                    var database = new ClassLibrary.DataBase();
                    var calculateAverageRepairTime = new CalculateAverageRepairTime(database);

                    double averageRepairTime = calculateAverageRepairTime.CalculateAverageRepairTimeByModelID(modelID);

                    MessageBox.Show($"Среднее время ремонта для модели с ID {modelID} составляет {averageRepairTime} дней.",
                                    "Результат подсчета",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка при подсчете среднего времени ремонта: {ex.Message}",
                                    "Ошибка",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Введите корректное значение для modelID.",
                                "Неверный ввод",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }
    }
}
