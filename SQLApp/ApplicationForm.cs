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
    public partial class ApplicationForm : Form
    {
        string selectedVeterinarianId;
        string selectedPetId;
        string selectedServiceId;
        int selectedTimeId;
        string id_client = MainForm.id;
        public ApplicationForm()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.Sizable;

            this.FormClosing += ApplicationForm_FormClosing;

            petComboBox.Text = "Выберите питомца";
            petComboBox.ForeColor = Color.Gray;

            serviceComboBox.Text = "Выберите услугу";
            serviceComboBox.ForeColor = Color.Gray;

            veterinarianComboBox.Text = "Выберите специалиста";
            veterinarianComboBox.ForeColor = Color.Gray;

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM pets WHERE id_client = @id_client", db.getConnection());
            command.Parameters.AddWithValue("@id_client", id_client);

            db.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string pets = reader["nickname"].ToString();
                petComboBox.Items.Add(pets);
            }

            db.closeConnection();

            MySqlCommand command2 = new MySqlCommand("SELECT * FROM services", db.getConnection());

            db.openConnection();

            MySqlDataReader reader2 = command2.ExecuteReader();

            while (reader2.Read())
            {
                string services = reader2["name"].ToString();
                string prices = reader2["price"].ToString();
                serviceComboBox.Items.Add(services + " - " + prices + "р.");
            }

            db.closeConnection();

            MySqlCommand command3 = new MySqlCommand("SELECT * FROM veterinarians", db.getConnection());

            db.openConnection();

            MySqlDataReader reader3 = command3.ExecuteReader();

            while (reader3.Read())
            {
                string surname = reader3["surname"].ToString();
                string name = reader3["name"].ToString();
                string patronymic = reader3["patronymic"].ToString();
                string specialization = reader3["specialization"].ToString();
                veterinarianComboBox.Items.Add(surname + " " + name + " " + patronymic + " (" + specialization + ")");
            }

            db.closeConnection();

            db.openConnection();

            MySqlCommand command4 = new MySqlCommand("SELECT schedule.id_date AS Индекс, CONCAT(veterinarians.surname, ' ', veterinarians.name, ' ', veterinarians.patronymic) AS Врач, schedule.date AS Дата, schedule.time AS Время FROM schedule JOIN veterinarians ON schedule.id_veterinarian = veterinarians.id_veterinarian WHERE CONCAT(schedule.date, ' ', schedule.time) >= NOW() AND available = 0 ORDER BY date DESC, time ASC", db.getConnection());

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = command4;
            adapter.Fill(table);

            AvailableTimeDataGridView.DataSource = table;

            AvailableTimeDataGridView.Columns["Индекс"].Visible = false;

            db.closeConnection();
        }

        private void ApplicationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void RegisterLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
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

        private void petComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DB db = new DB();

            MySqlCommand command = new MySqlCommand("SELECT * FROM pets WHERE id_client = @id_client", db.getConnection());
            command.Parameters.AddWithValue("@id_client", id_client);

            db.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string pets = reader["nickname"].ToString();
                if (pets == petComboBox.Text.ToString())
                    selectedPetId = reader["id_pet"].ToString();
            }

            db.closeConnection();
        }

        private void serviceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DB db = new DB();

            MySqlCommand command = new MySqlCommand("SELECT * FROM services", db.getConnection());

            db.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string services = reader["name"].ToString();
                string prices = reader["price"].ToString();
                string line = services + " - " + prices + "р.";
                if (line == serviceComboBox.Text.ToString())
                    selectedServiceId = reader["id_service"].ToString();
            }

            db.closeConnection();
        }

        private void gradientButton1_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            if (AvailableTimeDataGridView.SelectedRows.Count > 0)
            {
                int selectedIndex = AvailableTimeDataGridView.SelectedRows[0].Index;
                DataGridViewRow selectedRow = AvailableTimeDataGridView.Rows[selectedIndex];
                selectedTimeId = Convert.ToInt32(selectedRow.Cells["Индекс"].Value);

                MySqlCommand commandVet = new MySqlCommand("SELECT * FROM veterinarians", db.getConnection());

                db.openConnection();

                MySqlDataReader reader = commandVet.ExecuteReader();

                while (reader.Read())
                {
                    string surname = reader["surname"].ToString();
                    string name = reader["name"].ToString();
                    string patronymic = reader["patronymic"].ToString();
                    string specialization = reader["specialization"].ToString();
                    string fullName = surname + " " + name + " " + patronymic;
                    if (fullName == selectedRow.Cells["Врач"].Value.ToString())
                        selectedVeterinarianId = reader["id_veterinarian"].ToString();
                }

                db.closeConnection();
            }
            else
            {
                MessageBox.Show("Выберите доступное время для записи");
                return;
            }

            if (petComboBox.SelectedIndex == -1 || serviceComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Не все данные были предоставлены для формирования записи на прием");
                return;
            }

            MySqlCommand command = new MySqlCommand("INSERT INTO applications (id_veterinarian, id_client, id_pet, id_service, status, id_date) VALUES (@id_veterinarian, @id_client, @id_pet, @id_service, 'Прием запланирован', @id_date)", db.getConnection());
            command.Parameters.AddWithValue("@id_veterinarian", selectedVeterinarianId);
            command.Parameters.AddWithValue("@id_client", id_client);
            command.Parameters.AddWithValue("@id_pet", selectedPetId);
            command.Parameters.AddWithValue("@id_service", selectedServiceId);
            command.Parameters.AddWithValue("@id_date", selectedTimeId);

            db.openConnection();

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Новая заявка успешно добавлена");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении заявки: " + ex.Message);
            }

            db.closeConnection();

            MySqlCommand command2 = new MySqlCommand("UPDATE schedule SET available = 1 WHERE id_date = @id_date", db.getConnection());
            command2.Parameters.AddWithValue("@id_date", selectedTimeId);

            db.openConnection();

            command2.ExecuteNonQuery();

            db.closeConnection();

            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void veterinarianComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DB db = new DB();

            MySqlCommand command = new MySqlCommand("SELECT * FROM veterinarians", db.getConnection());

            db.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string surname = reader["surname"].ToString();
                string name = reader["name"].ToString();
                string patronymic = reader["patronymic"].ToString();
                string specialization = reader["specialization"].ToString();
                string fullName = surname + " " + name + " " + patronymic + " (" + specialization + ")";
                if (fullName == veterinarianComboBox.Text.ToString())
                {
                    selectedVeterinarianId = reader["id_veterinarian"].ToString();
                }
            }

            db.closeConnection();

            db.openConnection();

            MySqlCommand command2 = new MySqlCommand(@"SELECT schedule.id_date AS Индекс, 
                                             CONCAT(veterinarians.surname, ' ', veterinarians.name, ' ', veterinarians.patronymic) AS Врач, 
                                             schedule.date AS Дата, 
                                             schedule.time AS Время 
                                      FROM schedule 
                                      JOIN veterinarians ON schedule.id_veterinarian = veterinarians.id_veterinarian 
                                      WHERE schedule.id_veterinarian = @id_veterinarian 
                                            AND CONCAT(schedule.date, ' ', schedule.time) >= NOW() 
                                            AND available = 0 
                                      ORDER BY date DESC, time ASC", db.getConnection());
            command2.Parameters.AddWithValue("@id_veterinarian", selectedVeterinarianId);

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = command2;
            adapter.Fill(table);

            AvailableTimeDataGridView.DataSource = table;

            AvailableTimeDataGridView.Columns["Индекс"].Visible = false;

            db.closeConnection();
        }
    }
}
