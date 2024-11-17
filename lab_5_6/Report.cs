using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Aspose.Cells;
using Aspose.Words;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace lab_5_6
{
    public partial class Report : Form
    {
        static string path = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
        private readonly string ConnectionString;
        private SQLiteDataAdapter adapter;
        private DataSet dataSet;
        private System.Data.DataTable dataTable = new System.Data.DataTable();
        private string query;

        public Report(int reportType, string connectionString)
        {
            InitializeComponent();
            ConnectionString = connectionString;
            InitializeComboBox(reportType);
        }

        private void InitializeComboBox(int reportType)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                dataSet = new DataSet();
                string tableName;
                string displayMember;
                string valueMember;

                switch (reportType)
                {
                    case 1:
                        Tag = 1;
                        label1.Text = "Выберите студента";
                        tableName = "Students";
                        query = "SELECT student_id, full_name FROM Students";
                        displayMember = "full_name";
                        valueMember = "student_id";
                        break;
                    case 2:
                        Tag = 2;
                        label1.Text = "Выберите группу";
                        tableName = "Groups";
                        query = "SELECT group_id, name FROM Groups";
                        displayMember = "name";
                        valueMember = "group_id";
                        break;
                    case 3:
                        Tag = 3;
                        label1.Text = "Выберите дисциплину";
                        tableName = "Disciplines";
                        query = "SELECT discipline_id, discipline_name FROM Disciplines";
                        displayMember = "discipline_name";
                        valueMember = "discipline_id";
                        break;
                    default:
                        throw new ArgumentException("Неверный тип отчета");
                }

                dataSet.Tables.Add(new System.Data.DataTable(tableName));
                adapter = new SQLiteDataAdapter(query, connection);
                adapter.Fill(dataSet.Tables[tableName]);

                comboBox1.DisplayMember = displayMember;
                comboBox1.ValueMember = valueMember;
                comboBox1.DataSource = dataSet.Tables[tableName];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string value = comboBox1.SelectedValue?.ToString();
                string text = comboBox1.Text;

                if (string.IsNullOrEmpty(value))
                {
                    MessageBox.Show("Пожалуйста, выберите значение из списка");
                    return;
                }

                Thread reportThread = new Thread(() =>
                {
                    switch ((int)Tag)
                    {
                        case 1:
                            GenerateStudentReport(value, text);
                            break;
                        case 2:
                            GenerateGroupReport(value, text);
                            break;
                        case 3:
                            GenerateDisciplineReport(value, text);
                            break;
                    }
                });
                reportThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateReports(System.Data.DataTable data, string reportType, string text)
        {
            if (data == null || data.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для формирования отчета!");
                return;
            }

            string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Reports");

            try
            {
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                var reportFiles = new[]
                {
                    GenerateExcelReport(data, directoryPath, reportType, text, timestamp),
                    GenerateWordReport(data, directoryPath, reportType, text, timestamp),
                    GeneratePdfReport(data, directoryPath, reportType, text, timestamp)
                };

                MessageBox.Show($"Отчеты сохранены в папке:\n{directoryPath}\n\nСозданные файлы:\n{string.Join("\n", reportFiles)}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании отчетов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateExcelReport(System.Data.DataTable data, string directoryPath, string reportType, string text, string timestamp)
        {
            string fileName = $"Отчет_по_{reportType}_{text}_{timestamp}.xlsx";
            string filePath = Path.Combine(directoryPath, fileName);

            using (var workbook = new Workbook())
            {
                Worksheet worksheet = workbook.Worksheets[0];

                worksheet.Cells[0, 0].PutValue($"Отчет по {reportType}: {text}");
                worksheet.Cells[0, 0].GetStyle().Font.IsBold = true;
                worksheet.Cells[0, 0].GetStyle().Font.Size = 14;

                for (int i = 0; i < data.Columns.Count; i++)
                {
                    var cell = worksheet.Cells[2, i];
                    cell.PutValue(data.Columns[i].ColumnName);
                    var style = cell.GetStyle();
                    style.Font.IsBold = true;
                    style.Font.Size = 12;
                    style.Pattern = BackgroundType.Solid;
                    style.ForegroundColor = System.Drawing.Color.LightGray;
                    cell.SetStyle(style);
                }

                for (int row = 0; row < data.Rows.Count; row++)
                {
                    for (int col = 0; col < data.Columns.Count; col++)
                    {
                        worksheet.Cells[row + 3, col].PutValue(data.Rows[row][col]?.ToString() ?? "");
                    }
                }

                worksheet.AutoFitColumns();
                workbook.Save(filePath);
            }

            return fileName;
        }

        private string GenerateWordReport(System.Data.DataTable data, string directoryPath, string reportType, string text, string timestamp)
        {
            string fileName = $"Отчет_по_{reportType}_{text}_{timestamp}.docx";
            string filePath = Path.Combine(directoryPath, fileName);

            var doc = new Aspose.Words.Document();
            var builder = new Aspose.Words.DocumentBuilder(doc);

            try
            {
                builder.Font.Size = 16;
                builder.Font.Bold = true;
                builder.Writeln($"Отчет по {reportType}: {text}");
                builder.Writeln();

                var table = builder.StartTable();

                builder.Font.Size = 12;
                builder.CellFormat.Shading.BackgroundPatternColor = System.Drawing.Color.LightGray;

                foreach (DataColumn column in data.Columns)
                {
                    builder.InsertCell();
                    builder.Write(column.ColumnName);
                }
                builder.EndRow();

                builder.Font.Bold = false;
                builder.CellFormat.Shading.BackgroundPatternColor = System.Drawing.Color.White;
                builder.Font.Size = 11;

                foreach (DataRow row in data.Rows)
                {
                    foreach (var item in row.ItemArray)
                    {
                        builder.InsertCell();
                        builder.Write(item?.ToString() ?? "");
                    }
                    builder.EndRow();
                }

                builder.EndTable();
                doc.Save(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании Word документа: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            return fileName;
        }

        private string GeneratePdfReport(System.Data.DataTable data, string directoryPath, string reportType, string text, string timestamp)
        {
            string fileName = $"Отчет_по_{reportType}_{text}_{timestamp}.pdf";
            string filePath = Path.Combine(directoryPath, fileName);

            using (var document = new Aspose.Pdf.Document())
            {
                var page = document.Pages.Add();

                var header = new Aspose.Pdf.Text.TextFragment($"Отчет по {reportType}: {text}");
                header.TextState.FontSize = 16;
                header.TextState.FontStyle = Aspose.Pdf.Text.FontStyles.Bold;
                page.Paragraphs.Add(header);

                var table = new Aspose.Pdf.Table
                {
                    Border = new Aspose.Pdf.BorderInfo(Aspose.Pdf.BorderSide.All, 0.5f),
                    DefaultCellBorder = new Aspose.Pdf.BorderInfo(Aspose.Pdf.BorderSide.All, 0.5f)
                };

                var headerRow = table.Rows.Add();
                headerRow.DefaultCellTextState.FontSize = 12;
                headerRow.DefaultCellTextState.FontStyle = Aspose.Pdf.Text.FontStyles.Bold;
                headerRow.BackgroundColor = Aspose.Pdf.Color.LightGray;

                foreach (DataColumn column in data.Columns)
                {
                    headerRow.Cells.Add(column.ColumnName);
                }

                foreach (DataRow dataRow in data.Rows)
                {
                    var row = table.Rows.Add();
                    row.DefaultCellTextState.FontSize = 10;

                    foreach (var item in dataRow.ItemArray)
                    {
                        row.Cells.Add(item?.ToString() ?? "");
                    }
                }

                page.Paragraphs.Add(table);
                document.Save(filePath);
            }

            return fileName;
        }

        private void GenerateStudentReport(string studentId, string studentName)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                query = @"
                    SELECT 
                        g.name AS 'Группа',
                        d.discipline_name AS 'Дисциплина',
                        s.full_name AS 'Студент',
                        gr.grade AS 'Оценка'
                    FROM Students s
                    LEFT JOIN Groups g ON s.group_id = g.group_id
                    LEFT JOIN Grades gr ON s.student_id = gr.student_id
                    LEFT JOIN Disciplines d ON gr.discipline_id = d.discipline_id
                    WHERE s.student_id = @StudentId
                    ORDER BY d.discipline_name";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentId", studentId);
                    adapter = new SQLiteDataAdapter(command);
                    dataTable = new System.Data.DataTable();
                    adapter.Fill(dataTable);
                    GenerateReports(dataTable, "студенту", studentName);
                }
            }
        }

        private void GenerateGroupReport(string groupId, string groupName)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                query = @"
                    SELECT 
                        g.name AS 'Группа',
                        d.discipline_name AS 'Дисциплина',
                        s.full_name AS 'Студент',
                        gr.grade AS 'Оценка'
                    FROM Groups g
                    LEFT JOIN Students s ON g.group_id = s.group_id
                    LEFT JOIN Grades gr ON s.student_id = gr.student_id
                    LEFT JOIN Disciplines d ON gr.discipline_id = d.discipline_id
                    WHERE g.group_id = @GroupId
                    ORDER BY s.full_name, d.discipline_name";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@GroupId", groupId);
                    adapter = new SQLiteDataAdapter(command);
                    dataTable = new System.Data.DataTable();
                    adapter.Fill(dataTable);
                    GenerateReports(dataTable, "группе", groupName);
                }
            }
        }

        private void GenerateDisciplineReport(string disciplineId, string disciplineName)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                query = @"
                    SELECT 
                        d.discipline_name AS 'Дисциплина',
                        s.full_name AS 'Студент',
                        g.name AS 'Группа',
                        gr.grade AS 'Оценка'
                    FROM Disciplines d
                    LEFT JOIN Grades gr ON d.discipline_id = gr.discipline_id
                    LEFT JOIN Students s ON gr.student_id = s.student_id
                    LEFT JOIN Groups g ON s.group_id = g.group_id
                    WHERE d.discipline_id = @DisciplineId
                    ORDER BY g.name, s.full_name";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DisciplineId", disciplineId);
                    adapter = new SQLiteDataAdapter(command);
                    dataTable = new System.Data.DataTable();
                    adapter.Fill(dataTable);
                    GenerateReports(dataTable, "дисциплине", disciplineName);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
