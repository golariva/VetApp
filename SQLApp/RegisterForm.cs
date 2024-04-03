using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLApp
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.Sizable;

            this.FormClosing += RegisterForm_FormClosing;

            userNameField.Text = "Введите имя";
            userNameField.ForeColor = Color.Gray;

            userSurnameField.Text = "Введите фамилию";
            userSurnameField.ForeColor = Color.Gray;

            userPatroField.Text = "Введите отчество";
            userPatroField.ForeColor = Color.Gray;

            passField.Text = "Введите пароль";
            passField.ForeColor = Color.Gray;
            passField.UseSystemPasswordChar = false;

            passFieldRepeat.Text = "Повторите пароль";
            passFieldRepeat.ForeColor = Color.Gray;
            passFieldRepeat.UseSystemPasswordChar = false;

            emailField.Text = "Введите наименование электронной почты";
            emailField.ForeColor = Color.Gray;
        }

        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void userNameField_Enter(object sender, EventArgs e)
        {
            if (userNameField.Text == "Введите имя")
            {
                userNameField.Text = "";
                userNameField.ForeColor = Color.Black;
            }
        }

        private void userNameField_Leave(object sender, EventArgs e)
        {
            if (userNameField.Text == "")
            {
                userNameField.Text = "Введите имя";
                userNameField.ForeColor = Color.Gray;
            }
        }

        private void userSurnameField_Enter(object sender, EventArgs e)
        {
            if (userSurnameField.Text == "Введите фамилию")
            {
                userSurnameField.Text = "";
                userSurnameField.ForeColor = Color.Black;
            }
        }

        private void userSurnameField_Leave(object sender, EventArgs e)
        {
            if (userSurnameField.Text == "")
            {
                userSurnameField.Text = "Введите фамилию";
                userSurnameField.ForeColor = Color.Gray;
            }
        }

        private void userPatroField_Enter(object sender, EventArgs e)
        {
            if (userPatroField.Text == "Введите отчество")
            {
                userPatroField.Text = "";
                userPatroField.ForeColor = Color.Black;
            }
        }

        private void userPatroField_Leave(object sender, EventArgs e)
        {
            if (userPatroField.Text == "")
            {
                userPatroField.Text = "Введите отчество";
                userPatroField.ForeColor = Color.Gray;
            }
        }

        private void passField_Enter(object sender, EventArgs e)
        {
            if (passField.Text == "Введите пароль")
            {
                passField.UseSystemPasswordChar = true;
                passField.Text = "";
                passField.ForeColor = Color.Black;
            }
        }

        private void passField_Leave(object sender, EventArgs e)
        {
            if (passField.Text == "")
            {
                passField.UseSystemPasswordChar = false;
                passField.Text = "Введите пароль";
                passField.ForeColor = Color.Gray;
            }
        }


        private void emailField_Enter(object sender, EventArgs e)
        {
            if (emailField.Text == "Введите наименование электронной почты")
            {
                emailField.Text = "";
                emailField.ForeColor = Color.Black;
            }
        }

        private void emailField_Leave(object sender, EventArgs e)
        {
            if (emailField.Text == "")
            {
                emailField.Text = "Введите наименование электронной почты";
                emailField.ForeColor = Color.Gray;
            }
        }

        public Boolean isUserExists()
        {
            DB db = new DB();

            db.openConnection();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM accounts WHERE `email` = @uE", db.getConnection());
            command.Parameters.Add("@uE", MySqlDbType.VarChar).Value = emailField.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            db.closeConnection();

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Пользователь с такой почтой уже существует");
                return true;
            }
            else
                return false;
        }

        private void RegisterLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void passFieldRepeat_Enter(object sender, EventArgs e)
        {
            if (passFieldRepeat.Text == "Повторите пароль")
            {
                passFieldRepeat.UseSystemPasswordChar = true;
                passFieldRepeat.Text = "";
                passFieldRepeat.ForeColor = Color.Black;
            }
        }

        private void passFieldRepeat_Leave(object sender, EventArgs e)
        {
            if (passFieldRepeat.Text == "")
            {
                passFieldRepeat.UseSystemPasswordChar = false;
                passFieldRepeat.Text = "Повторите пароль";
                passFieldRepeat.ForeColor = Color.Gray;
            }
        }

        private void gradientButton1_Click(object sender, EventArgs e)
        {
            if (userNameField.Text == "Введите имя" || userSurnameField.Text == "Введите фамилию" 
                || emailField.Text == "Введите наименование электронной почты" || passField.Text == "Введите пароль" 
                || passFieldRepeat.Text == "Повторите пароль" || !phoneNumberField.MaskCompleted)
            {
                MessageBox.Show("Не все данные были заполнены \n Аккаунт не был создан");
                return;
            }

            if (passField.Text != passFieldRepeat.Text && passField.Text != "Введите пароль" && passFieldRepeat.Text != "Повторите пароль")
            {
                MessageBox.Show("Повторите пароль корректно");
                return;
            }

            if (passField.Text.Length < 8)
            {
                MessageBox.Show("Длина пароля должна быть не менее 8 символов");
                return;
            }

            if (IsDateValid(dateBirthPicker.Text) == DateTime.MinValue)
            {
                MessageBox.Show("Укажите верную дату рождения");
                return;
            }

            if (isUserExists())
                return;

            DB db = new DB();

            db.openConnection();

            MySqlCommand command = new MySqlCommand("INSERT INTO accounts (id_access, email, password) VALUES (2, @email, SHA2(@password, 256))", db.getConnection());
            MySqlCommand command2 = new MySqlCommand("INSERT INTO clients (id_user, surname, name, patronymic, phone_number, date_birth) VALUES (@id_user, @surname, @name, @patronymic, @phone_number, @date_birth)", db.getConnection());

            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = emailField.Text;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = passField.Text;

            if (command.ExecuteNonQuery() == 1)
            {
                command.CommandText = "SELECT LAST_INSERT_ID()";
                int idUser = Convert.ToInt32(command.ExecuteScalar());

                command2.Parameters.Add("@surname", MySqlDbType.VarChar).Value = userSurnameField.Text;
                command2.Parameters.Add("@name", MySqlDbType.VarChar).Value = userNameField.Text;
                if (userPatroField.Text != "Введите отчество")
                    command2.Parameters.Add("@patronymic", MySqlDbType.VarChar).Value = userPatroField.Text;
                else
                    command2.Parameters.Add("@patronymic", MySqlDbType.VarChar).Value = "";
                command2.Parameters.Add("@phone_number", MySqlDbType.VarChar).Value = phoneNumberField.Text;
                command2.Parameters.AddWithValue("@date_birth", IsDateValid(dateBirthPicker.Text));
                command2.Parameters.AddWithValue("@id_user", idUser);

                if (command2.ExecuteNonQuery() == 1)
                    MessageBox.Show("Аккаунт клиента был создан");
                else
                    MessageBox.Show("Аккаунт клиента НЕ был создан");
            }
            else
                MessageBox.Show("Аккаунт клиента НЕ был создан");

            db.closeConnection();
        }

        private DateTime IsDateValid(string dateText)
        {
            if (dateText.Length != 10)
                return DateTime.MinValue;

            string[] dateComponents = dateText.Split('.');
            if (dateComponents.Length != 3)
                return DateTime.MinValue;

            int day, month, year;
            if (!int.TryParse(dateComponents[0], out day) ||
                !int.TryParse(dateComponents[1], out month) ||
                !int.TryParse(dateComponents[2], out year))
            {
                return DateTime.MinValue;
            }

            if (day < 1 || day > 31 || month < 1 || month > 12 || year < 1900 || year > DateTime.Now.Year)
                return DateTime.MinValue;

            try
            {
                DateTime date = new DateTime(year, month, day);
                if (date > DateTime.Today)
                    return DateTime.MinValue;
                return date.Date;
            }
            catch
            {
                return DateTime.MinValue;
            }
        }

    }
}
