namespace SQLApp
{
    partial class AddPetForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateBirthPicker = new System.Windows.Forms.MaskedTextBox();
            this.RegisterButton = new SQLApp.GradientButton();
            this.sexComboBox = new System.Windows.Forms.ComboBox();
            this.backLabel = new System.Windows.Forms.Label();
            this.petNicknameField = new System.Windows.Forms.TextBox();
            this.petKindField = new System.Windows.Forms.TextBox();
            this.petBreedField = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.topPanel = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mainPanel.Controls.Add(this.label2);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.dateBirthPicker);
            this.mainPanel.Controls.Add(this.RegisterButton);
            this.mainPanel.Controls.Add(this.sexComboBox);
            this.mainPanel.Controls.Add(this.backLabel);
            this.mainPanel.Controls.Add(this.petNicknameField);
            this.mainPanel.Controls.Add(this.petKindField);
            this.mainPanel.Controls.Add(this.petBreedField);
            this.mainPanel.Controls.Add(this.panel2);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.MinimumSize = new System.Drawing.Size(800, 450);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 450);
            this.mainPanel.TabIndex = 2;
            this.mainPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainPanel_MouseDown);
            this.mainPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainPanel_MouseMove);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(58, 306);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Дата рождения:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(80, 272);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Пол питомца:";
            // 
            // dateBirthPicker
            // 
            this.dateBirthPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateBirthPicker.Location = new System.Drawing.Point(231, 303);
            this.dateBirthPicker.Mask = "00/00/0000";
            this.dateBirthPicker.Name = "dateBirthPicker";
            this.dateBirthPicker.Size = new System.Drawing.Size(189, 27);
            this.dateBirthPicker.TabIndex = 14;
            this.dateBirthPicker.ValidatingType = typeof(System.DateTime);
            // 
            // RegisterButton
            // 
            this.RegisterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RegisterButton.Angle = 45F;
            this.RegisterButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RegisterButton.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.RegisterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegisterButton.ForeColor = System.Drawing.Color.Black;
            this.RegisterButton.Location = new System.Drawing.Point(448, 282);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(308, 48);
            this.RegisterButton.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.RegisterButton.TabIndex = 13;
            this.RegisterButton.Text = "Зарегистрировать";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // sexComboBox
            // 
            this.sexComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sexComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sexComboBox.FormattingEnabled = true;
            this.sexComboBox.Items.AddRange(new object[] {
            "М",
            "Ж"});
            this.sexComboBox.Location = new System.Drawing.Point(231, 269);
            this.sexComboBox.Name = "sexComboBox";
            this.sexComboBox.Size = new System.Drawing.Size(189, 28);
            this.sexComboBox.TabIndex = 12;
            this.sexComboBox.Enter += new System.EventHandler(this.sexComboBox_Enter);
            this.sexComboBox.Leave += new System.EventHandler(this.sexComboBox_Leave);
            // 
            // backLabel
            // 
            this.backLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.backLabel.AutoSize = true;
            this.backLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.backLabel.Location = new System.Drawing.Point(671, 344);
            this.backLabel.Name = "backLabel";
            this.backLabel.Size = new System.Drawing.Size(85, 16);
            this.backLabel.TabIndex = 9;
            this.backLabel.Text = "Вернуться";
            this.backLabel.Click += new System.EventHandler(this.backLabel_Click);
            // 
            // petNicknameField
            // 
            this.petNicknameField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.petNicknameField.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.petNicknameField.Location = new System.Drawing.Point(231, 116);
            this.petNicknameField.Multiline = true;
            this.petNicknameField.Name = "petNicknameField";
            this.petNicknameField.Size = new System.Drawing.Size(525, 45);
            this.petNicknameField.TabIndex = 7;
            this.petNicknameField.Enter += new System.EventHandler(this.petNicknameField_Enter);
            this.petNicknameField.Leave += new System.EventHandler(this.petNicknameField_Leave);
            // 
            // petKindField
            // 
            this.petKindField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.petKindField.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.petKindField.Location = new System.Drawing.Point(231, 167);
            this.petKindField.Multiline = true;
            this.petKindField.Name = "petKindField";
            this.petKindField.Size = new System.Drawing.Size(525, 45);
            this.petKindField.TabIndex = 6;
            this.petKindField.Enter += new System.EventHandler(this.petKindField_Enter);
            this.petKindField.Leave += new System.EventHandler(this.petKindField_Leave);
            // 
            // petBreedField
            // 
            this.petBreedField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.petBreedField.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.petBreedField.Location = new System.Drawing.Point(231, 218);
            this.petBreedField.Multiline = true;
            this.petBreedField.Name = "petBreedField";
            this.petBreedField.Size = new System.Drawing.Size(525, 45);
            this.petBreedField.TabIndex = 2;
            this.petBreedField.Enter += new System.EventHandler(this.petBreedField_Enter);
            this.petBreedField.Leave += new System.EventHandler(this.petBreedField_Leave);
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
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(800, 100);
            this.topPanel.TabIndex = 0;
            this.topPanel.Text = "Регистрация питомца";
            this.topPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.topPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseDown);
            this.topPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseMove);
            // 
            // AddPetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 381);
            this.Controls.Add(this.mainPanel);
            this.MinimumSize = new System.Drawing.Size(795, 428);
            this.Name = "AddPetForm";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label backLabel;
        private System.Windows.Forms.TextBox petNicknameField;
        private System.Windows.Forms.TextBox petKindField;
        private System.Windows.Forms.TextBox petBreedField;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label topPanel;
        private System.Windows.Forms.ComboBox sexComboBox;
        private GradientButton RegisterButton;
        private System.Windows.Forms.MaskedTextBox dateBirthPicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}