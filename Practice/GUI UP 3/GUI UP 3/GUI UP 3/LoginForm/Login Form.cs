using GUI_EKZ_TRBZD.MasterForm;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GUI
{
    public partial class Login_Form_Window : Form
    {
        private string captchaText;
        private int failedAttempts = 0;
        private bool isLocked = false;
        private bool isPermanentlyLocked = false;
        private DateTime blockEndTime;

        DataBase database = new DataBase();

        public Login_Form_Window()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            textBox_PasswordField.UseSystemPasswordChar = true;

            HideCaptcha();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (isPermanentlyLocked)
            {
                MessageBox.Show("Вы заблокированы. Перезапустите приложение для повторной попытки.", "Перманентная блокировка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (isLocked)
            {
                if (DateTime.Now < blockEndTime)
                {
                    TimeSpan remainingTime = blockEndTime - DateTime.Now;
                    label_Captcha.Text = $"Блокировка: {remainingTime.Minutes:D2}:{remainingTime.Seconds:D2}";
                    label_Captcha.Visible = true;
                    return;
                }
                else
                {
                    isLocked = false;
                    failedAttempts = 0;
                    label_Captcha.Visible = false;
                    timer_Block.Stop();
                }
            }

            var loginUser = textBox_LoginField.Text;
            var passwordUser = textBox_PasswordField.Text;

            if (string.IsNullOrEmpty(loginUser) || string.IsNullOrEmpty(passwordUser))
            {
                MessageBox.Show("Необходимо ввести логин и/или пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string query_string = $"select userID, fio, login, password, userStatusID from Users where login = '{loginUser}' and password = '{passwordUser}'";
            SqlCommand command = new SqlCommand(query_string, database.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (failedAttempts >= 1)
            {
                if (pictureBox_Captcha.Visible)
                {
                    if (textBox_Captcha.Text != captchaText)
                    {
                        MessageBox.Show("CAPTCHA введена неверно!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox_Captcha.Clear();
                        pictureBox_Captcha.Image = CreateCaptchaImage(pictureBox_Captcha.Width, pictureBox_Captcha.Height);
                        return;
                    }
                }
            }

            if (table.Rows.Count == 1)
            {
                MessageBox.Show("Успешная авторизация!", "Вход в базу данных", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LogLoginAttempt(loginUser, true);

                failedAttempts = 0;

                int userID = Convert.ToInt32(table.Rows[0]["userID"]);
                int userStatusID = Convert.ToInt32(table.Rows[0]["userStatusID"]);
                string user_FIO = Convert.ToString(table.Rows[0]["fio"]);
                string user_role = GetRoleByStatusID(userStatusID);

                HideCaptcha();

                switch (userStatusID)
                {
                    case 1:
                        ManagerForm managerForm = new ManagerForm(user_FIO, user_role, userID);
                        this.Hide();
                        managerForm.ShowDialog();
                        this.Show();
                        break;
                    case 2:
                        MasterForm masterForm = new MasterForm(user_FIO, user_role, userID);
                        this.Hide();
                        masterForm.ShowDialog();
                        this.Show();
                        break;
                    case 3:
                        OperatorForm operatorForm = new OperatorForm(user_FIO, user_role, userID);
                        this.Hide();
                        operatorForm.ShowDialog();
                        this.Show();
                        break;
                    case 4:
                        ClientForm clientForm = new ClientForm(user_FIO, user_role, userID);
                        this.Hide();
                        clientForm.ShowDialog();
                        this.Show();
                        break;
                    default:
                        MessageBox.Show("Неизвестный статус пользователя.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }

                textBox_LoginField.Clear();
                textBox_PasswordField.Clear();
            }
            else
            {
                failedAttempts++;
                LogLoginAttempt(loginUser, false);

                MessageBox.Show("Ошибка ввода логина и/или пароля!", "Неуспешная авторизация", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (failedAttempts >= 1)
                {
                    ShowCaptcha();
                }

                if (failedAttempts >= 4)
                {
                    BlockUser();
                }
            }
        }

        private void checkBox_ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            textBox_PasswordField.UseSystemPasswordChar = !checkBox_ShowPassword.Checked;
        }

        private void HideCaptcha()
        {
            pictureBox_Captcha.Visible = false;
            textBox_Captcha.Visible = false;
            button_RefreshCaptcha.Visible = false;
            label_Captcha.Visible = false;
        }

        private void ShowCaptcha()
        {
            pictureBox_Captcha.Visible = true;
            textBox_Captcha.Visible = true;
            button_RefreshCaptcha.Visible = true;
            label_Captcha.Visible = true;

            pictureBox_Captcha.Image = CreateCaptchaImage(pictureBox_Captcha.Width, pictureBox_Captcha.Height);
        }

        private Bitmap CreateCaptchaImage(int Width, int Height)
        {
            Random rnd = new Random();
            Bitmap result = new Bitmap(Width, Height);
            int Xpos = rnd.Next(10, Width - 50);
            int Ypos = rnd.Next(10, Height - 30);

            Brush[] colors = { Brushes.Black, Brushes.Red, Brushes.RoyalBlue, Brushes.Green };
            Graphics g = Graphics.FromImage(result);
            g.Clear(Color.Gray);

            captchaText = String.Empty;
            string ALF = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
            for (int i = 0; i < 4; ++i)
                captchaText += ALF[rnd.Next(ALF.Length)];

            for (int i = 0; i < captchaText.Length; i++)
            {
                g.TranslateTransform(Xpos + (i * 20), Ypos);
                g.RotateTransform(rnd.Next(-45, 45));
                g.DrawString(captchaText[i].ToString(),
                    new Font("Arial", 18, FontStyle.Bold),
                    colors[rnd.Next(colors.Length)],
                    0, 0);
                g.ResetTransform();
            }

            for (int i = 0; i < Width; i += 10)
            {
                g.DrawLine(Pens.Black, new Point(rnd.Next(Width), rnd.Next(Height)), new Point(rnd.Next(Width), rnd.Next(Height)));
            }

            return result;
        }

        private void BlockUser()
        {
            if (failedAttempts >= 4)
            {
                if (failedAttempts < 5)
                {
                    blockEndTime = DateTime.Now.AddMinutes(3);
                    isLocked = true;
                    label_Captcha.Text = "Вы заблокированы на 3 минуты.";
                    label_Captcha.Visible = true;
                    timer_Block.Start();
                }
                else
                {
                    isPermanentlyLocked = true;
                    MessageBox.Show("Вы заблокированы. Необходимо перезапустить приложение!", "Перманентная блокировка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button_RefreshCaptcha_Click(object sender, EventArgs e)
        {
            pictureBox_Captcha.Image = CreateCaptchaImage(pictureBox_Captcha.Width, pictureBox_Captcha.Height);
        }

        private void timer_Block_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now >= blockEndTime)
            {
                isLocked = false;
                label_Captcha.Visible = false;
                timer_Block.Stop();
            }
            else
            {
                TimeSpan remainingTime = blockEndTime - DateTime.Now;
                label_Captcha.Text = $"Блокировка: {remainingTime.Minutes:D2}:{remainingTime.Seconds:D2}";
                label_Captcha.Visible = true;
            }
        }

        private void LogLoginAttempt(string login, bool success)
        {
            string filePath = "login_history.log";
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}|{login}|{success}";
            File.AppendAllLines(filePath, new[] { logEntry });
        }

        public string GetRoleByStatusID(int userStatusID)
        {
            switch (userStatusID)
            {
                case 1:
                    return "Менеджер";
                case 2:
                    return "Мастер";
                case 3:
                    return "Оператор";
                case 4:
                    return "Клиент";
                default:
                    return "Неизвестная роль";
            }
        }
    }
}


