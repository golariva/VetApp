using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLApp
{
    public partial class VetProfileForm : Form
    {
        string userEmail;
        string id_user;
        string surname;
        string name;
        string patronymic;
        string specialization;
        public VetProfileForm()
        {
            InitializeComponent();

            this.FormClosing += VetProfileForm_FormClosing;

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM veterinarians WHERE id_veterinarian = @id_veterinarian", db.getConnection());
            command.Parameters.AddWithValue("@id_veterinarian", VetForm.id);

            db.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                surname = reader["surname"].ToString();
                name = reader["name"].ToString();
                patronymic = reader["patronymic"].ToString();
                specialization = reader["specialization"].ToString();
                id_user = reader["id_user"].ToString();

                userSurnameField.Text = surname;
                userNameField.Text = name;
                userPatroField.Text = patronymic;
                SpecializationField.Text = specialization;
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

        private void VetProfileForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void RegisterLabel_Click(object sender, EventArgs e)
        {
            VetForm.id = id_user;
            this.Hide();
            VetForm vetForm = new VetForm();
            vetForm.Show();
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

        private void emailField_Enter(object sender, EventArgs e)
        {
            if (emailField.Text == "Введите почту")
            {
                emailField.Text = "";
                emailField.ForeColor = Color.Black;
            }
        }

        private void emailField_Leave(object sender, EventArgs e)
        {
            if (emailField.Text == "")
            {
                emailField.Text = "Введите почту";
                emailField.ForeColor = Color.Gray;
            }
        }

        private void SpecializationField_Enter(object sender, EventArgs e)
        {
            if (SpecializationField.Text == "Введите название специализации")
            {
                SpecializationField.Text = "";
                SpecializationField.ForeColor = Color.Black;
            }
        }

        private void SpecializationField_Leave(object sender, EventArgs e)
        {
            if (SpecializationField.Text == "")
            {
                SpecializationField.Text = "Введите название специализации";
                SpecializationField.ForeColor = Color.Gray;
            }
        }

        private void gradientButton1_Click(object sender, EventArgs e)
        {
            if (userNameField.Text == "Введите имя" || userSurnameField.Text == "Введите фамилию" || emailField.Text == "Введите почту" || SpecializationField.Text == "Введите название специализации" || passField.Text != "Введите новый пароль" && passFieldRepeat.Text == "Повторите пароль")
            {
                MessageBox.Show("Не все данные были заполнены \n Аккаунт не был изменен");
                return;
            }
            if (passField.Text != passFieldRepeat.Text && passField.Text != "Введите новый пароль" && passFieldRepeat.Text != "Повторите пароль")
            {
                MessageBox.Show("Повторите пароль корректно");
                return;
            }

            if (userNameField.Text == name && userSurnameField.Text == surname && userPatroField.Text == patronymic && emailField.Text == userEmail && SpecializationField.Text == specialization && passField.Text == "Введите новый пароль")
            {
                MessageBox.Show("Аккаунт не был изменен");
                return;
            }

            if (passField.Text.Length < 8 && passField.Text != "Введите новый пароль")
            {
                MessageBox.Show("Длина пароля должна быть не менее 8 символов");
                return;
            }

            if (isUserExists())
                return;

            DB db = new DB();

            db.openConnection();

            MySqlCommand command = new MySqlCommand("UPDATE accounts SET email = @email WHERE id_user = @id_user", db.getConnection());

            if (passField.Text != "Введите новый пароль")
                command = new MySqlCommand("UPDATE accounts SET email = @email, password = SHA2(@password, 256) WHERE id_user = @id_user", db.getConnection());
            MySqlCommand command2 = new MySqlCommand("UPDATE veterinarians SET surname = @surname, name = @name, patronymic = @patronymic, specialization = @specialization WHERE id_veterinarian = @id_veterinarian", db.getConnection());

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
                command2.Parameters.Add("@specialization", MySqlDbType.VarChar).Value = SpecializationField.Text;
                command2.Parameters.AddWithValue("@id_veterinarian", VetForm.id);

                if (command2.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Аккаунт сотрудника был изменен");
                }
                else
                    MessageBox.Show("Аккаунт сотрудника НЕ был изменен");
            }
            else
                MessageBox.Show("Аккаунт сотрудника НЕ был изменен");

            db.closeConnection();
        }
    }
}
