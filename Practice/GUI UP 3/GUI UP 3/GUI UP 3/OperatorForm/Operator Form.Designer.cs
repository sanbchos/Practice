namespace GUI
{
    partial class OperatorForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_auth_history = new System.Windows.Forms.Button();
            this.fio_label = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_back_to_menu = new System.Windows.Forms.Button();
            this.fio_role_label = new System.Windows.Forms.Label();
            this.pictureBox_photo = new System.Windows.Forms.PictureBox();
            this.label_requests = new System.Windows.Forms.Label();
            this.dataGridView_all_requests_by_operator = new System.Windows.Forms.DataGridView();
            this.btn_found_requests_by_user = new System.Windows.Forms.Button();
            this.btn_close_request = new System.Windows.Forms.Button();
            this.label_found = new System.Windows.Forms.Label();
            this.textBox_found_requests = new System.Windows.Forms.TextBox();
            this.label_count_of_requests = new System.Windows.Forms.Label();
            this.btn_reset_filters = new System.Windows.Forms.Button();
            this.btn_edit_request = new System.Windows.Forms.Button();
            this.btn_CalculateAverageRepairTime = new System.Windows.Forms.Button();
            this.textBox_modelID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_photo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_all_requests_by_operator)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(155)))), ((int)(((byte)(47)))));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btn_auth_history);
            this.panel1.Controls.Add(this.fio_label);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btn_back_to_menu);
            this.panel1.Controls.Add(this.fio_role_label);
            this.panel1.Controls.Add(this.pictureBox_photo);
            this.panel1.Location = new System.Drawing.Point(-1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1185, 126);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(0, 123);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(802, 328);
            this.panel3.TabIndex = 2;
            // 
            // btn_auth_history
            // 
            this.btn_auth_history.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_auth_history.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_auth_history.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_auth_history.Location = new System.Drawing.Point(879, 11);
            this.btn_auth_history.Name = "btn_auth_history";
            this.btn_auth_history.Size = new System.Drawing.Size(180, 32);
            this.btn_auth_history.TabIndex = 4;
            this.btn_auth_history.Text = "История авторизаций";
            this.btn_auth_history.UseVisualStyleBackColor = false;
            this.btn_auth_history.Click += new System.EventHandler(this.btn_auth_history_Click);
            // 
            // fio_label
            // 
            this.fio_label.AutoSize = true;
            this.fio_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fio_label.ForeColor = System.Drawing.Color.White;
            this.fio_label.Location = new System.Drawing.Point(204, 30);
            this.fio_label.Name = "fio_label";
            this.fio_label.Size = new System.Drawing.Size(0, 16);
            this.fio_label.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 123);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(802, 328);
            this.panel2.TabIndex = 1;
            // 
            // btn_back_to_menu
            // 
            this.btn_back_to_menu.BackColor = System.Drawing.Color.Red;
            this.btn_back_to_menu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_back_to_menu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_back_to_menu.Location = new System.Drawing.Point(1074, 11);
            this.btn_back_to_menu.Name = "btn_back_to_menu";
            this.btn_back_to_menu.Size = new System.Drawing.Size(99, 32);
            this.btn_back_to_menu.TabIndex = 2;
            this.btn_back_to_menu.Text = "Выйти";
            this.btn_back_to_menu.UseVisualStyleBackColor = false;
            this.btn_back_to_menu.Click += new System.EventHandler(this.btn_back_to_menu_Click);
            // 
            // fio_role_label
            // 
            this.fio_role_label.AutoSize = true;
            this.fio_role_label.Location = new System.Drawing.Point(178, 12);
            this.fio_role_label.Name = "fio_role_label";
            this.fio_role_label.Size = new System.Drawing.Size(0, 13);
            this.fio_role_label.TabIndex = 1;
            // 
            // pictureBox_photo
            // 
            this.pictureBox_photo.Location = new System.Drawing.Point(16, 12);
            this.pictureBox_photo.Name = "pictureBox_photo";
            this.pictureBox_photo.Size = new System.Drawing.Size(160, 95);
            this.pictureBox_photo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_photo.TabIndex = 0;
            this.pictureBox_photo.TabStop = false;
            // 
            // label_requests
            // 
            this.label_requests.AutoSize = true;
            this.label_requests.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_requests.ForeColor = System.Drawing.Color.White;
            this.label_requests.Location = new System.Drawing.Point(152, 236);
            this.label_requests.Name = "label_requests";
            this.label_requests.Size = new System.Drawing.Size(0, 16);
            this.label_requests.TabIndex = 6;
            // 
            // dataGridView_all_requests_by_operator
            // 
            this.dataGridView_all_requests_by_operator.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
            this.dataGridView_all_requests_by_operator.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_all_requests_by_operator.Location = new System.Drawing.Point(-1, 263);
            this.dataGridView_all_requests_by_operator.Name = "dataGridView_all_requests_by_operator";
            this.dataGridView_all_requests_by_operator.RowHeadersVisible = false;
            this.dataGridView_all_requests_by_operator.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_all_requests_by_operator.Size = new System.Drawing.Size(1185, 302);
            this.dataGridView_all_requests_by_operator.TabIndex = 7;
            // 
            // btn_found_requests_by_user
            // 
            this.btn_found_requests_by_user.BackColor = System.Drawing.Color.Green;
            this.btn_found_requests_by_user.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_found_requests_by_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_found_requests_by_user.ForeColor = System.Drawing.Color.White;
            this.btn_found_requests_by_user.Location = new System.Drawing.Point(12, 203);
            this.btn_found_requests_by_user.Name = "btn_found_requests_by_user";
            this.btn_found_requests_by_user.Size = new System.Drawing.Size(134, 26);
            this.btn_found_requests_by_user.TabIndex = 8;
            this.btn_found_requests_by_user.Text = "Поиск заявок";
            this.btn_found_requests_by_user.UseVisualStyleBackColor = false;
            this.btn_found_requests_by_user.Click += new System.EventHandler(this.btn_found_requests_by_user_Click);
            // 
            // btn_close_request
            // 
            this.btn_close_request.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_close_request.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close_request.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_close_request.ForeColor = System.Drawing.Color.White;
            this.btn_close_request.Location = new System.Drawing.Point(448, 183);
            this.btn_close_request.Name = "btn_close_request";
            this.btn_close_request.Size = new System.Drawing.Size(196, 26);
            this.btn_close_request.TabIndex = 9;
            this.btn_close_request.Text = "Закрыть заявку";
            this.btn_close_request.UseVisualStyleBackColor = false;
            this.btn_close_request.Click += new System.EventHandler(this.btn_close_request_Click);
            // 
            // label_found
            // 
            this.label_found.AutoSize = true;
            this.label_found.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_found.ForeColor = System.Drawing.Color.White;
            this.label_found.Location = new System.Drawing.Point(152, 189);
            this.label_found.Name = "label_found";
            this.label_found.Size = new System.Drawing.Size(126, 15);
            this.label_found.TabIndex = 11;
            this.label_found.Text = "Критерий поиска:";
            // 
            // textBox_found_requests
            // 
            this.textBox_found_requests.BackColor = System.Drawing.Color.White;
            this.textBox_found_requests.Location = new System.Drawing.Point(152, 208);
            this.textBox_found_requests.Name = "textBox_found_requests";
            this.textBox_found_requests.Size = new System.Drawing.Size(168, 20);
            this.textBox_found_requests.TabIndex = 10;
            // 
            // label_count_of_requests
            // 
            this.label_count_of_requests.AutoSize = true;
            this.label_count_of_requests.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_count_of_requests.ForeColor = System.Drawing.Color.White;
            this.label_count_of_requests.Location = new System.Drawing.Point(12, 236);
            this.label_count_of_requests.Name = "label_count_of_requests";
            this.label_count_of_requests.Size = new System.Drawing.Size(0, 16);
            this.label_count_of_requests.TabIndex = 12;
            // 
            // btn_reset_filters
            // 
            this.btn_reset_filters.BackColor = System.Drawing.Color.Red;
            this.btn_reset_filters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reset_filters.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_reset_filters.ForeColor = System.Drawing.Color.White;
            this.btn_reset_filters.Location = new System.Drawing.Point(12, 154);
            this.btn_reset_filters.Name = "btn_reset_filters";
            this.btn_reset_filters.Size = new System.Drawing.Size(134, 43);
            this.btn_reset_filters.TabIndex = 13;
            this.btn_reset_filters.Text = "Сбросить параметры";
            this.btn_reset_filters.UseVisualStyleBackColor = false;
            this.btn_reset_filters.Click += new System.EventHandler(this.btn_reset_filters_Click);
            // 
            // btn_edit_request
            // 
            this.btn_edit_request.BackColor = System.Drawing.Color.Teal;
            this.btn_edit_request.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_edit_request.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_edit_request.ForeColor = System.Drawing.Color.White;
            this.btn_edit_request.Location = new System.Drawing.Point(448, 142);
            this.btn_edit_request.Name = "btn_edit_request";
            this.btn_edit_request.Size = new System.Drawing.Size(196, 26);
            this.btn_edit_request.TabIndex = 14;
            this.btn_edit_request.Text = "Взять заявку в работу";
            this.btn_edit_request.UseVisualStyleBackColor = false;
            this.btn_edit_request.Click += new System.EventHandler(this.btn_edit_request_Click);
            // 
            // btn_CalculateAverageRepairTime
            // 
            this.btn_CalculateAverageRepairTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_CalculateAverageRepairTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CalculateAverageRepairTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_CalculateAverageRepairTime.ForeColor = System.Drawing.Color.White;
            this.btn_CalculateAverageRepairTime.Location = new System.Drawing.Point(801, 142);
            this.btn_CalculateAverageRepairTime.Name = "btn_CalculateAverageRepairTime";
            this.btn_CalculateAverageRepairTime.Size = new System.Drawing.Size(257, 26);
            this.btn_CalculateAverageRepairTime.TabIndex = 15;
            this.btn_CalculateAverageRepairTime.Text = "Посчитать среднее время ремонта";
            this.btn_CalculateAverageRepairTime.UseVisualStyleBackColor = false;
            this.btn_CalculateAverageRepairTime.Click += new System.EventHandler(this.btn_CalculateAverageRepairTime_Click);
            // 
            // textBox_modelID
            // 
            this.textBox_modelID.BackColor = System.Drawing.Color.White;
            this.textBox_modelID.Location = new System.Drawing.Point(890, 183);
            this.textBox_modelID.Name = "textBox_modelID";
            this.textBox_modelID.Size = new System.Drawing.Size(168, 20);
            this.textBox_modelID.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(805, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 17;
            this.label1.Text = "ID модели:";
            // 
            // OperatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_modelID);
            this.Controls.Add(this.btn_CalculateAverageRepairTime);
            this.Controls.Add(this.btn_edit_request);
            this.Controls.Add(this.btn_reset_filters);
            this.Controls.Add(this.label_count_of_requests);
            this.Controls.Add(this.label_found);
            this.Controls.Add(this.textBox_found_requests);
            this.Controls.Add(this.btn_close_request);
            this.Controls.Add(this.btn_found_requests_by_user);
            this.Controls.Add(this.dataGridView_all_requests_by_operator);
            this.Controls.Add(this.label_requests);
            this.Controls.Add(this.panel1);
            this.Name = "OperatorForm";
            this.Text = "Окно оператора";
            this.Load += new System.EventHandler(this.OperatorForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_photo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_all_requests_by_operator)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label fio_label;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_back_to_menu;
        private System.Windows.Forms.Label fio_role_label;
        private System.Windows.Forms.PictureBox pictureBox_photo;
        private System.Windows.Forms.Button btn_auth_history;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label_requests;
        private System.Windows.Forms.DataGridView dataGridView_all_requests_by_operator;
        private System.Windows.Forms.Button btn_found_requests_by_user;
        private System.Windows.Forms.Button btn_close_request;
        private System.Windows.Forms.Label label_found;
        private System.Windows.Forms.TextBox textBox_found_requests;
        private System.Windows.Forms.Label label_count_of_requests;
        private System.Windows.Forms.Button btn_reset_filters;
        private System.Windows.Forms.Button btn_edit_request;
        private System.Windows.Forms.Button btn_CalculateAverageRepairTime;
        private System.Windows.Forms.TextBox textBox_modelID;
        private System.Windows.Forms.Label label1;
    }
}