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
using OfficeOpenXml;
using System.IO;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace SQLApp
{
    public partial class VetForm : Form
    {
        public static string id = "";

        public VetForm()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.Sizable;

            this.FormClosing += VetForm_FormClosing;

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM veterinarians WHERE id_user = @id_user", db.getConnection());
            command.Parameters.AddWithValue("@id_user", id);

            db.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                string surname = reader["surname"].ToString();
                string name = reader["name"].ToString();
                string patronymic = reader["patronymic"].ToString();
                id = reader["id_veterinarian"].ToString();

                userInfoLabel.Text = LoginForm.accessName + "\n" + surname + " " + name + " " + patronymic;
            }

            db.closeConnection();

            db.openConnection();

            MySqlCommand command2 = new MySqlCommand("SELECT applications.id_appointment AS Индекс, CONCAT(clients.surname, ' ', clients.name, ' ', clients.patronymic) AS Клиент, schedule.date AS Дата, schedule.time AS Время, pets.nickname AS Питомец, applications.status AS Статус, services.name AS Услуга, services.price AS Цена FROM applications JOIN services ON applications.id_service = services.id_service JOIN pets ON applications.id_pet = pets.id_pet JOIN clients ON applications.id_client = clients.id_client JOIN schedule ON applications.id_date = schedule.id_date WHERE applications.id_veterinarian = @id_veterinarian ORDER BY date DESC, time DESC", db.getConnection());
            command2.Parameters.AddWithValue("@id_veterinarian", id);

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = command2;
            adapter.Fill(table);

            applicationsDataGridView.DataSource = table;

            applicationsDataGridView.Columns["Индекс"].Visible = false;

            db.closeConnection();
        }

        private void VetForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }


        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        public static decimal applicationId;
        public static bool isPlanned = false;

        private void gradientButton1_Click(object sender, EventArgs e)
        {
            VetProfileForm vetProfileForm = new VetProfileForm();
            vetProfileForm.Show();
            this.Hide();
        }

        private void gradientButton2_Click(object sender, EventArgs e)
        {
            isPlanned = false;

            if (applicationsDataGridView.SelectedRows.Count > 0)
            {
                int selectedIndex = applicationsDataGridView.SelectedRows[0].Index;
                DataGridViewRow selectedRow = applicationsDataGridView.Rows[selectedIndex];

                applicationId = Convert.ToInt32(selectedRow.Cells["Индекс"].Value);
                if (selectedRow.Cells["Статус"].Value.ToString() == "Прием запланирован")
                    isPlanned = true;
                this.Hide();
                ChangeStatusForm changeStatusForm = new ChangeStatusForm();
                changeStatusForm.Show();
            }
        }

        private void gradientButton3_Click(object sender, EventArgs e)
        {
            SetDateForm setDateForm = new SetDateForm();
            setDateForm.ShowDialog();
        }

        private void gradientButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            VetSchedule vetSchedule = new VetSchedule();
            vetSchedule.Show();
        }
    }
}
