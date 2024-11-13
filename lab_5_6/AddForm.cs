﻿using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace lab_5_6
{
    public partial class AddForm : Form
    {
        private string tableName;
        private DataRow dataRow;
        private SQLiteConnection sc;
        private bool isNewRecord;

        public AddForm(string tableName, DataRow dataRow, SQLiteConnection sc)
        {
            InitializeComponent();
            this.tableName = tableName;
            this.dataRow = dataRow;
            this.sc = sc;

            isNewRecord = dataRow == null;

            LoadForm();
        }

        private void LoadForm()
        {
            // Скрываем все элементы управления
            HideAllControls();

            if (isNewRecord)
            {
                this.Text = "Добавить запись";
            }
            else
            {
                this.Text = "Редактировать запись";
            }

            switch (tableName)
            {
                case "Students":
                    lblFullName.Visible = true;
                    txtFullName.Visible = true;
                    lblPhone.Visible = true;
                    txtPhone.Visible = true;
                    lblBirthDate.Visible = true;
                    dtpBirthDate.Visible = true;
                    lblStudentBookNumber.Visible = true;
                    txtStudentBookNumber.Visible = true;
                    lblGender.Visible = true;
                    cmbGender.Visible = true;
                    lblGroupId.Visible = true;
                    txtGroup.Visible = true;

                    LoadGroups();
                    LoadGenders();

                    if (!isNewRecord)
                    {
                        txtFullName.Text = dataRow["full_name"].ToString();
                        txtPhone.Text = dataRow["phone"].ToString();
                        dtpBirthDate.Value = DateTime.Parse(dataRow["birth_date"].ToString());
                        txtStudentBookNumber.Text = dataRow["student_book_number"].ToString();
                        cmbGender.SelectedItem = dataRow["gender"].ToString();
                        txtGroup.Text = dataRow["group_id"].ToString();
                    }
                    break;

                case "Teachers":
                    lblFullName.Visible = true;
                    txtFullName.Visible = true;
                    lblPhone.Visible = true;
                    txtPhone.Visible = true;
                    lblBirthDate.Visible = true;
                    dtpBirthDate.Visible = true;
                    lblGender.Visible = true;
                    cmbGender.Visible = true;
                    lblPositionId.Visible = true;
                    cmbPositionId.Visible = true;

                    LoadGenders();
                    LoadPositions();

                    if (!isNewRecord)
                    {
                        txtFullName.Text = dataRow["full_name"].ToString();
                        txtPhone.Text = dataRow["phone"].ToString();
                        dtpBirthDate.Value = DateTime.Parse(dataRow["birth_date"].ToString());
                        cmbGender.SelectedItem = dataRow["gender"].ToString();
                        cmbPositionId.SelectedValue = dataRow["position_id"];
                    }
                    break;

                case "Disciplines":
                    lblDisciplineName.Visible = true;
                    txtDisciplineName.Visible = true;
                    lblDisciplineDescription.Visible = true;
                    txtDisciplineDescription.Visible = true;
                    lblTeacherId.Visible = true;
                    cmbTeacherId.Visible = true;
                    lblHoursCount.Visible = true;
                    txtHoursCount.Visible = true;

                    LoadTeachers();

                    if (!isNewRecord)
                    {
                        txtDisciplineName.Text = dataRow["discipline_name"].ToString();
                        txtDisciplineDescription.Text = dataRow["discipline_description"].ToString();
                        cmbTeacherId.SelectedValue = dataRow["teacher_id"];
                        txtHoursCount.Text = dataRow["hours_count"].ToString();
                    }
                    break;

                case "Grades":
                    lblStudentId.Visible = true;
                    cmbStudentId.Visible = true;
                    lblDisciplineId.Visible = true;
                    cmbDisciplineId.Visible = true;
                    lblGrade.Visible = true;
                    txtGrade.Visible = true;

                    LoadStudents();
                    LoadDisciplines();

                    if (!isNewRecord)
                    {
                        cmbStudentId.SelectedValue = dataRow["student_id"];
                        cmbDisciplineId.SelectedValue = dataRow["discipline_id"];
                        txtGrade.Text = dataRow["grade"].ToString();
                    }
                    break;

                case "Groups":
                    lblGroupName.Visible = true;
                    txtGroupName.Visible = true;
                    lblDirectionId.Visible = true;
                    cmbDirectionId.Visible = true;
                    lblQualificationId.Visible = true;
                    cmbQualificationId.Visible = true;
                    lblAdmissionYear.Visible = true;
                    txtAdmissionYear.Visible = true;

                    LoadDirections();
                    LoadQualifications();

                    if (!isNewRecord)
                    {
                        txtGroupName.Text = dataRow["name"].ToString();
                        cmbDirectionId.SelectedValue = dataRow["direction_id"];
                        cmbQualificationId.SelectedValue = dataRow["qualification_id"];
                        txtAdmissionYear.Text = dataRow["admission_year"].ToString();
                    }
                    break;

                case "Direction":
                    lblDirection.Visible = true;
                    txtDirection.Visible = true;

                    if (!isNewRecord)
                    {
                        txtDirection.Text = dataRow["direction"].ToString();
                    }
                    break;

                case "Qualification":
                    lblQualification.Visible = true;
                    txtQualification.Visible = true;

                    if (!isNewRecord)
                    {
                        txtQualification.Text = dataRow["qualification"].ToString();
                    }
                    break;

                case "Position":
                    lblPosition.Visible = true;
                    txtPosition.Visible = true;

                    if (!isNewRecord)
                    {
                        txtPosition.Text = dataRow["position"].ToString();
                    }
                    break;
            }
        }

        private void LoadGroups()
        {
            cmbGroupId.Items.Clear();
            string query = "SELECT group_id, name FROM Groups";
            SQLiteCommand cmd = new SQLiteCommand(query, sc);

            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    cmbGroupId.Items.Add(new
                    {
                        Text = reader["name"].ToString(),
                        Value = reader["group_id"]
                    });
                }
            }

            cmbGroupId.DisplayMember = "Text";
            cmbGroupId.ValueMember = "Value";
        }

        private void LoadGenders()
        {
            cmbGender.Items.Clear();
            cmbGender.Items.Add("мужской");
            cmbGender.Items.Add("женский");
        }

        private void LoadPositions()
        {
            cmbPositionId.Items.Clear();
            string query = "SELECT position_id, position FROM Position";
            SQLiteCommand cmd = new SQLiteCommand(query, sc);

            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    cmbPositionId.Items.Add(new
                    {
                        Text = reader["position"].ToString(),
                        Value = reader["position_id"]
                    });
                }
            }

            cmbPositionId.DisplayMember = "Text";
            cmbPositionId.ValueMember = "Value";
        }

        private void LoadTeachers()
        {
            cmbTeacherId.Items.Clear();
            string query = "SELECT teacher_id, full_name FROM Teachers";
            SQLiteCommand cmd = new SQLiteCommand(query, sc);

            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    cmbTeacherId.Items.Add(new
                    {
                        Text = reader["full_name"].ToString(),
                        Value = reader["teacher_id"]
                    });
                }
            }

            cmbTeacherId.DisplayMember = "Text";
            cmbTeacherId.ValueMember = "Value";
        }

        private void LoadStudents()
        {
            cmbStudentId.Items.Clear();
            string query = "SELECT student_id, full_name FROM Students";
            SQLiteCommand cmd = new SQLiteCommand(query, sc);

            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    cmbStudentId.Items.Add(new
                    {
                        Text = reader["full_name"].ToString(),
                        Value = reader["student_id"]
                    });
                }
            }

            cmbStudentId.DisplayMember = "Text";
            cmbStudentId.ValueMember = "Value";
        }

        private void LoadDisciplines()
        {
            cmbDisciplineId.Items.Clear();
            string query = "SELECT discipline_id, discipline_name FROM Disciplines";
            SQLiteCommand cmd = new SQLiteCommand(query, sc);

            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    cmbDisciplineId.Items.Add(new
                    {
                        Text = reader["discipline_name"].ToString(),
                        Value = reader["discipline_id"]
                    });
                }
            }

            cmbDisciplineId.DisplayMember = "Text";
            cmbDisciplineId.ValueMember = "Value";
        }

        private void LoadDirections()
        {
            cmbDirectionId.Items.Clear();
            string query = "SELECT direction_id, direction FROM Direction";
            SQLiteCommand cmd = new SQLiteCommand(query, sc);

            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    cmbDirectionId.Items.Add(new
                    {
                        Text = reader["direction"].ToString(),
                        Value = reader["direction_id"]
                    });
                }
            }

            cmbDirectionId.DisplayMember = "Text";
            cmbDirectionId.ValueMember = "Value";
        }

        private void LoadQualifications()
        {
            cmbQualificationId.Items.Clear();
            string query = "SELECT qualification_id, qualification FROM Qualification";
            SQLiteCommand cmd = new SQLiteCommand(query, sc);

            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    cmbQualificationId.Items.Add(new
                    {
                        Text = reader["qualification"].ToString(),
                        Value = reader["qualification_id"]
                    });
                }
            }

            cmbQualificationId.DisplayMember = "Text";
            cmbQualificationId.ValueMember = "Value";
        }

        private void HideAllControls()
        {
            // Students
            lblFullName.Visible = false;
            txtFullName.Visible = false;
            lblPhone.Visible = false;
            txtPhone.Visible = false;
            lblBirthDate.Visible = false;
            dtpBirthDate.Visible = false;
            lblStudentBookNumber.Visible = false;
            txtStudentBookNumber.Visible = false;
            lblGender.Visible = false;
            cmbGender.Visible = false;
            lblGroupId.Visible = false;
            txtGroup.Visible = false;

            // Teachers
            lblPositionId.Visible = false;
            cmbPositionId.Visible = false;

            // Disciplines
            lblDisciplineName.Visible = false;
            txtDisciplineName.Visible = false;
            lblDisciplineDescription.Visible = false;
            txtDisciplineDescription.Visible = false;
            lblTeacherId.Visible = false;
            cmbTeacherId.Visible = false;
            lblHoursCount.Visible = false;
            txtHoursCount.Visible = false;

            // Grades
            lblStudentId.Visible = false;
            cmbStudentId.Visible = false;
            lblDisciplineId.Visible = false;
            cmbDisciplineId.Visible = false;
            lblGrade.Visible = false;
            txtGrade.Visible = false;

            // Groups
            lblGroupName.Visible = false;
            txtGroupName.Visible = false;
            lblDirectionId.Visible = false;
            cmbDirectionId.Visible = false;
            lblQualificationId.Visible = false;
            cmbQualificationId.Visible = false;
            lblAdmissionYear.Visible = false;
            txtAdmissionYear.Visible = false;

            // Direction
            lblDirection.Visible = false;
            txtDirection.Visible = false;

            // Qualification
            lblQualification.Visible = false;
            txtQualification.Visible = false;

            // Position
            lblPosition.Visible = false;
            txtPosition.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                MessageBox.Show("Пожалуйста, проверьте правильность ввода данных.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                switch (tableName)
                {
                    case "Students":
                        SaveStudent();
                        break;
                    case "Teachers":
                        SaveTeacher();
                        break;
                    case "Disciplines":
                        SaveDiscipline();
                        break;
                    case "Grades":
                        SaveGrade();
                        break;
                    case "Groups":
                        SaveGroup();
                        break;
                    case "Direction":
                        SaveDirection();
                        break;
                    case "Qualification":
                        SaveQualification();
                        break;
                    case "Position":
                        SavePosition();
                        break;
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении данных: " + ex.Message);
            }
        }

        private bool ValidateInputs()
        {
            // Проверка имени и фамилии на буквы
            if (tableName == "Students" || tableName == "Teachers" || tableName == "Groups" || tableName == "Disciplines")
            {
                if (!IsAllLetters(txtFullName.Text))
                    return false;
            }

            // Проверка номера телефона (10 цифр)
            if (tableName == "Students" || tableName == "Teachers")
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(txtPhone.Text, @"^\d{10}$"))
                    return false;
            }

            // Проверка, что должность выбрана из списка
            if (tableName == "Teachers" && cmbPositionId.SelectedIndex == -1)
            {
                MessageBox.Show("Пожалуйста, выберите должность.");
                return false;
            }

            return true;
        }

        private bool IsAllLetters(string input)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(input, @"^[а-яА-Я ]+$");
        }

        private void SaveStudent()
        {
            string query = isNewRecord
                ? "INSERT INTO Students (full_name, phone, birth_date, student_book_number, gender, group_id) VALUES (@full_name, @phone, @birth_date, @student_book_number, @gender, @group_id)"
                : "UPDATE Students SET full_name = @full_name, phone = @phone, birth_date = @birth_date, student_book_number = @student_book_number, gender = @gender, group_id = @group_id WHERE student_id = @student_id";

            SQLiteCommand cmd = new SQLiteCommand(query, sc);
            cmd.Parameters.AddWithValue("@full_name", txtFullName.Text);
            cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
            cmd.Parameters.AddWithValue("@birth_date", dtpBirthDate.Value.ToString("dd.MM.yyyy"));
            cmd.Parameters.AddWithValue("@student_book_number", txtStudentBookNumber.Text);
            cmd.Parameters.AddWithValue("@gender", cmbGender.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@group_id", txtGroup.Text);

            if (!isNewRecord)
            {
                cmd.Parameters.AddWithValue("@student_id", dataRow["student_id"]);
            }

            cmd.ExecuteNonQuery();
        }

        private void SaveTeacher()
        {
            string query = isNewRecord
                ? "INSERT INTO Teachers (full_name, phone, birth_date, gender, position_id) VALUES (@full_name, @phone, @birth_date, @gender, @position_id)"
                : "UPDATE Teachers SET full_name = @full_name, phone = @phone, birth_date = @birth_date, gender = @gender, position_id = @position_id WHERE teacher_id = @teacher_id";

            SQLiteCommand cmd = new SQLiteCommand(query, sc);
            cmd.Parameters.AddWithValue("@full_name", txtFullName.Text);
            cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
            cmd.Parameters.AddWithValue("@birth_date", dtpBirthDate.Value.ToString("dd.MM.yyyy"));
            cmd.Parameters.AddWithValue("@gender", cmbGender.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@position_id", cmbPositionId.SelectedValue);

            if (!isNewRecord)
            {
                cmd.Parameters.AddWithValue("@teacher_id", dataRow["teacher_id"]);
            }

            cmd.ExecuteNonQuery();
        }

        private void SaveDiscipline()
        {
            string query = isNewRecord
                ? "INSERT INTO Disciplines (discipline_name, discipline_description, teacher_id, hours_count) VALUES (@discipline_name, @discipline_description, @teacher_id, @hours_count)"
                : "UPDATE Disciplines SET discipline_name = @discipline_name, discipline_description = @discipline_description, teacher_id = @teacher_id, hours_count = @hours_count WHERE discipline_id = @discipline_id";

            SQLiteCommand cmd = new SQLiteCommand(query, sc);
            cmd.Parameters.AddWithValue("@discipline_name", txtDisciplineName.Text);
            cmd.Parameters.AddWithValue("@discipline_description", txtDisciplineDescription.Text);
            cmd.Parameters.AddWithValue("@teacher_id", cmbTeacherId.SelectedValue);
            cmd.Parameters.AddWithValue("@hours_count", txtHoursCount.Text);

            if (!isNewRecord)
            {
                cmd.Parameters.AddWithValue("@discipline_id", dataRow["discipline_id"]);
            }

            cmd.ExecuteNonQuery();
        }

        private void SaveGrade()
        {
            string query = isNewRecord
                ? "INSERT INTO Grades (student_id, discipline_id, grade) VALUES (@student_id, @discipline_id, @grade)"
                : "UPDATE Grades SET student_id = @student_id, discipline_id = @discipline_id, grade = @grade WHERE grade_id = @grade_id";

            SQLiteCommand cmd = new SQLiteCommand(query, sc);
            cmd.Parameters.AddWithValue("@student_id", cmbStudentId.SelectedValue);
            cmd.Parameters.AddWithValue("@discipline_id", cmbDisciplineId.SelectedValue);
            cmd.Parameters.AddWithValue("@grade", txtGrade.Text);

            if (!isNewRecord)
            {
                cmd.Parameters.AddWithValue("@grade_id", dataRow["grade_id"]);
            }

            cmd.ExecuteNonQuery();
        }

        private void SaveGroup()
        {
            string query = isNewRecord
                ? "INSERT INTO Groups (name, direction_id, qualification_id, admission_year) VALUES (@name, @direction_id, @qualification_id, @admission_year)"
                : "UPDATE Groups SET name = @name, direction_id = @direction_id, qualification_id = @qualification_id, admission_year = @admission_year WHERE group_id = @group_id";

            SQLiteCommand cmd = new SQLiteCommand(query, sc);
            cmd.Parameters.AddWithValue("@name", txtGroupName.Text);
            cmd.Parameters.AddWithValue("@direction_id", cmbDirectionId.SelectedValue);
            cmd.Parameters.AddWithValue("@qualification_id", cmbQualificationId.SelectedValue);
            cmd.Parameters.AddWithValue("@admission_year", txtAdmissionYear.Text);

            if (!isNewRecord)
            {
                cmd.Parameters.AddWithValue("@group_id", dataRow["group_id"]);
            }

            cmd.ExecuteNonQuery();
        }

        private void SaveDirection()
        {
            string query = isNewRecord
                ? "INSERT INTO Direction (direction) VALUES (@direction)"
                : "UPDATE Direction SET direction = @direction WHERE direction_id = @direction_id";

            SQLiteCommand cmd = new SQLiteCommand(query, sc);
            cmd.Parameters.AddWithValue("@direction", txtDirection.Text);

            if (!isNewRecord)
            {
                cmd.Parameters.AddWithValue("@direction_id", dataRow["direction_id"]);
            }

            cmd.ExecuteNonQuery();
        }

        private void SaveQualification()
        {
            string query = isNewRecord
                ? "INSERT INTO Qualification (qualification) VALUES (@qualification)"
                : "UPDATE Qualification SET qualification = @qualification WHERE qualification_id = @qualification_id";

            SQLiteCommand cmd = new SQLiteCommand(query, sc);
            cmd.Parameters.AddWithValue("@qualification", txtQualification.Text);

            if (!isNewRecord)
            {
                cmd.Parameters.AddWithValue("@qualification_id", dataRow["qualification_id"]);
            }

            cmd.ExecuteNonQuery();
        }

        private void SavePosition()
        {
            string query = isNewRecord
                ? "INSERT INTO Position (position) VALUES (@position)"
                : "UPDATE Position SET position = @position WHERE position_id = @position_id";

            SQLiteCommand cmd = new SQLiteCommand(query, sc);
            cmd.Parameters.AddWithValue("@position", txtPosition.Text);

            if (!isNewRecord)
            {
                cmd.Parameters.AddWithValue("@position_id", dataRow["position_id"]);
            }

            cmd.ExecuteNonQuery();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}