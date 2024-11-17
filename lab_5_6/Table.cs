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
            if (isFormOpen)
                return;

            if (dataGridView1.SelectedRows.Count > 0)
            {
                isFormOpen = true;
                try
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    DataRow dataRow = ((DataRowView)selectedRow.DataBoundItem).Row;

                    AddForm add = new AddForm(nameTable, dataRow, sc);
                    add.FormClosed += (s, args) => isFormOpen = false;
                    add.Show();
                }
                catch (Exception ex)
                {
                    isFormOpen = false;
                    MessageBox.Show("Ошибка при открытии формы: " + ex.Message);
                    throw;
                }
            }
            else
            {
                MessageBox.Show("Выделите строку для изменения.");
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Close();
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
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выделите строку для удаления.");
                return;
            }

            var result = MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Подтверждение удаления",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return;
            }

            try
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                DataRow dataRow = ((DataRowView)selectedRow.DataBoundItem).Row;
                int id;

                switch (nameTable)
                {
                    case "Студенты":
                        id = Convert.ToInt32(dataRow["ID Студента"]);
                        DeleteStudent(id);
                        break;
                    case "Группы":
                        id = Convert.ToInt32(dataRow["ID Группы"]);
                        DeleteGroup(id);
                        break;
                    case "Дисциплины":
                        id = Convert.ToInt32(dataRow["ID Дисциплины"]);
                        DeleteDiscipline(id);
                        break;
                    case "Оценки":
                        id = Convert.ToInt32(dataRow["ID Оценки"]);
                        DeleteGrade(id);
                        break;
                    case "Преподаватели":
                        id = Convert.ToInt32(dataRow["ID Преподавателя"]);
                        DeleteTeacher(id);
                        break;
                    default:
                        MessageBox.Show("Неизвестная таблица.");
                        return;
                }

                dataRow.Delete();
                RefreshData();
                dataGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении записи: {ex.Message}", "Ошибка");
            }
        }

        private void RefreshData()
        {
            try
            {
                dt.Clear();
                using (a = new SQLiteDataAdapter(query, sc))
                {
                    a.Fill(dt);
                }
                dataGridView1.DataSource = dt;


                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.ClearSelection();
                }
                else
                {
                    MessageBox.Show("Нет данных для отображения.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении данных: {ex.Message}", "Ошибка");
            }
        }

        private void DeleteStudent(int studentId)
        {
            using (SQLiteTransaction transaction = sc.BeginTransaction())
            {
                try
                {
                    string deleteGradesQuery = "DELETE FROM Grades WHERE student_id = @studentId";
                    using (SQLiteCommand cmd = new SQLiteCommand(deleteGradesQuery, sc))
                    {
                        cmd.Parameters.AddWithValue("@studentId", studentId);
                        cmd.ExecuteNonQuery();
                    }

                    string deleteStudentQuery = "DELETE FROM Students WHERE student_id = @studentId";
                    using (SQLiteCommand cmd = new SQLiteCommand(deleteStudentQuery, sc))
                    {
                        cmd.Parameters.AddWithValue("@studentId", studentId);
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Студент и его оценки успешно удалены", "Успех");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка");
                }
            }
        }

        private void DeleteTeacher(int teacherId)
        {
            using (SQLiteTransaction transaction = sc.BeginTransaction())
            {
                try
                {
                    string deleteTeacherDisciplineQuery = "DELETE FROM TeacherDiscipline WHERE teacher_id = @teacherId";
                    using (SQLiteCommand cmd = new SQLiteCommand(deleteTeacherDisciplineQuery, sc))
                    {
                        cmd.Parameters.AddWithValue("@teacherId", teacherId);
                        cmd.ExecuteNonQuery();
                    }

                    string deleteTeacherQuery = "DELETE FROM Teachers WHERE teacher_id = @teacherId";
                    using (SQLiteCommand cmd = new SQLiteCommand(deleteTeacherQuery, sc))
                    {
                        cmd.Parameters.AddWithValue("@teacherId", teacherId);
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Преподаватель успешно удален", "Успех");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка");
                    throw;
                }
            }
        }

        private void DeleteDiscipline(int disciplineId)
        {
            using (SQLiteTransaction transaction = sc.BeginTransaction())
            {
                try
                {
                    string deleteGradesQuery = "DELETE FROM Grades WHERE discipline_id = @disciplineId";
                    using (SQLiteCommand cmd = new SQLiteCommand(deleteGradesQuery, sc))
                    {
                        cmd.Parameters.AddWithValue("@disciplineId", disciplineId);
                        cmd.ExecuteNonQuery();
                    }

                    string deleteTeacherDisciplineQuery = "DELETE FROM TeacherDiscipline WHERE discipline_id = @disciplineId";
                    using (SQLiteCommand cmd = new SQLiteCommand(deleteTeacherDisciplineQuery, sc))
                    {
                        cmd.Parameters.AddWithValue("@disciplineId", disciplineId);
                        cmd.ExecuteNonQuery();
                    }

                    string deleteDisciplineQuery = "DELETE FROM Disciplines WHERE discipline_id = @disciplineId";
                    using (SQLiteCommand cmd = new SQLiteCommand(deleteDisciplineQuery, sc))
                    {
                        cmd.Parameters.AddWithValue("@disciplineId", disciplineId);
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Дисциплина успешно удалена", "Успех");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка");
                }
            }
        }

        private void DeleteGroup(int groupId)
        {
            string checkStudentsQuery = "SELECT COUNT(*) FROM Students WHERE group_id = @groupId";
            using (SQLiteCommand cmd = new SQLiteCommand(checkStudentsQuery, sc))
            {
                cmd.Parameters.AddWithValue("@groupId", groupId);
                int studentCount = Convert.ToInt32(cmd.ExecuteScalar());

                if (studentCount > 0)
                {
                    MessageBox.Show("Невозможно удалить группу, так как в ней есть студенты", "Предупреждение");
                    return;
                }
            }

            using (SQLiteTransaction transaction = sc.BeginTransaction())
            {
                try
                {
                    string deleteGroupQuery = "DELETE FROM Groups WHERE group_id = @groupId";
                    using (SQLiteCommand cmd = new SQLiteCommand(deleteGroupQuery, sc))
                    {
                        cmd.Parameters.AddWithValue("@groupId", groupId);
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Группа успешно удалена", "Успех");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка");
                }
            }
        }

        private void DeleteGrade(int gradeId)
        {
            using (SQLiteTransaction transaction = sc.BeginTransaction())
            {
                try
                {
                    string deleteGradeQuery = "DELETE FROM Grades WHERE grade_id = @gradeId";
                    using (SQLiteCommand cmd = new SQLiteCommand(deleteGradeQuery, sc))
                    {
                        cmd.Parameters.AddWithValue("@gradeId", gradeId);
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Оценка успешно удалена", "Успех");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка");
                }
            }
        }

        private void toolStripTextBox1_KeyPress(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(this.sc.ConnectionString))
            {
                if (toolStripTextBox1.Text != "")
                {
                    conn.Open();
                    string field = "";
                    string query = "";

                    switch (this.nameTable)
                    {
                        case "Студенты":
                            {
                                field = "ФИО";
                                query = "SELECT " +
                                        "Students.student_id AS 'ID Студента', " +
                                        "Students.full_name AS 'ФИО', " +
                                        "Students.phone AS 'Телефон', " +
                                        "Students.birth_date AS 'Дата рождения', " +
                                        "Students.student_book_number AS 'Номер студенческого билета', " +
                                        "Students.gender AS 'Пол', " +
                                        "Groups.name AS 'Группа' " +
                                        "FROM Students " +
                                        "LEFT JOIN Groups ON Students.group_id = Groups.group_id " +
                                        $"WHERE Students.full_name glob '*{toolStripTextBox1.Text}*'";
                                break;
                            }
                        case "Преподаватели":
                            {
                                field = "ФИО";
                                query = "SELECT " +
                                        "Teachers.teacher_id AS 'ID Преподавателя', " +
                                        "Teachers.full_name AS 'ФИО', " +
                                        "Teachers.phone AS 'Телефон', " +
                                        "Teachers.birth_date AS 'Дата рождения', " +
                                        "Position.position AS 'Должность', " +
                                        "Teachers.gender AS 'Пол' " +
                                        "FROM Teachers " +
                                        "LEFT JOIN Position ON Teachers.position_id = Position.position_id " +
                                        $"WHERE Teachers.full_name glob '*{toolStripTextBox1.Text}*'";
                                break;
                            }
                        case "Группы":
                            {
                                field = "Название группы";
                                query = "SELECT " +
                                        "Groups.group_id AS 'ID Группы', " +
                                        "Groups.name AS 'Название группы', " +
                                        "Direction.direction AS 'Направление', " +
                                        "Qualification.qualification AS 'Квалификация', " +
                                        "Groups.admission_year AS 'Год поступления' " +
                                        "FROM Groups " +
                                        "LEFT JOIN Direction ON Groups.direction_id = Direction.direction_id " +
                                        "LEFT JOIN Qualification ON Groups.qualification_id = Qualification.qualification_id " +
                                        $"WHERE Groups.name glob '*{toolStripTextBox1.Text}*'";
                                break;
                            }
                        case "Дисциплины":
                            {
                                field = "Название дисциплины";
                                query = "SELECT " +
                                        "Disciplines.discipline_id AS 'ID Дисциплины', " +
                                        "Disciplines.discipline_name AS 'Название дисциплины', " +
                                        "Disciplines.discipline_description AS 'Описание', " +
                                        "Teachers.full_name AS 'Преподаватель', " +
                                        "Disciplines.hours_count AS 'Количество часов' " +
                                        "FROM Disciplines " +
                                        "LEFT JOIN Teachers ON Disciplines.teacher_id = Teachers.teacher_id " +
                                        $"WHERE Disciplines.discipline_name glob '*{toolStripTextBox1.Text}*'";
                                break;
                            }
                        case "Оценки":
                            {
                                field = "Студент";
                                query = "SELECT " +
                                        "Grades.grade_id AS 'ID Оценки', " +
                                        "Students.full_name AS 'Студент', " +
                                        "Disciplines.discipline_name AS 'Дисциплина', " +
                                        "Grades.grade AS 'Оценка' " +
                                        "FROM Grades " +
                                        "LEFT JOIN Students ON Grades.student_id = Students.student_id " +
                                        "LEFT JOIN Disciplines ON Grades.discipline_id = Disciplines.discipline_id " +
                                        $"WHERE Students.full_name glob '*{toolStripTextBox1.Text}*'";
                                break;
                            }
                    }

                    this.dt.Clear();
                    a = new SQLiteDataAdapter(query, conn);
                    a.Fill(dt);
                    dataGridView1.DataSource = this.dt;

                    conn.Close();
                }
                else
                {
                    a = new SQLiteDataAdapter(this.query, conn);
                    this.dt.Clear();
                    a.Fill(dt);
                    dataGridView1.DataSource = this.dt;

                    conn.Close();
                }
            }
        }
    }
}
