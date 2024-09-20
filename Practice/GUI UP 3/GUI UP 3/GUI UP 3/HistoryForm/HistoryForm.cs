using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class HistoryForm : Form
    {
        private bool isDescending = true;
        private List<LoginAttempt> loginAttempts = new List<LoginAttempt>();

        public HistoryForm()
        {
            InitializeComponent();

            LoadHistory();
            DisplayHistory();
        }

        private void LoadHistory()
        {
            string filePath = "login_history.log";
            if (File.Exists(filePath))
            {
                foreach (var line in File.ReadAllLines(filePath))
                {
                    var parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        loginAttempts.Add(new LoginAttempt
                        {
                            Timestamp = DateTime.Parse(parts[0]),
                            Login = parts[1],
                            Success = bool.Parse(parts[2])
                        });
                    }
                }
            }
        }

        private void DisplayHistory()
        {
            dataGridViewHistory.DataSource = loginAttempts.OrderByDescending(a => a.Timestamp).ToList();

            dataGridViewHistory.Columns["Timestamp"].HeaderText = "Дата входа";
            dataGridViewHistory.Columns["Login"].HeaderText = "Логин";
            dataGridViewHistory.Columns["Success"].HeaderText = "Результат входа";
        }

        private void btn_add_filter_name_Click(object sender, EventArgs e)
        {
            string filterLogin = textBoxFilterLogin.Text;

            if (string.IsNullOrEmpty(filterLogin))
            {
                MessageBox.Show("Введите логин для сортировки!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var filteredAttempts = loginAttempts.Where(a => !string.IsNullOrEmpty(a.Login) &&a.Login.IndexOf(filterLogin, StringComparison.OrdinalIgnoreCase) >= 0).OrderBy(a => a.Timestamp) .ToList();

            if (filteredAttempts.Count == 0)
            {
                MessageBox.Show("Нет записей, соответствующих указанному фильтру.","Информация", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            dataGridViewHistory.DataSource = filteredAttempts;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            textBoxFilterLogin.Clear();
            DisplayHistory();
        }

        private void btn_back_to_login_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите вернуться в меню?", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btn_date_sort_Click(object sender, EventArgs e)
        {
            isDescending = !isDescending;

            IEnumerable<LoginAttempt> dataToSort = loginAttempts;

            if (!string.IsNullOrEmpty(textBoxFilterLogin.Text))
            {
                string filterLogin = textBoxFilterLogin.Text;
                dataToSort = dataToSort.Where(a => !string.IsNullOrEmpty(a.Login) && a.Login.IndexOf(filterLogin, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            var sortedData = isDescending ? dataToSort.OrderByDescending(a => a.Timestamp).ToList(): dataToSort.OrderBy(a => a.Timestamp).ToList();
            dataGridViewHistory.DataSource = sortedData;
            dataGridViewHistory.Columns["Timestamp"].HeaderText = isDescending ? "Дата входа (сначала новые)" : "Дата входа (сначала старые)";
        }
    }
}

