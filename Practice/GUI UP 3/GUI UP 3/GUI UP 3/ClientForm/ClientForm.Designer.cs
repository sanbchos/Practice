namespace GUI
{
    partial class ClientForm
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
            this.pictureBox_base_photo = new System.Windows.Forms.PictureBox();
            this.fio_label = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_back_to_menu = new System.Windows.Forms.Button();
            this.fio_role_label = new System.Windows.Forms.Label();
            this.btn_create_request = new System.Windows.Forms.Button();
            this.dataGridView_all_requests_by_user = new System.Windows.Forms.DataGridView();
            this.label_requests = new System.Windows.Forms.Label();
            this.btn_found_requests_by_user = new System.Windows.Forms.Button();
            this.textBox_found_requests = new System.Windows.Forms.TextBox();
            this.label_found = new System.Windows.Forms.Label();
            this.label_count_of_reports = new System.Windows.Forms.Label();
            this.btn_reset_filters = new System.Windows.Forms.Button();
            this.btn_edit_request = new System.Windows.Forms.Button();
            this.btn_show_qr = new System.Windows.Forms.Button();
            this.pictureBox_QR_code = new System.Windows.Forms.PictureBox();
            this.btn_hide_picture = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_base_photo)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_all_requests_by_user)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_QR_code)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(155)))), ((int)(((byte)(47)))));
            this.panel1.Controls.Add(this.pictureBox_base_photo);
            this.panel1.Controls.Add(this.fio_label);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btn_back_to_menu);
            this.panel1.Controls.Add(this.fio_role_label);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(805, 126);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox_base_photo
            // 
            this.pictureBox_base_photo.Location = new System.Drawing.Point(12, 12);
            this.pictureBox_base_photo.Name = "pictureBox_base_photo";
            this.pictureBox_base_photo.Size = new System.Drawing.Size(111, 88);
            this.pictureBox_base_photo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_base_photo.TabIndex = 4;
            this.pictureBox_base_photo.TabStop = false;
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
            // btn_create_request
            // 
            this.btn_create_request.Location = new System.Drawing.Point(320, 161);
            this.btn_create_request.Name = "btn_create_request";
            this.btn_create_request.Size = new System.Drawing.Size(223, 23);
            this.btn_create_request.TabIndex = 1;
            this.btn_create_request.Text = "Составить заявку на ремонт";
            this.btn_create_request.UseVisualStyleBackColor = true;
            this.btn_create_request.Click += new System.EventHandler(this.btn_create_request_Click);
            // 
            // dataGridView_all_requests_by_user
            // 
            this.dataGridView_all_requests_by_user.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
            this.dataGridView_all_requests_by_user.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_all_requests_by_user.Location = new System.Drawing.Point(3, 313);
            this.dataGridView_all_requests_by_user.Name = "dataGridView_all_requests_by_user";
            this.dataGridView_all_requests_by_user.RowHeadersVisible = false;
            this.dataGridView_all_requests_by_user.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_all_requests_by_user.Size = new System.Drawing.Size(796, 135);
            this.dataGridView_all_requests_by_user.TabIndex = 4;
            // 
            // label_requests
            // 
            this.label_requests.AutoSize = true;
            this.label_requests.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_requests.ForeColor = System.Drawing.Color.White;
            this.label_requests.Location = new System.Drawing.Point(9, 283);
            this.label_requests.Name = "label_requests";
            this.label_requests.Size = new System.Drawing.Size(0, 16);
            this.label_requests.TabIndex = 5;
            // 
            // btn_found_requests_by_user
            // 
            this.btn_found_requests_by_user.BackColor = System.Drawing.Color.Green;
            this.btn_found_requests_by_user.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_found_requests_by_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_found_requests_by_user.ForeColor = System.Drawing.Color.White;
            this.btn_found_requests_by_user.Location = new System.Drawing.Point(168, 279);
            this.btn_found_requests_by_user.Name = "btn_found_requests_by_user";
            this.btn_found_requests_by_user.Size = new System.Drawing.Size(134, 26);
            this.btn_found_requests_by_user.TabIndex = 6;
            this.btn_found_requests_by_user.Text = "Поиск заявок";
            this.btn_found_requests_by_user.UseVisualStyleBackColor = false;
            this.btn_found_requests_by_user.Click += new System.EventHandler(this.btn_found_requests_by_user_Click);
            // 
            // textBox_found_requests
            // 
            this.textBox_found_requests.BackColor = System.Drawing.Color.White;
            this.textBox_found_requests.Location = new System.Drawing.Point(311, 283);
            this.textBox_found_requests.Name = "textBox_found_requests";
            this.textBox_found_requests.Size = new System.Drawing.Size(168, 20);
            this.textBox_found_requests.TabIndex = 7;
            // 
            // label_found
            // 
            this.label_found.AutoSize = true;
            this.label_found.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_found.ForeColor = System.Drawing.Color.White;
            this.label_found.Location = new System.Drawing.Point(308, 265);
            this.label_found.Name = "label_found";
            this.label_found.Size = new System.Drawing.Size(126, 15);
            this.label_found.TabIndex = 8;
            this.label_found.Text = "Критерий поиска:";
            // 
            // label_count_of_reports
            // 
            this.label_count_of_reports.AutoSize = true;
            this.label_count_of_reports.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_count_of_reports.ForeColor = System.Drawing.Color.White;
            this.label_count_of_reports.Location = new System.Drawing.Point(543, 283);
            this.label_count_of_reports.Name = "label_count_of_reports";
            this.label_count_of_reports.Size = new System.Drawing.Size(0, 15);
            this.label_count_of_reports.TabIndex = 9;
            // 
            // btn_reset_filters
            // 
            this.btn_reset_filters.BackColor = System.Drawing.Color.Red;
            this.btn_reset_filters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reset_filters.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_reset_filters.ForeColor = System.Drawing.Color.White;
            this.btn_reset_filters.Location = new System.Drawing.Point(168, 230);
            this.btn_reset_filters.Name = "btn_reset_filters";
            this.btn_reset_filters.Size = new System.Drawing.Size(134, 43);
            this.btn_reset_filters.TabIndex = 10;
            this.btn_reset_filters.Text = "Сбросить параметры";
            this.btn_reset_filters.UseVisualStyleBackColor = false;
            this.btn_reset_filters.Click += new System.EventHandler(this.btn_reset_filters_Click);
            // 
            // btn_edit_request
            // 
            this.btn_edit_request.Location = new System.Drawing.Point(320, 201);
            this.btn_edit_request.Name = "btn_edit_request";
            this.btn_edit_request.Size = new System.Drawing.Size(223, 23);
            this.btn_edit_request.TabIndex = 3;
            this.btn_edit_request.Text = "Редактировать заявку";
            this.btn_edit_request.UseVisualStyleBackColor = true;
            this.btn_edit_request.Click += new System.EventHandler(this.btn_edit_request_Click);
            // 
            // btn_show_qr
            // 
            this.btn_show_qr.Location = new System.Drawing.Point(320, 239);
            this.btn_show_qr.Name = "btn_show_qr";
            this.btn_show_qr.Size = new System.Drawing.Size(223, 23);
            this.btn_show_qr.TabIndex = 11;
            this.btn_show_qr.Text = "Показать QR код";
            this.btn_show_qr.UseVisualStyleBackColor = true;
            this.btn_show_qr.Click += new System.EventHandler(this.btn_show_qr_Click);
            // 
            // pictureBox_QR_code
            // 
            this.pictureBox_QR_code.BackColor = System.Drawing.Color.White;
            this.pictureBox_QR_code.Location = new System.Drawing.Point(549, 126);
            this.pictureBox_QR_code.Name = "pictureBox_QR_code";
            this.pictureBox_QR_code.Size = new System.Drawing.Size(182, 191);
            this.pictureBox_QR_code.TabIndex = 12;
            this.pictureBox_QR_code.TabStop = false;
            // 
            // btn_hide_picture
            // 
            this.btn_hide_picture.Location = new System.Drawing.Point(12, 142);
            this.btn_hide_picture.Name = "btn_hide_picture";
            this.btn_hide_picture.Size = new System.Drawing.Size(75, 23);
            this.btn_hide_picture.TabIndex = 13;
            this.btn_hide_picture.Text = "Скрыть QR";
            this.btn_hide_picture.UseVisualStyleBackColor = true;
            this.btn_hide_picture.Click += new System.EventHandler(this.btn_hide_picture_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(804, 461);
            this.Controls.Add(this.btn_hide_picture);
            this.Controls.Add(this.pictureBox_QR_code);
            this.Controls.Add(this.btn_show_qr);
            this.Controls.Add(this.btn_reset_filters);
            this.Controls.Add(this.label_count_of_reports);
            this.Controls.Add(this.label_found);
            this.Controls.Add(this.textBox_found_requests);
            this.Controls.Add(this.btn_found_requests_by_user);
            this.Controls.Add(this.label_requests);
            this.Controls.Add(this.dataGridView_all_requests_by_user);
            this.Controls.Add(this.btn_edit_request);
            this.Controls.Add(this.btn_create_request);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(820, 500);
            this.MinimumSize = new System.Drawing.Size(820, 500);
            this.Name = "ClientForm";
            this.Text = "Ваши заявки:";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_base_photo)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_all_requests_by_user)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_QR_code)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_back_to_menu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_create_request;
        private System.Windows.Forms.DataGridView dataGridView_all_requests_by_user;
        private System.Windows.Forms.Label label_requests;
        private System.Windows.Forms.Button btn_found_requests_by_user;
        private System.Windows.Forms.PictureBox pictureBox_base_photo;
        private System.Windows.Forms.Label fio_label;
        private System.Windows.Forms.Label fio_role_label;
        private System.Windows.Forms.TextBox textBox_found_requests;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_found;
        private System.Windows.Forms.Label label_count_of_reports;
        private System.Windows.Forms.Button btn_reset_filters;
        private System.Windows.Forms.Button btn_edit_request;
        private System.Windows.Forms.Button btn_show_qr;
        private System.Windows.Forms.PictureBox pictureBox_QR_code;
        private System.Windows.Forms.Button btn_hide_picture;
    }
}