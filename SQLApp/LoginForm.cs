using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using System.Windows.Forms;

namespace SQLApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.Sizable;

            this.FormClosing += LoginForm_FormClosing;

            this.passField.AutoSize = false;
            this.passField.Size = new Size(this.passField.Size.Width, 64);
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        Point lastPoint;
        private void mainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void mainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void topPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void topPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        public static string userInformation;
        public static string accessName = "";

        private void RegisterLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm chosenUserForm = new RegisterForm();
            chosenUserForm.Show();
        }

        public static string id_user = "";

        private void gradientButton1_Click(object sender, EventArgs e)
        {

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM accounts WHERE `email` = @uE AND `password` = SHA2(@uP, 256)", db.getConnection());
            command.Parameters.Add("@uE", MySqlDbType.VarChar).Value = emailField.Text;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passField.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            MySqlCommand command3 = new MySqlCommand("SELECT * FROM accounts WHERE accounts.email = @userEmail", db.getConnection());
            command3.Parameters.AddWithValue("@userEmail", emailField.Text);

            db.openConnection();

            MySqlDataReader reader2 = command3.ExecuteReader();

            if (reader2.Read())
            {
                id_user = reader2["id_user"].ToString();
                userInformation = reader2["email"].ToString();
            }

            db.closeConnection();

            if (table.Rows.Count > 0)
            {

                MySqlCommand command2 = new MySqlCommand("SELECT * FROM accounts WHERE accounts.email = @userEmail", db.getConnection());
                command2.Parameters.AddWithValue("@userEmail", emailField.Text);

                string accessLevel = "1";

                db.openConnection();

                MySqlDataReader reader = command2.ExecuteReader();

                if (reader.Read())
                {
                    accessLevel = reader["id_access"].ToString();
                }

                db.closeConnection();

                if (accessLevel == "1")
                {
                    accessName = "Сотрудник";
                    VetForm.id = id_user;
                    this.Hide();
                    VetForm vetForm = new VetForm();
                    vetForm.Show();
                }
                else if (accessLevel == "2")
                {
                    accessName = "Клиент";
                    MainForm.id = id_user;
                    this.Hide();
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                }
            }
            else
                if (emailField.Text == userInformation)
                MessageBox.Show("Неверный пароль");
            else
                MessageBox.Show("Такого пользователя не существует");
        }
    }
}
