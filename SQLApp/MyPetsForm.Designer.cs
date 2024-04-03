﻿namespace SQLApp
{
    partial class MyPetsForm
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
            this.gradientButton3 = new SQLApp.GradientButton();
            this.gradientButton2 = new SQLApp.GradientButton();
            this.gradientButton1 = new SQLApp.GradientButton();
            this.RegisterLabel = new System.Windows.Forms.Label();
            this.petsDataGridView = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.topPanel = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.petsDataGridView)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mainPanel.Controls.Add(this.gradientButton3);
            this.mainPanel.Controls.Add(this.gradientButton2);
            this.mainPanel.Controls.Add(this.gradientButton1);
            this.mainPanel.Controls.Add(this.RegisterLabel);
            this.mainPanel.Controls.Add(this.petsDataGridView);
            this.mainPanel.Controls.Add(this.panel2);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(766, 507);
            this.mainPanel.TabIndex = 2;
            this.mainPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainPanel_MouseDown);
            this.mainPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainPanel_MouseMove);
            // 
            // gradientButton3
            // 
            this.gradientButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gradientButton3.Angle = 45F;
            this.gradientButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gradientButton3.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gradientButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gradientButton3.Location = new System.Drawing.Point(448, 431);
            this.gradientButton3.Name = "gradientButton3";
            this.gradientButton3.Size = new System.Drawing.Size(185, 45);
            this.gradientButton3.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gradientButton3.TabIndex = 13;
            this.gradientButton3.Text = "Удалить";
            this.gradientButton3.UseVisualStyleBackColor = true;
            this.gradientButton3.Click += new System.EventHandler(this.gradientButton3_Click);
            // 
            // gradientButton2
            // 
            this.gradientButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gradientButton2.Angle = 45F;
            this.gradientButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gradientButton2.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gradientButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gradientButton2.Location = new System.Drawing.Point(242, 431);
            this.gradientButton2.Name = "gradientButton2";
            this.gradientButton2.Size = new System.Drawing.Size(185, 45);
            this.gradientButton2.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gradientButton2.TabIndex = 12;
            this.gradientButton2.Text = "Изменить";
            this.gradientButton2.UseVisualStyleBackColor = true;
            this.gradientButton2.Click += new System.EventHandler(this.gradientButton2_Click);
            // 
            // gradientButton1
            // 
            this.gradientButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gradientButton1.Angle = 45F;
            this.gradientButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gradientButton1.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gradientButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gradientButton1.Location = new System.Drawing.Point(36, 431);
            this.gradientButton1.Name = "gradientButton1";
            this.gradientButton1.Size = new System.Drawing.Size(185, 45);
            this.gradientButton1.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gradientButton1.TabIndex = 11;
            this.gradientButton1.Text = "Добавить";
            this.gradientButton1.UseVisualStyleBackColor = true;
            this.gradientButton1.Click += new System.EventHandler(this.gradientButton1_Click);
            // 
            // RegisterLabel
            // 
            this.RegisterLabel.AutoSize = true;
            this.RegisterLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RegisterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegisterLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.RegisterLabel.Location = new System.Drawing.Point(656, 446);
            this.RegisterLabel.Name = "RegisterLabel";
            this.RegisterLabel.Size = new System.Drawing.Size(85, 16);
            this.RegisterLabel.TabIndex = 10;
            this.RegisterLabel.Text = "Вернуться";
            this.RegisterLabel.Click += new System.EventHandler(this.RegisterLabel_Click);
            // 
            // petsDataGridView
            // 
            this.petsDataGridView.AllowUserToAddRows = false;
            this.petsDataGridView.AllowUserToDeleteRows = false;
            this.petsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.petsDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.petsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.petsDataGridView.Location = new System.Drawing.Point(12, 120);
            this.petsDataGridView.Name = "petsDataGridView";
            this.petsDataGridView.ReadOnly = true;
            this.petsDataGridView.RowHeadersWidth = 51;
            this.petsDataGridView.RowTemplate.Height = 24;
            this.petsDataGridView.Size = new System.Drawing.Size(742, 305);
            this.petsDataGridView.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Purple;
            this.panel2.Controls.Add(this.topPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(766, 100);
            this.panel2.TabIndex = 0;
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.SlateBlue;
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.topPanel.ForeColor = System.Drawing.Color.White;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(766, 100);
            this.topPanel.TabIndex = 0;
            this.topPanel.Text = "Мои питомцы";
            this.topPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.topPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseDown);
            this.topPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseMove);
            // 
            // MyPetsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 507);
            this.Controls.Add(this.mainPanel);
            this.MinimumSize = new System.Drawing.Size(784, 554);
            this.Name = "MyPetsForm";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.petsDataGridView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.DataGridView petsDataGridView;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label topPanel;
        private System.Windows.Forms.Label RegisterLabel;
        private GradientButton gradientButton1;
        private GradientButton gradientButton2;
        private GradientButton gradientButton3;
    }
}