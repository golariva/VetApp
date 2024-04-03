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
    public partial class AddPetForm : Form
    {
        public AddPetForm()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.Sizable;

            this.FormClosing += AddPetForm_FormClosing;

            petNicknameField.Text = "Какая кличка у Вашего питомца?";
            petNicknameField.ForeColor = Color.Gray;

            petKindField.Text = "Какой вид животного (кот, собака и т.д.)?";
            petKindField.ForeColor = Color.Gray;

            petBreedField.Text = "Какая у питомца порода?";
            petBreedField.ForeColor = Color.Gray;
        }

        private void AddPetForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void backLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            MyPetsForm myPetsForm = new MyPetsForm();
            myPetsForm.Show();
        }

        private void petNicknameField_Enter(object sender, EventArgs e)
        {
            if (petNicknameField.Text == "Какая кличка у Вашего питомца?")
            {
                petNicknameField.Text = "";
                petNicknameField.ForeColor = Color.Black;
            }
        }

        private void petNicknameField_Leave(object sender, EventArgs e)
        {
            if (petNicknameField.Text == "")
            {
                petNicknameField.Text = "Какая кличка у Вашего питомца?";
                petNicknameField.ForeColor = Color.Gray;
            }
        }

        private void petKindField_Enter(object sender, EventArgs e)
        {
            if (petKindField.Text == "Какой вид животного (кот, собака и т.д.)?")
            {
                petKindField.Text = "";
                petKindField.ForeColor = Color.Black;
            }
        }

        private void petKindField_Leave(object sender, EventArgs e)
        {
            if (petKindField.Text == "")
            {
                petKindField.Text = "Какой вид животного (кот, собака и т.д.)?";
                petKindField.ForeColor = Color.Gray;
            }
        }

        private void petBreedField_Enter(object sender, EventArgs e)
        {
            if (petBreedField.Text == "Какая у питомца порода?")
            {
                petBreedField.Text = "";
                petBreedField.ForeColor = Color.Black;
            }
        }

        private void petBreedField_Leave(object sender, EventArgs e)
        {
            if (petBreedField.Text == "")
            {
                petBreedField.Text = "Какая у питомца порода?";
                petBreedField.ForeColor = Color.Gray;
            }
        }

        private void sexComboBox_Enter(object sender, EventArgs e)
        {
            if (sexComboBox.Text == "Выберите пол питомца")
            {
                sexComboBox.Text = "";
                sexComboBox.ForeColor = Color.Black;
            }
        }

        private void sexComboBox_Leave(object sender, EventArgs e)
        {
            if (sexComboBox.Text == "")
            {
                sexComboBox.Text = "Выберите пол питомца";
                sexComboBox.ForeColor = Color.Gray;
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

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (petNicknameField.Text == "Какая кличка у Вашего питомца?" || petKindField.Text == "Какой вид животного (кот, собака и т.д.)?" || petBreedField.Text == "Какая у питомца порода?" || sexComboBox.Text == "Выберите пол питомца")
            {
                MessageBox.Show("Не все данные были заполнены \n Питомец не был зарегистрирован");
                return;
            }
            if (IsDateValid(dateBirthPicker.Text) == DateTime.MinValue)
            {
                MessageBox.Show("Укажите верную дату рождения питомца");
                return;
            }
            if (sexComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Укажите пол питомца");
                return;
            }
            if (isPetExists())
            {
                return;
            }

            DB db = new DB();
            string id_client = MainForm.id;
            MySqlCommand command = new MySqlCommand("INSERT INTO `pets`(`id_client`, `nickname`, `animal_kind`, `sex`, `breed`, `date_birth`) VALUES (@id_client, @nickname, @animal_kind, @sex, @breed, @date_birth)", db.getConnection());

            command.Parameters.AddWithValue("@id_client", id_client);
            command.Parameters.Add("@nickname", MySqlDbType.VarChar).Value = petNicknameField.Text;
            command.Parameters.Add("@animal_kind", MySqlDbType.VarChar).Value = petKindField.Text;
            command.Parameters.AddWithValue("@sex", sexComboBox.Text);
            command.Parameters.Add("@breed", MySqlDbType.VarChar).Value = petBreedField.Text;
            command.Parameters.AddWithValue("@date_birth", IsDateValid(dateBirthPicker.Text));

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Питомец был зарегистрирован");
            else
                MessageBox.Show("Питомец НЕ был зарегистрирован");

            db.closeConnection();

            this.Hide();
            MyPetsForm mainForm = new MyPetsForm();
            mainForm.Show();
        }

        public Boolean isPetExists()
        {
            DB db = new DB();

            db.openConnection();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM pets WHERE nickname = @nickname AND animal_kind = @animal_kind AND sex = @sex AND date_birth = @date_birth AND breed = @breed AND id_client = @id_client", db.getConnection());
            command.Parameters.Add("@nickname", MySqlDbType.VarChar).Value = petNicknameField.Text;
            command.Parameters.Add("@animal_kind", MySqlDbType.VarChar).Value = petKindField.Text;
            command.Parameters.AddWithValue("@sex", sexComboBox.Text);
            command.Parameters.Add("@breed", MySqlDbType.VarChar).Value = petBreedField.Text;
            command.Parameters.AddWithValue("@date_birth", IsDateValid(dateBirthPicker.Text));
            command.Parameters.AddWithValue("@id_client", MainForm.id);

            adapter.SelectCommand = command;
            adapter.Fill(table);

            db.closeConnection();

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Такой питомец уже существует");
                return true;
            }
            else
                return false;
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
