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
    public partial class MainForm : Form
    {
        public static string id;
        public static string userEmail;
        public MainForm()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.Sizable;

            this.FormClosing += MainForm_FormClosing;

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM clients WHERE id_user = @id_user", db.getConnection());
            command.Parameters.AddWithValue("@id_user", id);

            db.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                string surname = reader["surname"].ToString();
                string name = reader["name"].ToString();
                string patronymic = reader["patronymic"].ToString();
                id = reader["id_client"].ToString();

                userInfoLabel.Text = LoginForm.accessName + "\n" + surname + " " + name + " " + patronymic;
            }

            db.closeConnection();

            db.openConnection();

            MySqlCommand command2 = new MySqlCommand("SELECT applications.id_appointment AS Индекс, CONCAT(veterinarians.surname, ' ', veterinarians.name, ' ', veterinarians.patronymic) AS Врач, schedule.date AS Дата, schedule.time AS Время, pets.nickname AS Питомец, applications.status AS Статус, services.name AS Услуга, services.price AS Цена FROM applications JOIN services ON applications.id_service = services.id_service JOIN pets ON applications.id_pet = pets.id_pet JOIN veterinarians ON applications.id_veterinarian = veterinarians.id_veterinarian JOIN schedule ON applications.id_date = schedule.id_date WHERE applications.id_client = @id_client ORDER BY date DESC, time ASC", db.getConnection());
            command2.Parameters.AddWithValue("@id_client", id);

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = command2;
            adapter.Fill(table);

            applicationsDataGridView.DataSource = table;

            applicationsDataGridView.Columns["Индекс"].Visible = false;

            db.closeConnection();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void gradientButton1_Click(object sender, EventArgs e)
        {
            UserProfileForm userProfileForm = new UserProfileForm();
            userProfileForm.Show();
            this.Hide();
        }

        private void gradientButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MyPetsForm myPetsForm = new MyPetsForm();
            myPetsForm.Show();
        }

        private void gradientButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ApplicationForm applicationForm = new ApplicationForm();
            applicationForm.Show();
        }

        private void gradientButton4_Click(object sender, EventArgs e)
        {
            if (applicationsDataGridView.SelectedRows.Count > 0)
            {
                int selectedIndex = applicationsDataGridView.SelectedRows[0].Index;
                DataGridViewRow selectedRow = applicationsDataGridView.Rows[selectedIndex];

                decimal deleteId = Convert.ToInt32(selectedRow.Cells["Индекс"].Value);

                DB db = new DB();

                MySqlCommand command = new MySqlCommand("SELECT * FROM applications WHERE id_appointment = @id_appointment", db.getConnection());
                command.Parameters.AddWithValue("@id_appointment", deleteId);

                bool isCancelled = false;
                bool isCompleted = false;
                string indexDate = "0";

                db.openConnection();

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    indexDate = reader["id_date"].ToString();
                    string status = reader["status"].ToString();
                    if (status == "Прием отменен")
                        isCancelled = true;
                    if (status == "Прием завершен")
                        isCompleted = true;
                }

                db.closeConnection();

                if (!isCancelled && !isCompleted)
                {
                    MySqlCommand command3 = new MySqlCommand("UPDATE applications SET status = 'Прием отменен' WHERE id_appointment = @id_appointment", db.getConnection());
                    command3.Parameters.AddWithValue("@id_appointment", deleteId);

                    db.openConnection();

                    if (command3.ExecuteNonQuery() == 1)
                        MessageBox.Show("Прием был успешно отменен");
                    else
                        MessageBox.Show("Прием НЕ был отменен");

                    db.closeConnection();

                    MySqlCommand command4 = new MySqlCommand("UPDATE schedule SET available = 0 WHERE id_date = @id_date", db.getConnection());
                    command4.Parameters.AddWithValue("@id_date", indexDate);

                    db.openConnection();

                    command4.ExecuteNonQuery();

                    db.closeConnection();

                    MySqlCommand command2 = new MySqlCommand("SELECT applications.id_appointment AS Индекс, CONCAT(veterinarians.surname, ' ', veterinarians.name, ' ', veterinarians.patronymic) AS Врач, schedule.date AS Дата, schedule.time AS Время, pets.nickname AS Питомец, applications.status AS Статус, services.name AS Услуга, services.price AS Цена FROM applications JOIN services ON applications.id_service = services.id_service JOIN pets ON applications.id_pet = pets.id_pet JOIN veterinarians ON applications.id_veterinarian = veterinarians.id_veterinarian JOIN schedule ON applications.id_date = schedule.id_date WHERE applications.id_client = @id_client ORDER BY date DESC, time ASC", db.getConnection());
                    command2.Parameters.AddWithValue("@id_client", id);

                    db.openConnection();

                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    DataTable table = new DataTable();
                    adapter.SelectCommand = command2;
                    adapter.Fill(table);

                    applicationsDataGridView.DataSource = table;

                    applicationsDataGridView.Columns["Индекс"].Visible = false;

                    db.closeConnection();
                }
                else
                {
                    if (isCancelled)
                        MessageBox.Show("Прием уже был отменен");
                    else
                        MessageBox.Show("Прием уже был проведен");
                }
            }
        }
    }
}
