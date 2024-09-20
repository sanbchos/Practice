using GUI;
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
    public partial class Edit_request_form : Form
    {
        private int requestID;
        private string fio;
        private string deviceType;
        private string deviceModel;
        private string problemDescription;
        private int userID;

        DataBase database = new DataBase();

        public Edit_request_form(int requestID, string fio, string deviceType, string deviceModel, string problemDescription, int userID)
        {
            InitializeComponent();

            this.requestID = requestID;
            this.fio = fio;
            this.deviceType = deviceType;
            this.deviceModel = deviceModel;
            this.problemDescription = problemDescription;
            this.userID = userID;
        }

        private void LoadRequestData()
        {
            textBox_id_request.Text = requestID.ToString();
            textBox_FIO.Text = fio;
            comboBox_DeviceTypes.Text = deviceType;
            comboBox_DeviceModels.Text = deviceModel;
            textBox_Description_problem.Text = problemDescription;

            LoadDeviceTypes();
        }

        private void back_to_menu_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Вы уверены, что хотите вернуться в меню? Редактирование заявки будет прекращено!", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void LoadDeviceTypes()
        {
            string query = "SELECT typeID, typeName FROM DeviceTypes";

            using (SqlCommand command = new SqlCommand(query, database.GetConnection()))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                comboBox_DeviceTypes.DisplayMember = "typeName";
                comboBox_DeviceTypes.ValueMember = "typeID";
                comboBox_DeviceTypes.DataSource = table;

                comboBox_DeviceTypes.SelectedIndex = -1;
                comboBox_DeviceTypes.SelectedIndexChanged += comboBox_DeviceTypes_SelectedIndexChanged;

                if (!string.IsNullOrEmpty(deviceType))
                {
                    comboBox_DeviceTypes.SelectedValue = GetDeviceTypeID(deviceType);
                    LoadDeviceModels();
                }
            }
        }

        private int GetDeviceTypeID(string typeName)
        {
            string query = "SELECT typeID FROM DeviceTypes WHERE typeName = @typeName";
            using (SqlCommand command = new SqlCommand(query, database.GetConnection()))
            {
                command.Parameters.AddWithValue("@typeName", typeName);
                database.openConnection();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetInt32(0);
                    }
                }
            }

            return -1;
        }

        private int GetDeviceModelID(string modelName)
        {
            string query = "SELECT modelID FROM DeviceModels WHERE modelName = @modelName";
            using (SqlCommand command = new SqlCommand(query, database.GetConnection()))
            {
                command.Parameters.AddWithValue("@modelName", modelName);
                database.openConnection();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetInt32(0);
                    }
                }
            }
            return -1;
        }

        private void LoadDeviceModels()
        {
            if (comboBox_DeviceTypes.SelectedValue == null)
            {
                comboBox_DeviceModels.DataSource = null;
                comboBox_DeviceModels.Items.Clear();
                return;
            }

            int selectedTypeID = (int)comboBox_DeviceTypes.SelectedValue;

            string query = "SELECT modelID, modelName FROM DeviceModels WHERE typeID = @TypeID";

            using (SqlCommand command = new SqlCommand(query, database.GetConnection()))
            {
                command.Parameters.AddWithValue("@TypeID", selectedTypeID);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                comboBox_DeviceModels.DisplayMember = "modelName";
                comboBox_DeviceModels.ValueMember = "modelID";
                comboBox_DeviceModels.DataSource = table;

                comboBox_DeviceModels.SelectedIndex = -1;

                if (!string.IsNullOrEmpty(deviceModel))
                {
                    comboBox_DeviceModels.SelectedValue = GetDeviceModelID(deviceModel);
                }
            }
        }

        private void comboBox_DeviceTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_DeviceModels.DataSource = null;
            comboBox_DeviceModels.Items.Clear();
            LoadDeviceModels();
        }

        private void Edit_request_form_Load(object sender, EventArgs e)
        {
            LoadRequestData();
        }

        private void button_add_request_Click(object sender, EventArgs e)
        {
            string deviceModel = comboBox_DeviceModels.SelectedItem?.ToString();
            string problemDescription = textBox_Description_problem.Text;

            if (string.IsNullOrWhiteSpace(deviceModel) || string.IsNullOrWhiteSpace(problemDescription))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля перед обновлением заявки.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Пожалуйста, проверьте все введенные данные перед отправкой заявки. Вы уверены, что хотите продолжить?",
                                                  "Подтверждение",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                AddRequest(requestID, (int)comboBox_DeviceModels.SelectedValue, problemDescription, userID);
                this.Close();
            }
            else
            {
                MessageBox.Show("Обновление заявки отменено.", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AddRequest(int requestID, int modelID, string problemDescription, int userID)
        {
            string updateQuery = @"
            UPDATE Requests 
            SET modelID = @ModelID, 
                problemDescription = @ProblemDescription, 
                requestStatus = @RequestStatus, 
                clientID = @UserID,
                startDate = GETDATE()
            WHERE requestID = @RequestID";

            using (SqlCommand updateCommand = new SqlCommand(updateQuery, database.GetConnection()))
            {
                updateCommand.Parameters.AddWithValue("@ModelID", modelID);
                updateCommand.Parameters.AddWithValue("@ProblemDescription", problemDescription);
                updateCommand.Parameters.AddWithValue("@RequestStatus", "Новая");
                updateCommand.Parameters.AddWithValue("@UserID", userID);
                updateCommand.Parameters.AddWithValue("@RequestID", requestID);

                try
                {
                    int rowsAffected = updateCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Заявка успешно обновлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Заявка не найдена или не обновлена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при обновлении заявки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
