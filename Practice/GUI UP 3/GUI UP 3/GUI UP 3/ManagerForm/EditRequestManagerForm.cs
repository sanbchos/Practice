using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class EditRequestManagerForm : Form
    {
        private int requestID;
        private string startDate;
        private string completionDate;
        private string master;

        DataBase database = new DataBase();

        public EditRequestManagerForm(int selectedRequestID, string startDate, string completionDate, string master)
        {
            InitializeComponent();

            this.requestID = selectedRequestID;
            this.startDate = startDate;
            this.completionDate = completionDate;
            this.master = master;

            LoadRequestData();
        }

        private void back_to_menu_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Вы уверены, что хотите вернуться в меню? Изменение заявки будет прекращено!", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void LoadRequestData()
        {
            textBox_request_id.Text = requestID.ToString();
            dateTimePicker_start_date.Value = Convert.ToDateTime(startDate);

            if (!string.IsNullOrEmpty(completionDate))
            {
                dateTimePicker_end_date.Value = Convert.ToDateTime(completionDate);
            }

            LoadMasters();
            if (!string.IsNullOrEmpty(master))
            {
                comboBox_masters.Text = master;
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

        private void button_add_request_Click(object sender, EventArgs e)
        {
            int selectedRequestID = requestID;
            DateTime newStartDate = dateTimePicker_start_date.Value;
            DateTime? newCompletionDate = dateTimePicker_end_date.Checked ? (DateTime?)dateTimePicker_end_date.Value : null;
            int? selectedMasterID = comboBox_masters.SelectedValue as int?;

            if (selectedMasterID == null)
            {
                MessageBox.Show("Пожалуйста, выберите мастера.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string updateQuery = @"
            UPDATE Requests
            SET startDate = @startDate, 
                completionDate = @completionDate, 
                masterID = @masterID
            WHERE requestID = @requestID";

            try
            {
                using (SqlCommand command = new SqlCommand(updateQuery, database.GetConnection()))
                {
                    command.Parameters.AddWithValue("@startDate", newStartDate);
                    command.Parameters.AddWithValue("@completionDate", (object)newCompletionDate ?? DBNull.Value);
                    command.Parameters.AddWithValue("@masterID", selectedMasterID);
                    command.Parameters.AddWithValue("@requestID", selectedRequestID);

                    database.openConnection();
                    int rowsAffected = command.ExecuteNonQuery();
                    database.closeConnection();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Заявка успешно обновлена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось обновить заявку. Пожалуйста, попробуйте снова.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении заявки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
