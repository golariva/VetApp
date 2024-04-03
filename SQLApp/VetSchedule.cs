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
    public partial class VetSchedule : Form
    {
        public static int id_date;
        public VetSchedule()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.Sizable;

            this.FormClosing += VetSchedule_FormClosing;

            DB db = new DB();
            string id_vet = VetForm.id;
            MySqlCommand command = new MySqlCommand("SELECT id_date AS Индекс, date AS Дата, time AS Время, available AS Бронь FROM schedule WHERE id_veterinarian = @id_vet ORDER BY date DESC, time ASC", db.getConnection());
            command.Parameters.AddWithValue("@id_vet", id_vet);

            db.openConnection();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);

            ScheduleDataGridView.DataSource = table;

            ScheduleDataGridView.Columns["Индекс"].Visible = false;

            db.closeConnection();
        }

        private void VetSchedule_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void RegisterLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            VetForm vetForm = new VetForm();
            vetForm.Show();
        }

        private void gradientButton1_Click(object sender, EventArgs e)
        {
            AddScheduleForm addScheduleFrom = new AddScheduleForm(ScheduleDataGridView);
            addScheduleFrom.ShowDialog();
        }

        private void gradientButton2_Click(object sender, EventArgs e)
        {
            if (ScheduleDataGridView.SelectedRows.Count > 0)
            {
                int selectedIndex = ScheduleDataGridView.SelectedRows[0].Index;
                DataGridViewRow selectedRow = ScheduleDataGridView.Rows[selectedIndex];

                id_date = Convert.ToInt32(selectedRow.Cells["Индекс"].Value);
                int index_available = Convert.ToInt32(selectedRow.Cells["Бронь"].Value);
                if (index_available == 0)
                {
                    ChangeScheduleForm changeScheduleForm = new ChangeScheduleForm(ScheduleDataGridView);
                    changeScheduleForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Выберите свободное окно для изменения (без галочки)");
                }
            }
        }

        private void gradientButton3_Click(object sender, EventArgs e)
        {
            if (ScheduleDataGridView.SelectedRows.Count > 0)
            {
                int selectedIndex = ScheduleDataGridView.SelectedRows[0].Index;
                DataGridViewRow selectedRow = ScheduleDataGridView.Rows[selectedIndex];

                decimal deleteId = Convert.ToInt32(selectedRow.Cells["Индекс"].Value);
                int index_available = Convert.ToInt32(selectedRow.Cells["Бронь"].Value);

                if (index_available == 0)
                {
                    DB db = new DB();

                    MySqlCommand command = new MySqlCommand("DELETE FROM schedule WHERE id_date = @id_date", db.getConnection());

                    command.Parameters.AddWithValue("@id_date", deleteId);

                    db.openConnection();

                    command.ExecuteNonQuery();

                    db.closeConnection();

                    string id_vet = VetForm.id;
                    MySqlCommand command2 = new MySqlCommand("SELECT id_date AS Индекс, date AS Дата, time AS Время, available AS Бронь FROM schedule WHERE id_veterinarian = @id_vet ORDER BY date DESC, time ASC", db.getConnection());
                    command2.Parameters.AddWithValue("@id_vet", id_vet);

                    db.openConnection();

                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    DataTable table = new DataTable();
                    adapter.SelectCommand = command2;
                    adapter.Fill(table);

                    ScheduleDataGridView.DataSource = table;

                    db.closeConnection();

                    MessageBox.Show("Данные о свободном окне были успешно удалены");
                }
                else
                {
                    MessageBox.Show("Вы не можете удалять уже занятое время для записи");
                }
            }
        }
    }
}
