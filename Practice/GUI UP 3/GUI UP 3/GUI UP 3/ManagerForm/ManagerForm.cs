using ClassLibrary;
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

namespace GUI
{
    public partial class ManagerForm : Form
    {
        private string userFullName;
        private string userRole;
        private int userID;

        DataBase database = new DataBase();

        public ManagerForm(string fullName, string role, int id)
        {
            InitializeComponent();

            userFullName = fullName;
            userRole = role;
            userID = id;
        }

        private void btn_back_to_menu_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите вернуться в меню?", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void SetupDataGridViewColumns()
        {
            dataGridView_requests_for_manager.Columns["requestID"].HeaderText = "Номер заявки";
            dataGridView_requests_for_manager.Columns["startDate"].HeaderText = "Дата начала";
            dataGridView_requests_for_manager.Columns["problemDescription"].HeaderText = "Описание проблемы";
            dataGridView_requests_for_manager.Columns["requestStatus"].HeaderText = "Статус заявки";
            dataGridView_requests_for_manager.Columns["completionDate"].HeaderText = "Дата завершения";
            dataGridView_requests_for_manager.Columns["partName"].HeaderText = "Запчасти";
            dataGridView_requests_for_manager.Columns["masterName"].HeaderText = "ФИО мастера";
            dataGridView_requests_for_manager.Columns["clientName"].HeaderText = "ФИО клиента";
            dataGridView_requests_for_manager.Columns["modelName"].HeaderText = "Модель устройства";
            dataGridView_requests_for_manager.Columns["typeName"].HeaderText = "Тип устройства";

            dataGridView_requests_for_manager.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void LoadAllRequestsForManager()
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
            LEFT JOIN RepairParts rp ON r.repairParts = rp.partID
            WHERE r.completionDate IS NULL
                  OR r.masterID IS NULL
                  OR r.completionDate < GETDATE()";

            using (SqlCommand command = new SqlCommand(query, database.GetConnection()))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                dataGridView_requests_for_manager.DataSource = table;
                SetupDataGridViewColumns();
            }
        }

        private void ManagerForm_Load(object sender, EventArgs e)
        {
            fio_label.Text = $"ФИО: {userFullName} - {userRole}";

            label_count_of_reports.Visible = false;
            btn_reset_filters.Visible = false;

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

            LoadAllRequestsForManager();
            UpdateRequestCount(userID);
        }

        private void UpdateRequestCount(int userID)
        {
            string countQuery = @"
            SELECT COUNT(*) 
            FROM Requests r
            LEFT JOIN Users m ON r.masterID = m.userID
            WHERE r.completionDate IS NULL
                  OR r.masterID IS NULL
                  OR r.completionDate < GETDATE()";

            using (SqlCommand countCommand = new SqlCommand(countQuery, database.GetConnection()))
            {
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при получении количества заявок: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    database.closeConnection();
                }
            }
        }

        private void btn_reset_filters_Click(object sender, EventArgs e)
        {
            textBox_found_requests.Text = string.Empty;
            LoadAllRequestsForManager();
            label_count_of_reports.Visible = false;
            btn_reset_filters.Visible = false;
        }

        private void btn_found_requests_by_user_Click(object sender, EventArgs e)
        {
            string searchText = textBox_found_requests.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Введите текст для поиска.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadAllRequestsForManager();
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

                dataGridView_requests_for_manager.DataSource = table;

                btn_reset_filters.Visible = true;
                label_count_of_reports.Visible = true;
                int recordCount = table.Rows.Count;
                label_count_of_reports.Text = $"Количество записей: {recordCount}";

                if (recordCount == 0)
                {
                    MessageBox.Show("Не найдено заявок по заданным критериям.", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox_found_requests.Clear();
                    LoadAllRequestsForManager();
                }
            }
        }

        private void btn_edit_request_Click(object sender, EventArgs e)
        {
            if (dataGridView_requests_for_manager.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView_requests_for_manager.SelectedRows[0];

                int requestID = Convert.ToInt32(selectedRow.Cells["requestID"].Value);
                string startDate = selectedRow.Cells["startDate"].Value?.ToString();
                string completionDate = selectedRow.Cells["completionDate"].Value?.ToString();
                string master = selectedRow.Cells["masterName"].Value?.ToString();

                EditRequestManagerForm editForm = new EditRequestManagerForm(requestID, startDate, completionDate, master);
                editForm.ShowDialog();
                LoadAllRequestsForManager();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите заявку для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
