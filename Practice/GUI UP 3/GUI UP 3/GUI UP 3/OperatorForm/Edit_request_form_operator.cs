using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Edit_request_form_operator : Form
    {
        private int requestID;
        private string startDate;
        private string problemDescription;
        private string requestStatus;
        private string completionDate;
        private string repairParts;
        private string master;

        DataBase database = new DataBase();

        public Edit_request_form_operator(int selectedRequestID, string startDate, string problemDescription, string requestStatus, string completionDate, string repairParts, string master)
        {
            InitializeComponent();

            this.requestID = selectedRequestID;
            this.startDate = startDate;
            this.problemDescription = problemDescription;
            this.requestStatus = requestStatus;
            this.completionDate = completionDate;
            this.repairParts = repairParts;
            this.master = master;

            LoadRequestData();
        }

        private void back_to_menu_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Вы уверены, что хотите вернуться в меню? Создание заявки будет прекращено!", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void LoadRequestData()
        {
            textBox_request_id.Text = requestID.ToString();
            dateTimePicker_start_date.Value = Convert.ToDateTime(startDate);
            textBox_Description_problem.Text = string.IsNullOrEmpty(problemDescription) ? "" : problemDescription;
            comboBox_Status_request.SelectedItem = requestStatus;

            if (!string.IsNullOrEmpty(completionDate))
            {
                dateTimePicker_end_date.Value = Convert.ToDateTime(completionDate);
            }

            LoadMasters();
            if (!string.IsNullOrEmpty(master))
            {
                comboBox_masters.Text = master;
            }

            LoadRepairParts();
            if (!string.IsNullOrEmpty(repairParts))
            {
                comboBox_repair_parts.Text = repairParts;
            }
        }

        private void LoadMasters()
        {
            string query = "SELECT userID, fio FROM Users WHERE UserStatusID = 2";
            using (SqlCommand command = new SqlCommand(query, database.GetConnection()))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                comboBox_masters.DisplayMember = "fio";
                comboBox_masters.ValueMember = "userID";
                comboBox_masters.DataSource = table;
            }
        }

        private void LoadRepairParts()
        {
            string query = "SELECT partID, partName FROM RepairParts";
            using (SqlCommand command = new SqlCommand(query, database.GetConnection()))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                comboBox_repair_parts.DisplayMember = "partName";
                comboBox_repair_parts.ValueMember = "partID";
                comboBox_repair_parts.DataSource = table;
            }
        }

        private void Edit_request_form_operator_Load(object sender, EventArgs e)
        {
            LoadRequestStatuses();
        }

        private void button_add_request_Click(object sender, EventArgs e)
        {
            string query = @"
            UPDATE Requests
            SET problemDescription = @problemDescription, 
                requestStatus = @requestStatus, 
                completionDate = @completionDate, 
                repairParts = @repairParts, 
                masterID = @masterID
            WHERE requestID = @requestID";

            using (SqlCommand command = new SqlCommand(query, database.GetConnection()))
            {
                command.Parameters.AddWithValue("@problemDescription", string.IsNullOrEmpty(textBox_Description_problem.Text) ? (object)DBNull.Value : textBox_Description_problem.Text);
                command.Parameters.AddWithValue("@requestStatus", comboBox_Status_request.SelectedItem.ToString());

                if (dateTimePicker_end_date.Value == DateTime.MinValue)
                {
                    command.Parameters.AddWithValue("@completionDate", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@completionDate", dateTimePicker_end_date.Value);
                }

                command.Parameters.AddWithValue("@repairParts", comboBox_repair_parts.SelectedValue ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@masterID", comboBox_masters.SelectedValue ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@requestID", requestID);

                try
                {
                    database.openConnection();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Изменения успешно сохранены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
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

        private void LoadRequestStatuses()
        {
            List<string> statuses = new List<string>
            {
                "Новая",
                "В процессе ремонта",
                "Готова к выдаче",
                "Закрыта"
            };

            comboBox_Status_request.DataSource = statuses;
        }
    }
}
