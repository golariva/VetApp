namespace SQLApp
{
    partial class ApplicationForm
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.gradientButton1 = new SQLApp.GradientButton();
            this.AvailableTimeDataGridView = new System.Windows.Forms.DataGridView();
            this.appointmentLabel = new System.Windows.Forms.Label();
            this.veterinarianLabel = new System.Windows.Forms.Label();
            this.serviceLabel = new System.Windows.Forms.Label();
            this.petLabel = new System.Windows.Forms.Label();
            this.veterinarianComboBox = new System.Windows.Forms.ComboBox();
            this.serviceComboBox = new System.Windows.Forms.ComboBox();
            this.petComboBox = new System.Windows.Forms.ComboBox();
            this.RegisterLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.topPanel = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AvailableTimeDataGridView)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mainPanel.Controls.Add(this.gradientButton1);
            this.mainPanel.Controls.Add(this.AvailableTimeDataGridView);
            this.mainPanel.Controls.Add(this.appointmentLabel);
            this.mainPanel.Controls.Add(this.veterinarianLabel);
            this.mainPanel.Controls.Add(this.serviceLabel);
            this.mainPanel.Controls.Add(this.petLabel);
            this.mainPanel.Controls.Add(this.veterinarianComboBox);
            this.mainPanel.Controls.Add(this.serviceComboBox);
            this.mainPanel.Controls.Add(this.petComboBox);
            this.mainPanel.Controls.Add(this.RegisterLabel);
            this.mainPanel.Controls.Add(this.panel2);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.MinimumSize = new System.Drawing.Size(800, 450);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 480);
            this.mainPanel.TabIndex = 2;
            this.mainPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainPanel_MouseDown);
            this.mainPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainPanel_MouseMove);
            // 
            // gradientButton1
            // 
            this.gradientButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gradientButton1.Angle = 45F;
            this.gradientButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gradientButton1.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gradientButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gradientButton1.Location = new System.Drawing.Point(444, 403);
            this.gradientButton1.Name = "gradientButton1";
            this.gradientButton1.Size = new System.Drawing.Size(302, 48);
            this.gradientButton1.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gradientButton1.TabIndex = 20;
            this.gradientButton1.Text = "Записаться на прием";
            this.gradientButton1.UseVisualStyleBackColor = true;
            this.gradientButton1.Click += new System.EventHandler(this.gradientButton1_Click);
            // 
            // AvailableTimeDataGridView
            // 
            this.AvailableTimeDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AvailableTimeDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.AvailableTimeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AvailableTimeDataGridView.Location = new System.Drawing.Point(184, 232);
            this.AvailableTimeDataGridView.Name = "AvailableTimeDataGridView";
            this.AvailableTimeDataGridView.RowHeadersWidth = 51;
            this.AvailableTimeDataGridView.RowTemplate.Height = 24;
            this.AvailableTimeDataGridView.Size = new System.Drawing.Size(494, 151);
            this.AvailableTimeDataGridView.TabIndex = 19;
            // 
            // appointmentLabel
            // 
            this.appointmentLabel.AllowDrop = true;
            this.appointmentLabel.AutoSize = true;
            this.appointmentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.appointmentLabel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.appointmentLabel.Location = new System.Drawing.Point(22, 245);
            this.appointmentLabel.Name = "appointmentLabel";
            this.appointmentLabel.Size = new System.Drawing.Size(145, 40);
            this.appointmentLabel.TabIndex = 18;
            this.appointmentLabel.Text = "Доступные окна\r\nдля приема:";
            this.appointmentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // veterinarianLabel
            // 
            this.veterinarianLabel.AllowDrop = true;
            this.veterinarianLabel.AutoSize = true;
            this.veterinarianLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.veterinarianLabel.Location = new System.Drawing.Point(61, 166);
            this.veterinarianLabel.Name = "veterinarianLabel";
            this.veterinarianLabel.Size = new System.Drawing.Size(106, 20);
            this.veterinarianLabel.TabIndex = 17;
            this.veterinarianLabel.Text = "Ветеринар:";
            // 
            // serviceLabel
            // 
            this.serviceLabel.AllowDrop = true;
            this.serviceLabel.AutoSize = true;
            this.serviceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.serviceLabel.Location = new System.Drawing.Point(97, 201);
            this.serviceLabel.Name = "serviceLabel";
            this.serviceLabel.Size = new System.Drawing.Size(70, 20);
            this.serviceLabel.TabIndex = 16;
            this.serviceLabel.Text = "Услуга:";
            // 
            // petLabel
            // 
            this.petLabel.AllowDrop = true;
            this.petLabel.AutoSize = true;
            this.petLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.petLabel.Location = new System.Drawing.Point(40, 129);
            this.petLabel.Name = "petLabel";
            this.petLabel.Size = new System.Drawing.Size(127, 20);
            this.petLabel.TabIndex = 15;
            this.petLabel.Text = "Ваш питомец:";
            // 
            // veterinarianComboBox
            // 
            this.veterinarianComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.veterinarianComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.veterinarianComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.veterinarianComboBox.FormattingEnabled = true;
            this.veterinarianComboBox.Location = new System.Drawing.Point(184, 160);
            this.veterinarianComboBox.Name = "veterinarianComboBox";
            this.veterinarianComboBox.Size = new System.Drawing.Size(453, 28);
            this.veterinarianComboBox.TabIndex = 14;
            this.veterinarianComboBox.SelectedIndexChanged += new System.EventHandler(this.veterinarianComboBox_SelectedIndexChanged);
            // 
            // serviceComboBox
            // 
            this.serviceComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serviceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serviceComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.serviceComboBox.FormattingEnabled = true;
            this.serviceComboBox.Location = new System.Drawing.Point(184, 198);
            this.serviceComboBox.Name = "serviceComboBox";
            this.serviceComboBox.Size = new System.Drawing.Size(453, 28);
            this.serviceComboBox.TabIndex = 13;
            this.serviceComboBox.SelectedIndexChanged += new System.EventHandler(this.serviceComboBox_SelectedIndexChanged);
            // 
            // petComboBox
            // 
            this.petComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.petComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.petComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.petComboBox.FormattingEnabled = true;
            this.petComboBox.Location = new System.Drawing.Point(184, 126);
            this.petComboBox.Name = "petComboBox";
            this.petComboBox.Size = new System.Drawing.Size(181, 28);
            this.petComboBox.TabIndex = 12;
            this.petComboBox.SelectedIndexChanged += new System.EventHandler(this.petComboBox_SelectedIndexChanged);
            // 
            // RegisterLabel
            // 
            this.RegisterLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RegisterLabel.AutoSize = true;
            this.RegisterLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RegisterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegisterLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.RegisterLabel.Location = new System.Drawing.Point(41, 424);
            this.RegisterLabel.Name = "RegisterLabel";
            this.RegisterLabel.Size = new System.Drawing.Size(85, 16);
            this.RegisterLabel.TabIndex = 9;
            this.RegisterLabel.Text = "Вернуться";
            this.RegisterLabel.Click += new System.EventHandler(this.RegisterLabel_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Purple;
            this.panel2.Controls.Add(this.topPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 100);
            this.panel2.TabIndex = 0;
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.SlateBlue;
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.topPanel.ForeColor = System.Drawing.Color.White;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.MinimumSize = new System.Drawing.Size(685, 100);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(800, 100);
            this.topPanel.TabIndex = 0;
            this.topPanel.Text = "Запись на прием";
            this.topPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.topPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseDown);
            this.topPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseMove);
            // 
            // ApplicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 480);
            this.Controls.Add(this.mainPanel);
            this.MinimumSize = new System.Drawing.Size(792, 527);
            this.Name = "ApplicationForm";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AvailableTimeDataGridView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label RegisterLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label topPanel;
        private System.Windows.Forms.Label veterinarianLabel;
        private System.Windows.Forms.Label serviceLabel;
        private System.Windows.Forms.Label petLabel;
        private System.Windows.Forms.ComboBox veterinarianComboBox;
        private System.Windows.Forms.ComboBox serviceComboBox;
        private System.Windows.Forms.ComboBox petComboBox;
        private System.Windows.Forms.Label appointmentLabel;
        private System.Windows.Forms.DataGridView AvailableTimeDataGridView;
        private GradientButton gradientButton1;
    }
}