using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;

namespace SQLApp
{
    public partial class ChangeStatusForm : Form
    {
        public ChangeStatusForm()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.Sizable;

            this.FormClosing += ChangeStatusForm_FormClosing;

            decimal id = VetForm.applicationId;
            string client = "0";
            string pet = "0";
            string service = "0";

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM applications WHERE id_appointment = @id_appointment", db.getConnection());
            command.Parameters.AddWithValue("@id_appointment", id);

            db.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                client = reader["id_client"].ToString();
                pet = reader["id_pet"].ToString();
                service = reader["id_service"].ToString();
                string status = reader["status"].ToString();
                if (VetForm.isPlanned)
                {
                    statusComboBox.Text = status;
                    statusComboBox.Items.Add("Прием завершен");
                    statusComboBox.Items.Add("Прием отменен");
                }
                else
                {
                    statusComboBox.Hide();
                    gradientButton1.Hide();
                    statusLabel.Text = "Статус приема: " + status;
                }
            }

            db.closeConnection();

            MySqlCommand commandClient = new MySqlCommand("SELECT surname, name, patronymic FROM clients WHERE id_client = @id_client", db.getConnection());
            commandClient.Parameters.AddWithValue("@id_client", client);

            db.openConnection();

            MySqlDataReader readerClient = commandClient.ExecuteReader();
            if (readerClient.Read())
            {
                string firstName = readerClient["surname"].ToString();
                string lastName = readerClient["name"].ToString();
                string patronymic = readerClient["patronymic"].ToString();

                clientLabel.Text = "Клиент: " + firstName + " " + lastName + " " + patronymic;
            }

            db.closeConnection();

            MySqlCommand commandPet = new MySqlCommand("SELECT nickname, animal_kind, sex, date_birth, breed FROM pets WHERE id_pet = @pet", db.getConnection());
            commandPet.Parameters.AddWithValue("@pet", pet);

            db.openConnection();

            MySqlDataReader readerPet = commandPet.ExecuteReader();
            if (readerPet.Read())
            {
                string nickname = readerPet["nickname"].ToString();
                string animalKind = readerPet["animal_kind"].ToString();
                string sex = readerPet["sex"].ToString();
                DateTime dateBirth = Convert.ToDateTime(readerPet["date_birth"]);
                string breed = readerPet["breed"].ToString();

                nicknameLabel.Text = "Кличка: " + nickname;
                animalKindLabel.Text = "Вид: " + animalKind;
                sexLabel.Text = "Пол: " + sex;
                birthDateLabel.Text = "Дата рождения: " + dateBirth.ToString("dd.MM.yyyy");
                breedLabel.Text = "Порода: " + breed;
            }

            db.closeConnection();

            MySqlCommand commandService = new MySqlCommand("SELECT name, price FROM services WHERE id_service = @service", db.getConnection());
            commandService.Parameters.AddWithValue("@service", service);

            db.openConnection();

            MySqlDataReader readerService = commandService.ExecuteReader();
            if (readerService.Read())
            {
                string name = readerService["name"].ToString();
                string price = readerService["price"].ToString();

                serviceLabel.Text = "Услуга: " + name;
                priceLabel.Text = "Цена: " + price + " р.";
            }

            db.closeConnection();

            MySqlCommand command2 = new MySqlCommand("SELECT * FROM schedule JOIN applications ON applications.id_date = schedule.id_date WHERE applications.id_appointment = @id_appointment", db.getConnection());
            command2.Parameters.AddWithValue("@id_appointment", id);

            db.openConnection();

            MySqlDataReader reader2 = command2.ExecuteReader();

            if (reader2.Read())
            {
                DateTime date = Convert.ToDateTime(reader2["date"]);
                string time = reader2["time"].ToString();
                appointmentLabel.Text = "Дата приема: " + date.ToString("dd.MM.yyyy");
                timeLabel.Text = "Время приема: " + time;
            }

            db.closeConnection();
        }

        private void ChangeStatusForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                System.Windows.Forms.Application.Exit();
            }
        }


        private void closeButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        System.Drawing.Point lastPoint;

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
            lastPoint = new System.Drawing.Point(e.X, e.Y);
        }

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
            lastPoint = new System.Drawing.Point(e.X, e.Y);
        }

        private void backLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            VetForm vetForm = new VetForm();
            vetForm.Show();
        }

        private void gradientButton1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            decimal id_application = VetForm.applicationId;
            MySqlCommand command = new MySqlCommand("UPDATE `applications` SET status = @status WHERE id_appointment = @id_appointment", db.getConnection());

            command.Parameters.AddWithValue("@status", statusComboBox.Text);
            command.Parameters.AddWithValue("@id_appointment", id_application);

            MySqlCommand commandDate = new MySqlCommand("SELECT * FROM applications WHERE id_appointment = @id_appointment", db.getConnection());

            commandDate.Parameters.AddWithValue("@id_appointment", id_application);

            string indexDate = "0";

            db.openConnection();

            MySqlDataReader reader = commandDate.ExecuteReader();

            if (reader.Read())
            {
                indexDate = reader["id_date"].ToString();
            }

            db.closeConnection();

            MySqlCommand commandAvailable = new MySqlCommand("UPDATE schedule SET available = 0 WHERE id_date = @id_date", db.getConnection());

            commandAvailable.Parameters.AddWithValue("@id_date", indexDate);

            db.openConnection();

            if (statusComboBox.SelectedIndex != -1)
            {
                command.ExecuteNonQuery();
                commandAvailable.ExecuteNonQuery();
                MessageBox.Show("Статус был успешно изменен");
                gradientButton1.Hide();
                statusLabel.Text = "Статус приема: " + statusComboBox.Text;
                statusComboBox.Hide();
            }
            else
                MessageBox.Show("Статус НЕ был изменен");

            db.closeConnection();
        }
    }
}
