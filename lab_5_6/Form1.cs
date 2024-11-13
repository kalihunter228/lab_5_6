using System;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;

namespace lab_5_6
{

    public partial class Form1 : Form
    {

        // Строка подключения к базе данных SQLite
        private string connectionString = "Data Source=C:\\Users\\samSepi0l\\Desktop\\bd;Version=3;";

        public Form1()
        {
            InitializeComponent();
        }

        // Метод для подключения к базе данных и отображения данных в DataGridView
        private void ConnectToDatabase()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Подключение к базе данных прошло успешно!");

                    string query = "SELECT * FROM Disciplines";
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);
                    DataTable studentsTable = new DataTable();
                    adapter.Fill(studentsTable);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка подключения: {ex.Message}");
                }


            }
        }
        // Обработчик события загрузки формы
        private void Form1_Load(object sender, EventArgs e)
        {
            ConnectToDatabase();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e) //ФАЙЛ
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e) //ТАБЛИЦЫ
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e) //СПРАВОЧНИКИ
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e) //ОТЧЕТЫ
        {

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e) //ОКНО
        {

        }

        private void квалификацияToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void каскадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void горизонтальноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void вертикальноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        
        private void OpenTableForm(string tableName)
        {
            // Проверка, если окно с такой таблицей уже открыто
            bool isOpen = MdiChildren.Any(child => child.Text == tableName);

            if (!isOpen)
            {
                Table tableForm = new Table(tableName, connectionString);
                tableForm.MdiParent = this;
                tableForm.Show();
            }
        }

        private void OpenDoubleTableForm(string tableName)
        {
            // Проверка, если окно с такой таблицей уже открыто
            bool isOpen = MdiChildren.Any(child => child.Text == tableName);

            if (!isOpen)
            {
                DoubleTableForm tableForm = new DoubleTableForm(tableName, connectionString);
                tableForm.MdiParent = this;
                tableForm.Show();
            }
        }
        private void студентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDoubleTableForm("Студенты");
        }
        private void преподавателиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenTableForm("Преподаватели");
        }

        private void группыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenTableForm("Группы");
        }

        private void дисциплиныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenTableForm("Дисциплины");
        }

        private void оценкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenTableForm("Оценки");
        }
    }
}
