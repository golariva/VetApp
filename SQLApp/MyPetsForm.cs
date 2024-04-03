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
    public partial class MyPetsForm : Form
    {
        public MyPetsForm()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.Sizable;

            this.FormClosing += MyPetsForm_FormClosing;

            DB db = new DB();
            string id_client = MainForm.id;
            MySqlCommand command = new MySqlCommand("SELECT pets.id_pet AS Индекс, pets.nickname AS Кличка, pets.animal_kind AS Вид, pets.sex AS Пол, pets.date_birth AS Дата_рождения, pets.breed AS Порода FROM pets WHERE pets.id_client = @id_client ORDER BY nickname", db.getConnection());
            command.Parameters.AddWithValue("@id_client", id_client);

            db.openConnection();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);

            petsDataGridView.DataSource = table;

            petsDataGridView.Columns["Индекс"].Visible = false;

            db.closeConnection();
        }

        private void MyPetsForm_FormClosing(object sender, FormClosingEventArgs e)
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

        public static decimal petId;

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
            this.Hide();
            AddPetForm addPetForm = new AddPetForm();
            addPetForm.Show();
        }

        private void gradientButton2_Click(object sender, EventArgs e)
        {
            if (petsDataGridView.SelectedRows.Count > 0)
            {
                int selectedIndex = petsDataGridView.SelectedRows[0].Index;
                DataGridViewRow selectedRow = petsDataGridView.Rows[selectedIndex];

                petId = Convert.ToInt32(selectedRow.Cells["Индекс"].Value);
                this.Hide();
                ChangePetForm changePetForm = new ChangePetForm();
                changePetForm.Show();
            }
        }

        private void gradientButton3_Click(object sender, EventArgs e)
        {
            if (petsDataGridView.SelectedRows.Count > 0)
            {
                int selectedIndex = petsDataGridView.SelectedRows[0].Index;

                decimal petId = Convert.ToDecimal(petsDataGridView.Rows[selectedIndex].Cells["Индекс"].Value);

                DB db = new DB();

                MySqlCommand command = new MySqlCommand("DELETE FROM pets WHERE id_pet = @id_pet", db.getConnection());
                command.Parameters.AddWithValue("@id_pet", petId);

                try
                {
                    db.openConnection();

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Данные о питомце успешно удалены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        string id_client = MainForm.id;
                        MySqlCommand newCommand = new MySqlCommand("SELECT pets.id_pet AS Индекс, pets.nickname AS Кличка, pets.animal_kind AS Вид, pets.sex AS Пол, pets.date_birth AS Дата_рождения, pets.breed AS Порода FROM pets WHERE pets.id_client = @id_client ORDER BY nickname", db.getConnection());
                        newCommand.Parameters.AddWithValue("@id_client", id_client);

                        db.openConnection();

                        MySqlDataAdapter adapter = new MySqlDataAdapter();
                        DataTable table = new DataTable();
                        adapter.SelectCommand = newCommand;
                        adapter.Fill(table);

                        petsDataGridView.DataSource = table;

                        petsDataGridView.Columns["Индекс"].Visible = false;

                        db.closeConnection();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось удалить данные о питомце", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка удаления данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    db.closeConnection();
                }
            }
            else
            {
                MessageBox.Show("Выберите питомца для удаления данных о нем", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
