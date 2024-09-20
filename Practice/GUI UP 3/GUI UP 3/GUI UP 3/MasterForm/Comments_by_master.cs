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
    public partial class Comments_by_master : Form
    {
        private int masterID;
        private DataBase database = new DataBase();

        public Comments_by_master(int masterID)
        {
            InitializeComponent();
            this.masterID = masterID;

        }

        private void btn_back_to_meny_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                           "Вы уверены, что хотите вернуться в меню?", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void Comments_by_master_Load(object sender, EventArgs e)
        {
            LoadComments();
            LoadRequestsForComboBox();
        }

        private void LoadRequestsForComboBox()
        {
            string query = @"
            SELECT requestID 
            FROM Requests 
            WHERE masterID = @masterID";

            using (SqlCommand command = new SqlCommand(query, database.GetConnection()))
            {
                command.Parameters.AddWithValue("@masterID", masterID);

                try
                {
                    database.openConnection();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int requestID = reader.GetInt32(0);
                        comboBox_request_id.Items.Add(requestID.ToString());
                    }
                    reader.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Ошибка при загрузке заявок: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    database.closeConnection();
                }
            }
        }

        private void LoadComments()
        {
            string query = @"
            SELECT 
                c.commentID, 
                c.message, 
                r.problemDescription, 
                r.requestID 
            FROM Comments c
            INNER JOIN Requests r ON c.requestID = r.requestID
            WHERE c.masterID = @masterID";

            using (SqlCommand command = new SqlCommand(query, database.GetConnection()))
            {
                command.Parameters.AddWithValue("@masterID", masterID);

                try
                {
                    database.openConnection();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable commentsTable = new DataTable();
                    adapter.Fill(commentsTable);
                    dataGridView_comments.DataSource = commentsTable;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Ошибка при загрузке комментариев: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    database.closeConnection();
                }
            }
        }

        private void dataGridView_comments_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int commentID = Convert.ToInt32(dataGridView_comments.Rows[e.RowIndex].Cells["commentID"].Value);
            string updatedCommentText = dataGridView_comments.Rows[e.RowIndex].Cells["message"].Value?.ToString().Trim();

            // Проверяем, что комментарий не пустой
            if (string.IsNullOrEmpty(updatedCommentText))
            {
                MessageBox.Show("Комментарий не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string updateQuery = @"
            UPDATE Comments 
            SET message = @message 
            WHERE commentID = @commentID";

            using (SqlCommand command = new SqlCommand(updateQuery, database.GetConnection()))
            {
                command.Parameters.AddWithValue("@message", updatedCommentText);
                command.Parameters.AddWithValue("@commentID", commentID);

                try
                {
                    database.openConnection();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Комментарий успешно обновлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Не удалось обновить комментарий. Попробуйте еще раз.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Ошибка при редактировании комментария: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    database.closeConnection();
                }
            }
        }

        private void btn_add_comment_Click(object sender, EventArgs e)
        {
            if (comboBox_request_id.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите заявку.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получаем выбранный requestID напрямую как строку и конвертируем его в int
            int requestID;
            if (!int.TryParse(comboBox_request_id.SelectedItem.ToString().Split(':')[0], out requestID))
            {
                MessageBox.Show("Ошибка при выборе заявки. Попробуйте еще раз.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string newCommentText = textBox_new_comment.Text.Trim();

            if (string.IsNullOrEmpty(newCommentText))
            {
                MessageBox.Show("Введите текст комментария.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string insertQuery = @"
            INSERT INTO Comments (message, masterID, requestID) 
            VALUES (@message, @masterID, @requestID)";

            using (SqlCommand command = new SqlCommand(insertQuery, database.GetConnection()))
            {
                command.Parameters.AddWithValue("@message", newCommentText); // Используем правильное имя параметра
                command.Parameters.AddWithValue("@masterID", masterID); // Убедитесь, что masterID корректно инициализирован
                command.Parameters.AddWithValue("@requestID", requestID);

                try
                {
                    database.openConnection();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Комментарий успешно добавлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadComments(); // Обновляем комментарии после добавления
                    }
                    else
                    {
                        MessageBox.Show("Не удалось добавить комментарий. Попробуйте еще раз.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Ошибка при добавлении комментария: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    database.closeConnection();
                }
            }
        }
    }
}
