namespace SQLApp
{
    partial class VetForm
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
            this.topPanel = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.gradientButton4 = new SQLApp.GradientButton();
            this.gradientButton3 = new SQLApp.GradientButton();
            this.gradientButton2 = new SQLApp.GradientButton();
            this.gradientButton1 = new SQLApp.GradientButton();
            this.applicationsDataGridView = new System.Windows.Forms.DataGridView();
            this.userInfoLabel = new System.Windows.Forms.Label();
            this.userLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.applicationsDataGridView)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.SlateBlue;
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.topPanel.ForeColor = System.Drawing.Color.White;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1035, 100);
            this.topPanel.TabIndex = 0;
            this.topPanel.Text = "Приемы";
            this.topPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.topPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseDown);
            this.topPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseMove);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mainPanel.Controls.Add(this.gradientButton4);
            this.mainPanel.Controls.Add(this.gradientButton3);
            this.mainPanel.Controls.Add(this.gradientButton2);
            this.mainPanel.Controls.Add(this.gradientButton1);
            this.mainPanel.Controls.Add(this.applicationsDataGridView);
            this.mainPanel.Controls.Add(this.userInfoLabel);
            this.mainPanel.Controls.Add(this.userLabel);
            this.mainPanel.Controls.Add(this.panel2);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1035, 523);
            this.mainPanel.TabIndex = 2;
            this.mainPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainPanel_MouseDown);
            this.mainPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainPanel_MouseMove);
            // 
            // gradientButton4
            // 
            this.gradientButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gradientButton4.Angle = 45F;
            this.gradientButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gradientButton4.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gradientButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gradientButton4.Location = new System.Drawing.Point(771, 456);
            this.gradientButton4.Name = "gradientButton4";
            this.gradientButton4.Size = new System.Drawing.Size(246, 44);
            this.gradientButton4.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gradientButton4.TabIndex = 21;
            this.gradientButton4.Text = "Мое расписание";
            this.gradientButton4.UseVisualStyleBackColor = true;
            this.gradientButton4.Click += new System.EventHandler(this.gradientButton4_Click);
            // 
            // gradientButton3
            // 
            this.gradientButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gradientButton3.Angle = 45F;
            this.gradientButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gradientButton3.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gradientButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gradientButton3.Location = new System.Drawing.Point(513, 456);
            this.gradientButton3.Name = "gradientButton3";
            this.gradientButton3.Size = new System.Drawing.Size(246, 44);
            this.gradientButton3.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gradientButton3.TabIndex = 20;
            this.gradientButton3.Text = "Выгрузить отчет";
            this.gradientButton3.UseVisualStyleBackColor = true;
            this.gradientButton3.Click += new System.EventHandler(this.gradientButton3_Click);
            // 
            // gradientButton2
            // 
            this.gradientButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gradientButton2.Angle = 45F;
            this.gradientButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gradientButton2.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gradientButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gradientButton2.Location = new System.Drawing.Point(252, 456);
            this.gradientButton2.Name = "gradientButton2";
            this.gradientButton2.Size = new System.Drawing.Size(246, 44);
            this.gradientButton2.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gradientButton2.TabIndex = 19;
            this.gradientButton2.Text = "Просмотреть прием";
            this.gradientButton2.UseVisualStyleBackColor = true;
            this.gradientButton2.Click += new System.EventHandler(this.gradientButton2_Click);
            // 
            // gradientButton1
            // 
            this.gradientButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gradientButton1.Angle = 45F;
            this.gradientButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gradientButton1.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gradientButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gradientButton1.Location = new System.Drawing.Point(813, 113);
            this.gradientButton1.Name = "gradientButton1";
            this.gradientButton1.Size = new System.Drawing.Size(204, 44);
            this.gradientButton1.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gradientButton1.TabIndex = 18;
            this.gradientButton1.Text = "Мой профиль";
            this.gradientButton1.UseVisualStyleBackColor = true;
            this.gradientButton1.Click += new System.EventHandler(this.gradientButton1_Click);
            // 
            // applicationsDataGridView
            // 
            this.applicationsDataGridView.AllowUserToAddRows = false;
            this.applicationsDataGridView.AllowUserToDeleteRows = false;
            this.applicationsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.applicationsDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.applicationsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.applicationsDataGridView.Location = new System.Drawing.Point(12, 186);
            this.applicationsDataGridView.Name = "applicationsDataGridView";
            this.applicationsDataGridView.ReadOnly = true;
            this.applicationsDataGridView.RowHeadersWidth = 51;
            this.applicationsDataGridView.RowTemplate.Height = 24;
            this.applicationsDataGridView.Size = new System.Drawing.Size(1011, 255);
            this.applicationsDataGridView.TabIndex = 6;
            // 
            // userInfoLabel
            // 
            this.userInfoLabel.AutoSize = true;
            this.userInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userInfoLabel.Location = new System.Drawing.Point(13, 135);
            this.userInfoLabel.Name = "userInfoLabel";
            this.userInfoLabel.Size = new System.Drawing.Size(143, 20);
            this.userInfoLabel.TabIndex = 4;
            this.userInfoLabel.Text = "Пользователь";
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userLabel.Location = new System.Drawing.Point(12, 113);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(130, 20);
            this.userLabel.TabIndex = 2;
            this.userLabel.Text = "Вы вошли как:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Purple;
            this.panel2.Controls.Add(this.topPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1035, 100);
            this.panel2.TabIndex = 0;
            // 
            // VetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 523);
            this.Controls.Add(this.mainPanel);
            this.MinimumSize = new System.Drawing.Size(1053, 570);
            this.Name = "VetForm";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.applicationsDataGridView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label topPanel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.DataGridView applicationsDataGridView;
        private System.Windows.Forms.Label userInfoLabel;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Panel panel2;
        private GradientButton gradientButton1;
        private GradientButton gradientButton2;
        private GradientButton gradientButton3;
        private GradientButton gradientButton4;
    }
}