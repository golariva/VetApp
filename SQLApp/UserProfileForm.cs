using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLApp
{
    public partial class UserProfileForm : Form
    {
        string id_user;
        string surname;
        string name;
        string patronymic;
        DateTime date_birth;
        string phone_number;
        string userEmail;
        public UserProfileForm()
        {
            InitializeComponent();

            this.FormClosing += UserProfileForm_FormClosing;

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM clients WHERE id_client = @id_client", db.getConnection());
            command.Parameters.AddWithValue("@id_client", MainForm.id);

            db.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                surname = reader["surname"].ToString();
                name = reader["name"].ToString();
                patronymic = reader["patronymic"].ToString();
                date_birth = (DateTime)reader["date_birth"];
                phone_number = reader["phone_number"].ToString();
                id_user = reader["id_user"].ToString();

                userSurnameField.Text = surname;
                userNameField.Text = name;
                userPatroField.Text = patronymic;
                dateBirthPicker.Text = date_birth.ToString("dd.MM.yyyy");
                phoneNumberField.Text = phone_number;
            }

            db.closeConnection();

            MySqlCommand command2 = new MySqlCommand("SELECT * FROM accounts WHERE id_user = @id_user", db.getConnection());
            command2.Parameters.AddWithValue("@id_user", id_user);

            db.openConnection();

            MySqlDataReader reader2 = command2.ExecuteReader();

            if (reader2.Read())
            {
                userEmail = reader2["email"].ToString();
            }

            db.closeConnection();

            emailField.Text = userEmail;

            passField.Text = "Введите новый пароль";
            passField.ForeColor = Color.Gray;
            passField.UseSystemPasswordChar = false;

            passFieldRepeat.Text = "Повторите пароль";
            passFieldRepeat.ForeColor = Color.Gray;
            passFieldRepeat.UseSystemPasswordChar = false;
        }

        private void UserProfileForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
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

            if (table.Rows.Count > 0 && emailField.Text != userEmail)
            {
                MessageBox.Show("Пользователь с такой почтой уже существует");
                return true;
            }
            else
                return false;
        }

        private void RegisterLabel_Click(object sender, EventArgs e)
        {
            MainForm.id = id_user;
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
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

        private void passField_Enter(object sender, EventArgs e)
        {
            if (passField.Text == "Введите новый пароль")
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
                passField.Text = "Введите новый пароль";
                passField.ForeColor = Color.Gray;
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
            if (userNameField.Text == "Введите имя" || userSurnameField.Text == "Введите фамилию" || emailField.Text == "Введите наименование электронной почты" || !phoneNumberField.MaskCompleted || passField.Text != "Введите новый пароль" && passFieldRepeat.Text == "Повторите пароль")
            {
                MessageBox.Show("Не все данные были заполнены \n Аккаунт не был изменен");
                return;
            }
            if (passField.Text != passFieldRepeat.Text && passField.Text != "Введите новый пароль" && passFieldRepeat.Text != "Повторите пароль")
            {
                MessageBox.Show("Повторите пароль корректно");
                return;
            }

            if (userNameField.Text == name && userSurnameField.Text == surname && userPatroField.Text == patronymic && emailField.Text == userEmail && phoneNumberField.Text == phone_number && passField.Text == "Введите новый пароль" && dateBirthPicker.Text == date_birth.ToString("dd.MM.yyyy"))
            {
                MessageBox.Show("Аккаунт не был изменен");
                return;
            }

            if (passField.Text.Length < 8 && passField.Text != "Введите новый пароль")
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

            MySqlCommand command = new MySqlCommand("UPDATE accounts SET email = @email WHERE id_user = @id_user", db.getConnection());

            if (passField.Text != "Введите новый пароль")
                command = new MySqlCommand("UPDATE accounts SET email = @email, password = SHA2(@password, 256) WHERE id_user = @id_user", db.getConnection());
            MySqlCommand command2 = new MySqlCommand("UPDATE clients SET surname = @surname, name = @name, patronymic = @patronymic, phone_number = @phone_number, date_birth = @date_birth WHERE id_client = @id_client", db.getConnection());

            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = emailField.Text;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = passField.Text;
            command.Parameters.AddWithValue("@id_user", id_user);

            if (command.ExecuteNonQuery() == 1)
            {
                command2.Parameters.Add("@surname", MySqlDbType.VarChar).Value = userSurnameField.Text;
                command2.Parameters.Add("@name", MySqlDbType.VarChar).Value = userNameField.Text;
                if (userPatroField.Text != "Введите отчество")
                    command2.Parameters.Add("@patronymic", MySqlDbType.VarChar).Value = userPatroField.Text;
                else
                    command2.Parameters.Add("@patronymic", MySqlDbType.VarChar).Value = "";
                command2.Parameters.Add("@phone_number", MySqlDbType.VarChar).Value = phoneNumberField.Text;
                command2.Parameters.AddWithValue("@date_birth", IsDateValid(dateBirthPicker.Text));
                command2.Parameters.AddWithValue("@id_client", MainForm.id);

                if (command2.ExecuteNonQuery() == 1)
                    MessageBox.Show("Аккаунт клиента был изменен");
                else
                    MessageBox.Show("Аккаунт клиента НЕ был изменен");
            }
            else
                MessageBox.Show("Аккаунт клиента НЕ был изменен");

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
