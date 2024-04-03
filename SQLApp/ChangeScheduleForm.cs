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
    public partial class ChangeScheduleForm : Form
    {
        int id_date = VetSchedule.id_date;
        string id_vet = VetForm.id;
        private DataGridView scheduleDataGridView;

        public ChangeScheduleForm(DataGridView dataGridView)
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.Sizable;

            this.FormClosing += ChangeScheduleForm_FormClosing;

            for (int i = 9; i < 22; i++)
            {
                if (i == 9)
                    timeComboBox.Items.Add($"0{i}:00");
                else
                    timeComboBox.Items.Add($"{i}:00");
            }

            int id_date = VetSchedule.id_date;

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM schedule WHERE id_date = @id_date", db.getConnection());
            command.Parameters.AddWithValue("@id_date", id_date);

            db.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                string date = reader["date"].ToString();
                dateTimePicker.Text = date;
                string time = reader["time"].ToString();
                timeComboBox.Text = time;
            }

            db.closeConnection();
            this.scheduleDataGridView = dataGridView;
        }

        private void ChangeScheduleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Hide();
            }
        }

        Point lastPoint;

        private void topPanel_MouseDown(object sender, MouseEventArgs e)
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

        private void mainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void mainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void gradientButton1_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker.Value.Date;
            string selectedTime = timeComboBox.Text;

            DB dB = new DB();

            if (dateTimePicker.Value < DateTime.Now)
            {
                MessageBox.Show("Выберите действительные дату");
            }
            else if (timeComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите время");
            }
            else
            {
                dB.openConnection();

                MySqlCommand checkCommand = new MySqlCommand("SELECT COUNT(*) FROM schedule WHERE id_veterinarian = @id_vet AND date = @date AND time = @time", dB.getConnection());
                checkCommand.Parameters.AddWithValue("@id_vet", id_vet);
                checkCommand.Parameters.AddWithValue("@date", selectedDate.Date);
                checkCommand.Parameters.AddWithValue("@time", selectedTime.ToString());

                int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                if (count > 0)
                {
                    MessageBox.Show("Вы не можете изменить время приема на уже такое же существующее в таблице");
                }
                else
                {
                    MySqlCommand command = new MySqlCommand("UPDATE schedule SET id_veterinarian = @id_vet, date = @date, time = @time, available = 0 WHERE id_date = @id_date", dB.getConnection());
                    command.Parameters.AddWithValue("@id_vet", id_vet);
                    command.Parameters.AddWithValue("@id_date", id_date);
                    command.Parameters.AddWithValue("@date", selectedDate);
                    command.Parameters.AddWithValue("@time", selectedTime);

                    dB.openConnection();

                    command.ExecuteNonQuery();

                    dB.closeConnection();

                    MySqlCommand command2 = new MySqlCommand("SELECT id_date AS Индекс, date AS Дата, time AS Время, available AS Бронь FROM schedule WHERE id_veterinarian = @id_vet ORDER BY date DESC, time DESC", dB.getConnection());
                    command2.Parameters.AddWithValue("@id_vet", id_vet);

                    dB.openConnection();

                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    DataTable table = new DataTable();
                    adapter.SelectCommand = command2;
                    adapter.Fill(table);

                    scheduleDataGridView.DataSource = table;

                    dB.closeConnection();

                    this.Hide();
                }
            }
        }
    }
}
