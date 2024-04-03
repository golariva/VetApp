using MySqlConnector;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace SQLApp
{
    public partial class SetDateForm : Form
    {
        public SetDateForm()
        {
            InitializeComponent();

            dataGridView.Hide();
        }

        private void gradientButton1_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            db.openConnection();

            MySqlCommand command2 = new MySqlCommand("SELECT applications.id_appointment AS Индекс, CONCAT(clients.surname, ' ', clients.name, ' ', clients.patronymic) AS Клиент, schedule.date AS Дата, schedule.time AS Время, pets.nickname AS Питомец, applications.status AS Статус, services.name AS Услуга, services.price AS Цена FROM applications JOIN services ON applications.id_service = services.id_service JOIN pets ON applications.id_pet = pets.id_pet JOIN clients ON applications.id_client = clients.id_client JOIN schedule ON applications.id_date = schedule.id_date WHERE applications.id_veterinarian = @id_veterinarian AND schedule.date = @date ORDER BY date DESC, time DESC", db.getConnection());
            command2.Parameters.AddWithValue("@id_veterinarian", VetForm.id);
            command2.Parameters.AddWithValue("@date", dateTimePicker.Value.Date);

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = command2;
            adapter.Fill(table);

            db.closeConnection();

            dataGridView.DataSource = table;

            if (dataGridView.Rows.Count > 1)
            {
                try
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = ".XLSX (*.xlsx)|*.xlsx";
                    saveFileDialog.FilterIndex = 1;
                    saveFileDialog.RestoreDirectory = true;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                        ExcelPackage excelPackage = new ExcelPackage();
                        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Отчет");

                        worksheet.Cells["A1"].Value = "Отчет о приемах";
                        worksheet.Cells["A1"].Style.Font.Bold = true;
                        worksheet.Cells["A1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        worksheet.Cells["A2"].Value = "Дата: " + dateTimePicker.Value.Date.ToString("dd.MM.yyyy");
                        worksheet.Cells["A2"].Style.Font.Bold = true;

                        int columnIndex = 1;
                        for (int i = 0; i < dataGridView.Columns.Count; i++)
                        {
                            if (dataGridView.Columns[i].Name != "Индекс" && dataGridView.Columns[i].Name != "Дата")
                            {
                                worksheet.Cells[4, columnIndex].Value = dataGridView.Columns[i].HeaderText;
                                worksheet.Cells[4, columnIndex].Style.Font.Bold = true;
                                worksheet.Cells[4, columnIndex].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                                worksheet.Column(columnIndex).AutoFit();
                                columnIndex++;
                            }
                        }

                        int rowIndex = 5;
                        DateTime selectedDate = dateTimePicker.Value.Date;
                        for (int i = 0; i < dataGridView.Rows.Count; i++)
                        {
                            DateTime cellDate = Convert.ToDateTime(dataGridView.Rows[i].Cells["Дата"].Value);

                            if (cellDate.Date == selectedDate)
                            {
                                columnIndex = 1;
                                for (int j = 0; j < dataGridView.Columns.Count; j++)
                                {
                                    if (dataGridView.Columns[j].Name != "Индекс" && dataGridView.Columns[j].Name != "Дата")
                                    {
                                        worksheet.Cells[rowIndex, columnIndex].Value = dataGridView.Rows[i].Cells[j].Value?.ToString();
                                        columnIndex++;
                                    }
                                }

                                rowIndex++;
                            }
                        }

                        decimal totalServicesPrice = 0;
                        for (int i = 0; i < dataGridView.Rows.Count; i++)
                        {
                            decimal servicePrice;
                            if (decimal.TryParse(dataGridView.Rows[i].Cells["Цена"].Value?.ToString(), out servicePrice) && dataGridView.Rows[i].Cells["Статус"].Value.ToString() != "Прием отменен")
                            {
                                totalServicesPrice += servicePrice;
                            }
                        }

                        worksheet.Cells[rowIndex + 4, 1].Value = "Итого за услуги:";
                        worksheet.Cells[rowIndex + 4, 2].Value = totalServicesPrice;
                        worksheet.Cells[rowIndex + 4, 2].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;

                        worksheet.Cells[rowIndex + 2, 1].Value = "Врач:";
                        worksheet.Cells[rowIndex + 3, 1].Value = "Специализация:";
                        worksheet.Cells[rowIndex + 5, 1].Value = "Подпись:";

                        worksheet.Cells[rowIndex + 2, 1].Style.Font.Bold = true;
                        worksheet.Cells[rowIndex + 3, 1].Style.Font.Bold = true;
                        worksheet.Cells[rowIndex + 4, 1].Style.Font.Bold = true;
                        worksheet.Cells[rowIndex + 5, 1].Style.Font.Bold = true;
                        worksheet.Cells[rowIndex + 2, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                        worksheet.Cells[rowIndex + 3, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                        worksheet.Cells[rowIndex + 4, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                        worksheet.Cells[rowIndex + 5, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;

                        using (var range = worksheet.Cells[4, 1, rowIndex - 1, columnIndex - 1])
                        {
                            var border = range.Style.Border;
                            border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                            border.Bottom.Color.SetColor(Color.Black);
                            border.Top.Color.SetColor(Color.Black);
                            border.Left.Color.SetColor(Color.Black);
                            border.Right.Color.SetColor(Color.Black);
                        }

                        string id_vet = VetForm.id;

                        MySqlCommand command = new MySqlCommand("SELECT * FROM veterinarians WHERE id_veterinarian = @id_vet", db.getConnection());
                        command.Parameters.AddWithValue("@id_vet", id_vet);

                        db.openConnection();

                        MySqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            worksheet.Cells[rowIndex + 2, 2].Value = reader["surname"].ToString() + " " + reader["name"].ToString() + " " + reader["patronymic"].ToString();
                            worksheet.Cells[rowIndex + 3, 2].Value = reader["specialization"].ToString();
                        }

                        worksheet.Cells[rowIndex + 2, 2].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                        worksheet.Cells[rowIndex + 3, 2].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;

                        db.closeConnection();

                        worksheet.Cells.AutoFitColumns();

                        FileInfo excelFile = new FileInfo(saveFileDialog.FileName);
                        excelPackage.SaveAs(excelFile);
                        MessageBox.Show("Отчет успешно сохранен");
                        this.Hide();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при экспорте данных в Excel: " + ex.Message);
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Ваш отчет пуст");
                this.Hide();
            }
        }
    }
}
