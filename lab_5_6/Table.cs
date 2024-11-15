using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_5_6
{
    public partial class Table : Form
    {
        private string title;
        private string connectionString;

        private SQLiteConnection sc = new SQLiteConnection();
        private SQLiteDataAdapter a;
        private SQLiteCommand command = new SQLiteCommand();
        private DataTable dt = new DataTable();

        private string nameTable;
        private string query;

        public Table(string nameF, string ConnectionString)
        {
            InitializeComponent();
            this.Text = nameF;
            this.Name = nameF;
            this.sc.ConnectionString = ConnectionString;
            sc.Open();

            switch (this.Name)
            {
                case "Студенты":
                    {
                        query = "SELECT " +
                                "Students.student_id AS 'ID Студента', " +
                                "Students.full_name AS 'ФИО', " +
                                "Students.phone AS 'Телефон', " +
                                "Students.birth_date AS 'Дата рождения', " +
                                "Students.student_book_number AS 'Номер студенческого билета', " +
                                "Students.gender AS 'Пол', " +
                                "Groups.name AS 'Группа' " +
                                "FROM Students " +
                                "LEFT JOIN Groups ON Students.group_id = Groups.group_id;";
                        this.nameTable = "Студенты";
                        break;
                    }
                case "Преподаватели":
                    {
                        query = "SELECT " +
                                "Teachers.teacher_id AS 'ID Преподавателя', " +
                                "Teachers.full_name AS 'ФИО', " +
                                "Teachers.phone AS 'Телефон', " +
                                "Teachers.birth_date AS 'Дата рождения', " +
                                "Position.position AS 'Должность', " +
                                "Teachers.gender AS 'Пол' " +
                                "FROM Teachers " +
                                "LEFT JOIN Position ON Teachers.position_id = Position.position_id;";
                        this.nameTable = "Преподаватели";
                        break;
                    }
                case "Группы":
                    {
                        query = "SELECT " +
                                "Groups.group_id AS 'ID Группы', " +
                                "Groups.name AS 'Название группы', " +
                                "Direction.direction AS 'Направление', " +
                                "Qualification.qualification AS 'Квалификация', " +
                                "Groups.admission_year AS 'Год поступления' " +
                                "FROM Groups " +
                                "LEFT JOIN Direction ON Groups.direction_id = Direction.direction_id " +
                                "LEFT JOIN Qualification ON Groups.qualification_id = Qualification.qualification_id;";
                        this.nameTable = "Группы";
                        break;
                    }
                case "Дисциплины":
                    {
                        query = "SELECT " +
                                "Disciplines.discipline_id AS 'ID Дисциплины', " +
                                "Disciplines.discipline_name AS 'Название дисциплины', " +
                                "Disciplines.discipline_description AS 'Описание', " +
                                "Teachers.full_name AS 'Преподаватель', " +
                                "Disciplines.hours_count AS 'Количество часов' " +
                                "FROM Disciplines " +
                                "LEFT JOIN Teachers ON Disciplines.teacher_id = Teachers.teacher_id;";
                        this.nameTable = "Дисциплины";
                        break;
                    }
                case "Оценки":
                    {
                        query = "SELECT " +
                                "Grades.grade_id AS 'ID Оценки', " +
                                "Students.full_name AS 'Студент', " +
                                "Disciplines.discipline_name AS 'Дисциплина', " +
                                "Grades.grade AS 'Оценка' " +
                                "FROM Grades " +
                                "LEFT JOIN Students ON Grades.student_id = Students.student_id " +
                                "LEFT JOIN Disciplines ON Grades.discipline_id = Disciplines.discipline_id;";
                        this.nameTable = "Оценки";
                        break;
                    }
            }

            a = new SQLiteDataAdapter(query, sc);
            a.Fill(dt);
            dataGridView1.DataSource = dt;
            HideFields();

            // Подключение обработчиков событий
            toolStripButton1.Click += new EventHandler(toolStripButton1_Click);
            toolStripButton2.Click += new EventHandler(toolStripButton2_Click);
            toolStripButton3.Click += new EventHandler(toolStripButton3_Click);
            toolStripButton4.Click += new EventHandler(toolStripButton4_Click);
        }

        private void HideFields()
        {
            switch (this.Name)
            {
                case "Студенты":
                    {
                        dataGridView1.Columns["ID Студента"].Visible = false;
                        break;
                    }
                case "Преподаватели":
                    {
                        dataGridView1.Columns["ID Преподавателя"].Visible = false;
                        break;
                    }
                case "Группы":
                    {
                        dataGridView1.Columns["ID Группы"].Visible = false;
                        break;
                    }
                case "Дисциплины":
                    {
                        dataGridView1.Columns["ID Дисциплины"].Visible = false;
                        break;
                    }
                case "Оценки":
                    {
                        dataGridView1.Columns["ID Оценки"].Visible = false;
                        break;
                    }
            }
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Table_Load(object sender, EventArgs e)
        {

        }
        private bool isFormOpen = false;
        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            if (isFormOpen)
                return;

            isFormOpen = true;

            try
            {
                AddForm add = new AddForm(nameTable, null, sc);
                add.FormClosed += (s, args) => isFormOpen = false;
                add.Show();
            }
            catch
            {
                isFormOpen = false;
                throw;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }
    }
}
