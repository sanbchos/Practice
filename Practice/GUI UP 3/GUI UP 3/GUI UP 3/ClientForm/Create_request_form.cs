using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Create_request_form : Form
    {
        private string userFullName;
        private int userID;

        DataBase database = new DataBase();

        public Create_request_form(string fullName, int userid)
        {
            InitializeComponent();
            userFullName = fullName;
            userID = userid;
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

        private void button_add_request_Click(object sender, EventArgs e)
        {
   
            string fio = textBox_FIO.Text;
            string deviceType = comboBox_DeviceTypes.SelectedItem?.ToString();
            string deviceModel = comboBox_DeviceModels.SelectedItem?.ToString();
            string problemDescription = textBox_Description_problem.Text;

            if (string.IsNullOrWhiteSpace(fio) || string.IsNullOrWhiteSpace(deviceType) || string.IsNullOrWhiteSpace(deviceModel) || string.IsNullOrWhiteSpace(problemDescription))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля перед добавлением заявки.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Пожалуйста, проверьте все введенные данные перед отправкой заявки. Вы уверены, что хотите продолжить?",
                                                  "Подтверждение",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                AddRequest(fio, deviceModel, problemDescription);

                textBox_FIO.Text = userFullName;
                textBox_Description_problem.Clear();
                comboBox_DeviceModels.SelectedIndex = -1;
                comboBox_DeviceTypes.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Добавление заявки отменено.", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AddRequest(string fio, string deviceModel, string problemDescription)
        {
            if (comboBox_DeviceModels.SelectedValue == null)
            {
                MessageBox.Show("Модель устройства не выбрана.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int modelID = (int)comboBox_DeviceModels.SelectedValue;

            string insertQuery = @"
            INSERT INTO Requests (startDate, modelID, problemDescription, requestStatus, clientID)
            VALUES (GETDATE(), 
                    @ModelID, 
                    @ProblemDescription, 
                    'Новая', 
                    @UserID)";

            using (SqlCommand insertCommand = new SqlCommand(insertQuery, database.GetConnection()))
            {
                insertCommand.Parameters.AddWithValue("@ModelID", modelID);
                insertCommand.Parameters.AddWithValue("@ProblemDescription", problemDescription);
                insertCommand.Parameters.AddWithValue("@UserID", userID);

                try
                {
                    database.GetConnection().Open();
                    insertCommand.ExecuteNonQuery();

                    MessageBox.Show("Заявка успешно добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при добавлении заявки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    database.GetConnection().Close();
                }
            }
        }



        private void Create_request_form_Load(object sender, EventArgs e)
        {
            textBox_FIO.Text = userFullName;
            LoadDeviceTypes();

            comboBox_DeviceTypes.SelectedIndex = -1;
            comboBox_DeviceModels.DataSource = null;
            comboBox_DeviceModels.Items.Clear();
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
            }
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
            }
        }

        private void comboBox_DeviceTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_DeviceModels.DataSource = null;
            comboBox_DeviceModels.Items.Clear();
            LoadDeviceModels();
        }
    }
}
