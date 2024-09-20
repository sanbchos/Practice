namespace GUI
{
    partial class HistoryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewHistory = new System.Windows.Forms.DataGridView();
            this.textBoxFilterLogin = new System.Windows.Forms.TextBox();
            this.btn_add_filter_name = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_date_sort = new System.Windows.Forms.Button();
            this.btn_back_to_login = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewHistory
            // 
            this.dataGridViewHistory.AllowUserToAddRows = false;
            this.dataGridViewHistory.AllowUserToDeleteRows = false;
            this.dataGridViewHistory.AllowUserToResizeColumns = false;
            this.dataGridViewHistory.AllowUserToResizeRows = false;
            this.dataGridViewHistory.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHistory.Location = new System.Drawing.Point(12, 106);
            this.dataGridViewHistory.Name = "dataGridViewHistory";
            this.dataGridViewHistory.ReadOnly = true;
            this.dataGridViewHistory.RowHeadersVisible = false;
            this.dataGridViewHistory.Size = new System.Drawing.Size(307, 288);
            this.dataGridViewHistory.TabIndex = 0;
            // 
            // textBoxFilterLogin
            // 
            this.textBoxFilterLogin.Location = new System.Drawing.Point(12, 28);
            this.textBoxFilterLogin.Name = "textBoxFilterLogin";
            this.textBoxFilterLogin.Size = new System.Drawing.Size(138, 20);
            this.textBoxFilterLogin.TabIndex = 1;
            // 
            // btn_add_filter_name
            // 
            this.btn_add_filter_name.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add_filter_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_add_filter_name.Location = new System.Drawing.Point(156, 28);
            this.btn_add_filter_name.Name = "btn_add_filter_name";
            this.btn_add_filter_name.Size = new System.Drawing.Size(177, 23);
            this.btn_add_filter_name.TabIndex = 2;
            this.btn_add_filter_name.Text = "Применить фильтр";
            this.btn_add_filter_name.UseVisualStyleBackColor = true;
            this.btn_add_filter_name.Click += new System.EventHandler(this.btn_add_filter_name_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(155)))), ((int)(((byte)(47)))));
            this.panel1.Controls.Add(this.btn_cancel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(609, 100);
            this.panel1.TabIndex = 3;
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.SystemColors.Control;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_cancel.Location = new System.Drawing.Point(340, 28);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(79, 23);
            this.btn_cancel.TabIndex = 5;
            this.btn_cancel.Text = "Отменить";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите login";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
            this.panel2.Controls.Add(this.btn_date_sort);
            this.panel2.Controls.Add(this.btn_back_to_login);
            this.panel2.Location = new System.Drawing.Point(-1, 97);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(609, 366);
            this.panel2.TabIndex = 4;
            // 
            // btn_date_sort
            // 
            this.btn_date_sort.BackColor = System.Drawing.SystemColors.Control;
            this.btn_date_sort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_date_sort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_date_sort.Location = new System.Drawing.Point(13, 303);
            this.btn_date_sort.Name = "btn_date_sort";
            this.btn_date_sort.Size = new System.Drawing.Size(177, 23);
            this.btn_date_sort.TabIndex = 6;
            this.btn_date_sort.Text = "Сортировать по дате";
            this.btn_date_sort.UseVisualStyleBackColor = false;
            this.btn_date_sort.Click += new System.EventHandler(this.btn_date_sort_Click);
            // 
            // btn_back_to_login
            // 
            this.btn_back_to_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_back_to_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_back_to_login.ForeColor = System.Drawing.Color.White;
            this.btn_back_to_login.Location = new System.Drawing.Point(437, 318);
            this.btn_back_to_login.Name = "btn_back_to_login";
            this.btn_back_to_login.Size = new System.Drawing.Size(158, 23);
            this.btn_back_to_login.TabIndex = 0;
            this.btn_back_to_login.Text = "Вернуться в меню";
            this.btn_back_to_login.UseVisualStyleBackColor = true;
            this.btn_back_to_login.Click += new System.EventHandler(this.btn_back_to_login_Click);
            // 
            // HistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 461);
            this.Controls.Add(this.btn_add_filter_name);
            this.Controls.Add(this.textBoxFilterLogin);
            this.Controls.Add(this.dataGridViewHistory);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.MaximumSize = new System.Drawing.Size(620, 500);
            this.MinimumSize = new System.Drawing.Size(620, 500);
            this.Name = "HistoryForm";
            this.Text = "История авторизаций";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewHistory;
        private System.Windows.Forms.TextBox textBoxFilterLogin;
        private System.Windows.Forms.Button btn_add_filter_name;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_back_to_login;
        private System.Windows.Forms.Button btn_date_sort;
    }
}