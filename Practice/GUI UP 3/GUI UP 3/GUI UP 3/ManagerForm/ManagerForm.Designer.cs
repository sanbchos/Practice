namespace GUI
{
    partial class ManagerForm
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
            this.pictureBox_photo = new System.Windows.Forms.PictureBox();
            this.fio_label = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_back_to_menu = new System.Windows.Forms.Button();
            this.fio_role_label = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView_requests_for_manager = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label_requests = new System.Windows.Forms.Label();
            this.label_count_of_reports = new System.Windows.Forms.Label();
            this.btn_reset_filters = new System.Windows.Forms.Button();
            this.label_found = new System.Windows.Forms.Label();
            this.textBox_found_requests = new System.Windows.Forms.TextBox();
            this.btn_found_requests_by_user = new System.Windows.Forms.Button();
            this.btn_edit_request = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_photo)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_requests_for_manager)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(155)))), ((int)(((byte)(47)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox_photo);
            this.panel1.Controls.Add(this.fio_label);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btn_back_to_menu);
            this.panel1.Controls.Add(this.fio_role_label);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(805, 126);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox_photo
            // 
            this.pictureBox_photo.Location = new System.Drawing.Point(12, 12);
            this.pictureBox_photo.Name = "pictureBox_photo";
            this.pictureBox_photo.Size = new System.Drawing.Size(111, 88);
            this.pictureBox_photo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_photo.TabIndex = 4;
            this.pictureBox_photo.TabStop = false;
            // 
            // fio_label
            // 
            this.fio_label.AutoSize = true;
            this.fio_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fio_label.ForeColor = System.Drawing.Color.White;
            this.fio_label.Location = new System.Drawing.Point(136, 21);
            this.fio_label.Name = "fio_label";
            this.fio_label.Size = new System.Drawing.Size(0, 16);
            this.fio_label.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 123);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(802, 328);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(261, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Критерий поиска:";
            // 
            // btn_back_to_menu
            // 
            this.btn_back_to_menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_back_to_menu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_back_to_menu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_back_to_menu.Location = new System.Drawing.Point(689, 12);
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
            this.fio_role_label.Location = new System.Drawing.Point(110, 3);
            this.fio_role_label.Name = "fio_role_label";
            this.fio_role_label.Size = new System.Drawing.Size(0, 13);
            this.fio_role_label.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
            this.panel3.Controls.Add(this.btn_edit_request);
            this.panel3.Controls.Add(this.btn_found_requests_by_user);
            this.panel3.Controls.Add(this.label_found);
            this.panel3.Controls.Add(this.textBox_found_requests);
            this.panel3.Controls.Add(this.btn_reset_filters);
            this.panel3.Controls.Add(this.label_count_of_reports);
            this.panel3.Controls.Add(this.label_requests);
            this.panel3.Controls.Add(this.dataGridView_requests_for_manager);
            this.panel3.Location = new System.Drawing.Point(-1, 106);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(802, 345);
            this.panel3.TabIndex = 2;
            // 
            // dataGridView_requests_for_manager
            // 
            this.dataGridView_requests_for_manager.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_requests_for_manager.Location = new System.Drawing.Point(12, 173);
            this.dataGridView_requests_for_manager.Name = "dataGridView_requests_for_manager";
            this.dataGridView_requests_for_manager.RowHeadersVisible = false;
            this.dataGridView_requests_for_manager.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_requests_for_manager.Size = new System.Drawing.Size(773, 150);
            this.dataGridView_requests_for_manager.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(142, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 5;
            // 
            // label_requests
            // 
            this.label_requests.AutoSize = true;
            this.label_requests.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_requests.ForeColor = System.Drawing.Color.White;
            this.label_requests.Location = new System.Drawing.Point(13, 137);
            this.label_requests.Name = "label_requests";
            this.label_requests.Size = new System.Drawing.Size(0, 16);
            this.label_requests.TabIndex = 6;
            // 
            // label_count_of_reports
            // 
            this.label_count_of_reports.AutoSize = true;
            this.label_count_of_reports.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_count_of_reports.ForeColor = System.Drawing.Color.White;
            this.label_count_of_reports.Location = new System.Drawing.Point(497, 123);
            this.label_count_of_reports.Name = "label_count_of_reports";
            this.label_count_of_reports.Size = new System.Drawing.Size(123, 16);
            this.label_count_of_reports.TabIndex = 7;
            this.label_count_of_reports.Text = "Кол-во записей";
            // 
            // btn_reset_filters
            // 
            this.btn_reset_filters.BackColor = System.Drawing.Color.Red;
            this.btn_reset_filters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reset_filters.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_reset_filters.ForeColor = System.Drawing.Color.White;
            this.btn_reset_filters.Location = new System.Drawing.Point(174, 78);
            this.btn_reset_filters.Name = "btn_reset_filters";
            this.btn_reset_filters.Size = new System.Drawing.Size(134, 43);
            this.btn_reset_filters.TabIndex = 11;
            this.btn_reset_filters.Text = "Сбросить параметры";
            this.btn_reset_filters.UseVisualStyleBackColor = false;
            this.btn_reset_filters.Click += new System.EventHandler(this.btn_reset_filters_Click);
            // 
            // label_found
            // 
            this.label_found.AutoSize = true;
            this.label_found.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_found.ForeColor = System.Drawing.Color.White;
            this.label_found.Location = new System.Drawing.Point(311, 92);
            this.label_found.Name = "label_found";
            this.label_found.Size = new System.Drawing.Size(126, 15);
            this.label_found.TabIndex = 13;
            this.label_found.Text = "Критерий поиска:";
            // 
            // textBox_found_requests
            // 
            this.textBox_found_requests.BackColor = System.Drawing.Color.White;
            this.textBox_found_requests.Location = new System.Drawing.Point(314, 110);
            this.textBox_found_requests.Name = "textBox_found_requests";
            this.textBox_found_requests.Size = new System.Drawing.Size(168, 20);
            this.textBox_found_requests.TabIndex = 12;
            // 
            // btn_found_requests_by_user
            // 
            this.btn_found_requests_by_user.BackColor = System.Drawing.Color.Green;
            this.btn_found_requests_by_user.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_found_requests_by_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_found_requests_by_user.ForeColor = System.Drawing.Color.White;
            this.btn_found_requests_by_user.Location = new System.Drawing.Point(174, 131);
            this.btn_found_requests_by_user.Name = "btn_found_requests_by_user";
            this.btn_found_requests_by_user.Size = new System.Drawing.Size(134, 26);
            this.btn_found_requests_by_user.TabIndex = 14;
            this.btn_found_requests_by_user.Text = "Поиск заявок";
            this.btn_found_requests_by_user.UseVisualStyleBackColor = false;
            this.btn_found_requests_by_user.Click += new System.EventHandler(this.btn_found_requests_by_user_Click);
            // 
            // btn_edit_request
            // 
            this.btn_edit_request.BackColor = System.Drawing.Color.Teal;
            this.btn_edit_request.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_edit_request.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_edit_request.ForeColor = System.Drawing.Color.White;
            this.btn_edit_request.Location = new System.Drawing.Point(325, 50);
            this.btn_edit_request.Name = "btn_edit_request";
            this.btn_edit_request.Size = new System.Drawing.Size(196, 26);
            this.btn_edit_request.TabIndex = 15;
            this.btn_edit_request.Text = "Взять заявку в работу";
            this.btn_edit_request.UseVisualStyleBackColor = false;
            this.btn_edit_request.Click += new System.EventHandler(this.btn_edit_request_Click);
            // 
            // ManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Name = "ManagerForm";
            this.Text = "Форма менеджера";
            this.Load += new System.EventHandler(this.ManagerForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_photo)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_requests_for_manager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox_photo;
        private System.Windows.Forms.Label fio_label;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_back_to_menu;
        private System.Windows.Forms.Label fio_role_label;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView_requests_for_manager;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_requests;
        private System.Windows.Forms.Label label_count_of_reports;
        private System.Windows.Forms.Button btn_reset_filters;
        private System.Windows.Forms.Label label_found;
        private System.Windows.Forms.TextBox textBox_found_requests;
        private System.Windows.Forms.Button btn_found_requests_by_user;
        private System.Windows.Forms.Button btn_edit_request;
    }
}