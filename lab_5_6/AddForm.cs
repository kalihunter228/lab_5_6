using System;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SQLite;
using System.Linq;
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
                case "Студенты":
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

                    LoadGenders();

                    if (!isNewRecord)
                    {
                        txtFullName.Text = dataRow["ФИО"].ToString();
                        txtPhone.Text = dataRow["Телефон"].ToString();
                        dtpBirthDate.Value = DateTime.Parse(dataRow["Дата рождения"].ToString());
                        txtStudentBookNumber.Text = dataRow["Номер студенческого билета"].ToString();
                        cmbGender.SelectedItem = dataRow["Пол"].ToString();
                        txtGroup.Text = dataRow["Группа"].ToString();
                    }
                    break;

                case "Преподаватели":
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

                        txtFullName.Text = dataRow["ФИО"].ToString();
                        txtPhone.Text = dataRow["Телефон"].ToString();
                        dtpBirthDate.Value = DateTime.Parse(dataRow["Дата рождения"].ToString());
                        cmbGender.SelectedItem = dataRow["Пол"].ToString();
                        string position = dataRow["Должность"].ToString();

                        foreach (var item in cmbPositionId.Items)
                        {
                            if ((item as dynamic).Text == position)
                            {
                                cmbPositionId.SelectedItem = item;
                            }
                        }
                    }
                    break;

                case "Дисциплины":
                    lblDisciplineName.Visible = true;
                    txtDisciplineName.Visible = true;
                    lblDisciplineDescription.Visible = true;
                    txtDisciplineDescription.Visible = true;
                    lblTeacherId.Visible = true;
                    txtTeacherId.Visible = true;
                    lblHoursCount.Visible = true;
                    textBox1.Visible = true;


                    if (!isNewRecord)
                    {
                        txtDisciplineName.Text = dataRow["Название дисциплины"].ToString();
                        txtDisciplineDescription.Text = dataRow["Описание"].ToString();
                        txtTeacherId.Text = dataRow["Преподаватель"].ToString();
                        textBox1.Text = dataRow["Количество часов"].ToString();
                    }
                    break;

                case "Оценки":
                    lblStudentId.Visible = true;
                    txtStudentId.Visible = true;
                    lblDisciplineId.Visible = true;
                    cmbDisciplineId.Visible = true;
                    lblGrade.Visible = true;
                    txtGrade.Visible = true;

                    LoadDisciplines();

                    if (!isNewRecord)
                    {
                        txtStudentId.Text = dataRow["Студент"].ToString();
                        txtGrade.Text = dataRow["Оценка"].ToString();

                        string discipline = dataRow["Дисциплина"].ToString();
                        var selectedDiscipline = cmbDisciplineId.Items.Cast<object>()
                            .FirstOrDefault(item => (item as dynamic).Text == discipline);
                        if (selectedDiscipline != null)
                        {
                            cmbDisciplineId.SelectedItem = selectedDiscipline;
                        }
                    }
                    break;

                case "Группы":
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
                        txtGroupName.Text = dataRow["Название группы"].ToString();
                        txtAdmissionYear.Text = dataRow["Год поступления"].ToString();

                        string direction = dataRow["Направление"].ToString();
                        var selectedDirection = cmbDirectionId.Items.Cast<object>()
                            .FirstOrDefault(item => (item as dynamic).Text == direction);
                        if (selectedDirection != null)
                        {
                            cmbDirectionId.SelectedItem = selectedDirection;
                        }

                        string qualification = dataRow["Квалификация"].ToString();
                        var selectedQualification = cmbQualificationId.Items.Cast<object>()
                            .FirstOrDefault(item => (item as dynamic).Text == qualification);
                        if (selectedQualification != null)
                        {
                            cmbQualificationId.SelectedItem = selectedQualification;
                        }
                    }
                    break;

            }
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
            txtTeacherId.Visible = false;
            lblHoursCount.Visible = false;
            textBox1.Visible = false;

            // Grades
            lblStudentId.Visible = false;
            txtStudentId.Visible = false;
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
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                return;
            }

            try
            {
                bool saveSuccessful = false;

                switch (tableName)
                {
                    case "Студенты":
                        saveSuccessful = SaveStudent();
                        break;
                    case "Преподаватели":
                        saveSuccessful = SaveTeacher();
                        break;
                    case "Дисциплины":
                        saveSuccessful = SaveDiscipline();
                        break;
                    case "Оценки":
                        saveSuccessful = SaveGrade();
                        break;
                    case "Группы":
                        saveSuccessful = SaveGroup();
                        break;
                }

                if (saveSuccessful)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении данных: " + ex.Message);
            }
        }

        private bool ValidateInputs()
        {
            bool isValid = true;
            string errorMessage = "";

            switch (tableName)
            {
                case "Студенты":
                    if (!ValidateFullName(txtFullName.Text))
                    {
                        errorMessage += "ФИО должно содержать только русские буквы(Фамилия Имя Отчество)\n";
                        isValid = false;
                    }
                    if (!ValidatePhone(txtPhone.Text))
                    {
                        errorMessage += "Номер телефона должен содержать 11 цифр\n";
                        isValid = false;
                    }
                    if (!ValidateStudentBook(txtStudentBookNumber.Text))
                    {
                        errorMessage += "Неверный номер студенческого билета(8 цифр)\n";
                        isValid = false;
                    }
                    if (cmbGender.SelectedIndex == -1)
                    {
                        errorMessage += "Выберите пол\n";
                        isValid = false;
                    }
                    if (!ValidateGroupId(txtGroup.Text))
                    {
                        errorMessage += "Введите правильное название группы вида(ПИ_22_1)\n";
                        isValid = false;
                    }
                    break;

                case "Преподаватели":
                    if (!ValidateFullName(txtFullName.Text))
                    {
                        errorMessage += "ФИО должно содержать только русские буквы(Фамилия Имя Отчество)\n";
                        isValid = false;
                    }
                    if (!ValidatePhone(txtPhone.Text))
                    {
                        errorMessage += "Номер телефона должен содержать 11 цифр\n";
                        isValid = false;
                    }
                    if (cmbGender.SelectedIndex == -1)
                    {
                        errorMessage += "Выберите пол\n";
                        isValid = false;
                    }
                    if (cmbPositionId.SelectedIndex == -1)
                    {
                        errorMessage += "Выберите должность\n";
                        isValid = false;
                    }
                    break;

                case "Дисциплины":
                    if (!IsAllLetters(txtDisciplineName.Text))
                    {
                        errorMessage += "Введите название дисциплины\n";
                        isValid = false;
                    }
                    if (!ValidateFullName(txtTeacherId.Text))
                    {
                        errorMessage += "Введите правильное ФИО преподавателя(Фамилия Имя Отчество)\n";
                        isValid = false;
                    }
                    if (!ValidateHours(textBox1.Text))
                    {
                        errorMessage += "Количество часов должно быть положительным числом(от 0 до 500)\n";
                        isValid = false;
                    }
                    break;

                case "Оценки":
                    if (!ValidateFullName(txtStudentId.Text))
                    {
                        errorMessage += "Введите правильное ФИО студента(Фамилия Имя Отчество)\n";
                        isValid = false;
                    }
                    if (cmbDisciplineId.SelectedIndex == -1)
                    {
                        errorMessage += "Выберите дисциплину\n";
                        isValid = false;
                    }
                    if (!ValidateGrade(txtGrade.Text))
                    {
                        errorMessage += "Оценка должна быть от 1 до 5\n";
                        isValid = false;
                    }
                    break;

                case "Группы":
                    if (string.IsNullOrWhiteSpace(txtGroupName.Text))
                    {
                        errorMessage += "Введите название группы(ПИ_22_1)\n";
                        isValid = false;
                    }
                    if (cmbDirectionId.SelectedIndex == -1)
                    {
                        errorMessage += "Выберите направление\n";
                        isValid = false;
                    }
                    if (cmbQualificationId.SelectedIndex == -1)
                    {
                        errorMessage += "Выберите квалификацию\n";
                        isValid = false;
                    }
                    if (!ValidateYear(txtAdmissionYear.Text))
                    {
                        errorMessage += "Введите корректный год поступления\n";
                        isValid = false;
                    }
                    break;
            }

            if (!isValid)
            {
                MessageBox.Show(errorMessage, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isValid;
        }

        private bool ValidateFullName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;

            string[] nameParts = name.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (nameParts.Length != 3)
            {
                return false;
            }

            foreach (string part in nameParts)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(part, @"^[а-яА-Я]+$"))
                {
                    return false;
                }
            }

            return true;
        }

        private bool ValidatePhone(string phone)
        {
            return !string.IsNullOrWhiteSpace(phone) &&
                   System.Text.RegularExpressions.Regex.IsMatch(phone, @"^\d{11}$");
        }

        private bool ValidateStudentBook(string number)
        {
            return !string.IsNullOrWhiteSpace(number) &&
                   System.Text.RegularExpressions.Regex.IsMatch(number, @"^\d+$");
        }

        private bool ValidateStudentId(string studentId)
        {
            return !string.IsNullOrWhiteSpace(studentId) &&
                   int.TryParse(studentId, out int id) &&
                   id > 0;
        }

        private bool ValidateGroupId(string groupId)
        {
            if (string.IsNullOrWhiteSpace(groupId))
            {
                return false;
            }

            var match = System.Text.RegularExpressions.Regex.Match(groupId, @"^([А-Я]+)_(\d{2})_(\d)$");

            if (!match.Success)
            {
                return false;
            }

            return true;
        }

        private bool ValidateGrade(string grade)
        {
            return int.TryParse(grade, out int value) &&
                   value >= 1 &&
                   value <= 5;
        }

        private bool ValidateHours(string hours)
        {
            return int.TryParse(hours, out int value) &&
                   value > 0 &&
                   value <= 500;
        }

        private bool ValidateYear(string year)
        {
            if (!int.TryParse(year, out int yearValue))
                return false;

            int currentYear = DateTime.Now.Year;
            return yearValue >= 1900 && yearValue <= currentYear + 20;
        }

        private bool IsAllLetters(string input)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(input, @"^[а-яА-Я ]+$");
        }

        private bool SaveStudent()
        {
            string groupQuery = "SELECT group_id FROM Groups WHERE name = @name";
            SQLiteCommand groupCmd = new SQLiteCommand(groupQuery, sc);
            groupCmd.Parameters.AddWithValue("@name", txtGroup.Text);
            object groupId = groupCmd.ExecuteScalar();

            if (groupId == null)
            {
                MessageBox.Show("Указанная группа не найдена!");
                return false;
            }


            string query = isNewRecord
                ? "INSERT INTO Students (full_name, phone, birth_date, student_book_number, gender, group_id) VALUES (@full_name, @phone, @birth_date, @student_book_number, @gender, @group_id)"
                : "UPDATE Students SET full_name = @full_name, phone = @phone, birth_date = @birth_date, student_book_number = @student_book_number, gender = @gender, group_id = @group_id WHERE student_id = @student_id";

            SQLiteCommand cmd = new SQLiteCommand(query, sc);
            cmd.Parameters.AddWithValue("@full_name", txtFullName.Text);
            cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
            cmd.Parameters.AddWithValue("@birth_date", dtpBirthDate.Value.ToString("dd.MM.yyyy"));
            cmd.Parameters.AddWithValue("@student_book_number", txtStudentBookNumber.Text);
            cmd.Parameters.AddWithValue("@gender", cmbGender.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@group_id", groupId);

            if (!isNewRecord)
            {
                cmd.Parameters.AddWithValue("@student_id", dataRow["ID Студента"]);
            }

            cmd.ExecuteNonQuery();
            return true;
        }

        private bool SaveTeacher()
        {
            string teacherQuery = "SELECT position_id FROM Position WHERE position = @position_id";
            SQLiteCommand teacherCmd = new SQLiteCommand(teacherQuery, sc);
            teacherCmd.Parameters.AddWithValue("@position_id", cmbPositionId.Text);
            object teacherId = teacherCmd.ExecuteScalar();

            string query = isNewRecord
                ? "INSERT INTO Teachers (full_name, phone, birth_date, gender, position_id) VALUES (@full_name, @phone, @birth_date, @gender, @position_id)"
                : "UPDATE Teachers SET full_name = @full_name, phone = @phone, birth_date = @birth_date, gender = @gender, position_id = @position_id WHERE teacher_id = @teacher_id";

            SQLiteCommand cmd = new SQLiteCommand(query, sc);
            cmd.Parameters.AddWithValue("@full_name", txtFullName.Text);
            cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
            cmd.Parameters.AddWithValue("@birth_date", dtpBirthDate.Value.ToString("dd.MM.yyyy"));
            cmd.Parameters.AddWithValue("@gender", cmbGender.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@position_id", teacherId);

            if (!isNewRecord)
            {
                cmd.Parameters.AddWithValue("@teacher_id", dataRow["ID Преподавателя"]);
            }

            cmd.ExecuteNonQuery();
            return true;
        }

        private bool SaveDiscipline()
        {
            string teacherQuery = "SELECT teacher_id FROM Teachers WHERE full_name = @full_name";
            SQLiteCommand teacherCmd = new SQLiteCommand(teacherQuery, sc);
            teacherCmd.Parameters.AddWithValue("@full_name", txtTeacherId.Text);
            object teacherId = teacherCmd.ExecuteScalar();

            if (teacherId == null)
            {
                MessageBox.Show("Указанный преподаватель не найден!");
                return false;
            }

            string query = isNewRecord
                ? "INSERT INTO Disciplines (discipline_name, discipline_description, teacher_id, hours_count) VALUES (@discipline_name, @discipline_description, @teacher_id, @hours_count)"
                : "UPDATE Disciplines SET discipline_name = @discipline_name, discipline_description = @discipline_description, teacher_id = @teacher_id, hours_count = @hours_count WHERE discipline_id = @discipline_id";

            SQLiteCommand cmd = new SQLiteCommand(query, sc);
            cmd.Parameters.AddWithValue("@discipline_name", txtDisciplineName.Text);
            cmd.Parameters.AddWithValue("@discipline_description", txtDisciplineDescription.Text);
            cmd.Parameters.AddWithValue("@teacher_id", teacherId);
            cmd.Parameters.AddWithValue("@hours_count", textBox1.Text);

            if (!isNewRecord)
            {
                cmd.Parameters.AddWithValue("@discipline_id", dataRow["ID Дисциплины"]);
            }

            cmd.ExecuteNonQuery();
            return true;
        }

        private bool SaveGrade()
        {
            string studentQuery = "SELECT student_id FROM Students WHERE full_name = @full_name";
            SQLiteCommand studentCmd = new SQLiteCommand(studentQuery, sc);
            studentCmd.Parameters.AddWithValue("@full_name", txtStudentId.Text);
            object studentId = studentCmd.ExecuteScalar();


            if (studentId == null)
            {
                MessageBox.Show("Указанный студент не найден!");
                return false;
            }

            string disciplineQuery = "SELECT discipline_id FROM Disciplines WHERE discipline_name = @discipline_id";
            SQLiteCommand disciplineCmd = new SQLiteCommand(disciplineQuery, sc);
            disciplineCmd.Parameters.AddWithValue("@discipline_id", cmbDisciplineId.Text);
            object disciplineId = disciplineCmd.ExecuteScalar();

            string query = isNewRecord
                ? "INSERT INTO Grades (student_id, discipline_id, grade) VALUES (@student_id, @discipline_id, @grade)"
                : "UPDATE Grades SET student_id = @student_id, discipline_id = @discipline_id, grade = @grade WHERE grade_id = @grade_id";

            SQLiteCommand cmd = new SQLiteCommand(query, sc);
            cmd.Parameters.AddWithValue("@student_id", studentId);
            cmd.Parameters.AddWithValue("@discipline_id", disciplineId);
            cmd.Parameters.AddWithValue("@grade", txtGrade.Text);

            if (!isNewRecord)
            {
                cmd.Parameters.AddWithValue("@grade_id", dataRow["ID Оценки"]);
            }

            cmd.ExecuteNonQuery();
            return true;
        }

        private bool SaveGroup()
        {
            string directionQuery = "SELECT direction_id FROM Direction WHERE direction = @direction_name";
            SQLiteCommand directionCmd = new SQLiteCommand(directionQuery, sc);
            directionCmd.Parameters.AddWithValue("@direction_name", cmbDirectionId.Text);
            object directionId = directionCmd.ExecuteScalar();

            if (directionId == null)
            {
                MessageBox.Show("Указанное направление не найдено!");
                return false;
            }

            string qualificationQuery = "SELECT qualification_id FROM Qualification WHERE qualification = @qualification_name";
            SQLiteCommand qualificationCmd = new SQLiteCommand(qualificationQuery, sc);
            qualificationCmd.Parameters.AddWithValue("@qualification_name", cmbQualificationId.Text);
            object qualificationId = qualificationCmd.ExecuteScalar();

            if (qualificationId == null)
            {
                MessageBox.Show("Указанная квалификация не найдена!");
                return false;
            }

            string query = isNewRecord
                ? "INSERT INTO Groups (name, direction_id, qualification_id, admission_year) VALUES (@name, @direction_id, @qualification_id, @admission_year)"
                : "UPDATE Groups SET name = @name, direction_id = @direction_id, qualification_id = @qualification_id, admission_year = @admission_year WHERE group_id = @group_id";

            SQLiteCommand cmd = new SQLiteCommand(query, sc);
            cmd.Parameters.AddWithValue("@name", txtGroupName.Text);
            cmd.Parameters.AddWithValue("@direction_id", directionId);
            cmd.Parameters.AddWithValue("@qualification_id", qualificationId);
            cmd.Parameters.AddWithValue("@admission_year", txtAdmissionYear.Text);

            if (!isNewRecord)
            {
                cmd.Parameters.AddWithValue("@group_id", dataRow["ID Группы"]);
            }

            cmd.ExecuteNonQuery();
            return true;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFullName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDisciplineName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtStudentId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGroupName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDisciplineDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbDisciplineId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbDirectionId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtpBirthDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtTeacherId_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbQualificationId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtStudentBookNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbPositionId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGrade_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAdmissionYear_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtGroup_TextChanged(object sender, EventArgs e)
        {

        }

    }
}