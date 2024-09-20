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

namespace GUI_EKZ_TRBZD.MasterForm
{
    public partial class Add_repair_parts : Form
    {
        private int requestID;

        DataBase database = new DataBase();

        public Add_repair_parts(int requestID)
        {
            InitializeComponent();
            this.requestID = requestID;
            label_id_request.Text = $"ID заявки: {requestID}";
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

        private void button_add_repair_parts_Click(object sender, EventArgs e)
        {
            if (comboBox_repair_parts.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите запчасть.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedPartID = Convert.ToInt32(comboBox_repair_parts.SelectedValue);

            string query = @"
            UPDATE Requests
            SET repairParts = @partID
            WHERE requestID = @requestID";

            using (SqlCommand command = new SqlCommand(query, database.GetConnection()))
            {
                command.Parameters.AddWithValue("@partID", selectedPartID);
                command.Parameters.AddWithValue("@requestID", requestID);

                try
                {
                    database.openConnection();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Запчасть успешно добавлена к заявке.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Ошибка при обновлении заявки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    database.closeConnection();
                }
            }
        }

        private void Add_repair_parts_Load(object sender, EventArgs e)
        {
            LoadRepairParts();
            LoadCurrentRepairPart();
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

        private void LoadCurrentRepairPart()
        {
            string query = "SELECT partID FROM RepairParts WHERE requestID = @requestID";

            using (SqlCommand command = new SqlCommand(query, database.GetConnection()))
            {
                command.Parameters.AddWithValue("@requestID", requestID);

                try
                {
                    database.openConnection();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        int currentPartID = Convert.ToInt32(result);
                        comboBox_repair_parts.SelectedValue = currentPartID;
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Ошибка при загрузке текущей запчасти: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    database.closeConnection();
                }
            }
        }
    }
}
