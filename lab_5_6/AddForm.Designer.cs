namespace lab_5_6
{
    partial class AddForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblGroupId = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.lblStudentBookNumber = new System.Windows.Forms.Label();
            this.txtStudentBookNumber = new System.Windows.Forms.TextBox();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.lblPositionId = new System.Windows.Forms.Label();
            this.cmbPositionId = new System.Windows.Forms.ComboBox();
            this.lblDisciplineName = new System.Windows.Forms.Label();
            this.txtDisciplineName = new System.Windows.Forms.TextBox();
            this.lblDisciplineDescription = new System.Windows.Forms.Label();
            this.txtDisciplineDescription = new System.Windows.Forms.TextBox();
            this.lblTeacherId = new System.Windows.Forms.Label();
            this.txtTeacherId = new System.Windows.Forms.TextBox();
            this.lblHoursCount = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblStudentId = new System.Windows.Forms.Label();
            this.txtStudentId = new System.Windows.Forms.TextBox();
            this.lblDisciplineId = new System.Windows.Forms.Label();
            this.cmbDisciplineId = new System.Windows.Forms.ComboBox();
            this.lblGrade = new System.Windows.Forms.Label();
            this.txtGrade = new System.Windows.Forms.TextBox();
            this.lblGroupName = new System.Windows.Forms.Label();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.lblDirectionId = new System.Windows.Forms.Label();
            this.cmbDirectionId = new System.Windows.Forms.ComboBox();
            this.lblQualificationId = new System.Windows.Forms.Label();
            this.cmbQualificationId = new System.Windows.Forms.ComboBox();
            this.lblAdmissionYear = new System.Windows.Forms.Label();
            this.txtAdmissionYear = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFullName
            // 
            this.lblFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.lblFullName.Location = new System.Drawing.Point(30, 30);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(73, 28);
            this.lblFullName.TabIndex = 0;
            this.lblFullName.Text = "ФИО";
            // 
            // lblPhone
            // 
            this.lblPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.lblPhone.Location = new System.Drawing.Point(30, 70);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(119, 28);
            this.lblPhone.TabIndex = 1;
            this.lblPhone.Text = "Телефон";
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.lblBirthDate.Location = new System.Drawing.Point(30, 107);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(212, 28);
            this.lblBirthDate.TabIndex = 2;
            this.lblBirthDate.Text = "Дата рождения";
            // 
            // lblGender
            // 
            this.lblGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.lblGender.Location = new System.Drawing.Point(30, 191);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(84, 28);
            this.lblGender.TabIndex = 3;
            this.lblGender.Text = "Пол";
            // 
            // lblGroupId
            // 
            this.lblGroupId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.lblGroupId.Location = new System.Drawing.Point(30, 234);
            this.lblGroupId.Name = "lblGroupId";
            this.lblGroupId.Size = new System.Drawing.Size(96, 28);
            this.lblGroupId.TabIndex = 4;
            this.lblGroupId.Text = "Группа";
            // 
            // txtFullName
            // 
            this.txtFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.8F);
            this.txtFullName.Location = new System.Drawing.Point(250, 29);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(200, 30);
            this.txtFullName.TabIndex = 5;
            this.txtFullName.TextChanged += new System.EventHandler(this.txtFullName_TextChanged);
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.8F);
            this.txtPhone.Location = new System.Drawing.Point(250, 70);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(200, 30);
            this.txtPhone.TabIndex = 6;
            this.txtPhone.TextChanged += new System.EventHandler(this.txtPhone_TextChanged);
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.8F);
            this.dtpBirthDate.Location = new System.Drawing.Point(250, 109);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(200, 30);
            this.dtpBirthDate.TabIndex = 7;
            this.dtpBirthDate.ValueChanged += new System.EventHandler(this.dtpBirthDate_ValueChanged);
            // 
            // lblStudentBookNumber
            // 
            this.lblStudentBookNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.lblStudentBookNumber.Location = new System.Drawing.Point(30, 146);
            this.lblStudentBookNumber.Name = "lblStudentBookNumber";
            this.lblStudentBookNumber.Size = new System.Drawing.Size(220, 28);
            this.lblStudentBookNumber.TabIndex = 8;
            this.lblStudentBookNumber.Text = "№ зачетной книжки";
            // 
            // txtStudentBookNumber
            // 
            this.txtStudentBookNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.8F);
            this.txtStudentBookNumber.Location = new System.Drawing.Point(250, 146);
            this.txtStudentBookNumber.Name = "txtStudentBookNumber";
            this.txtStudentBookNumber.Size = new System.Drawing.Size(200, 30);
            this.txtStudentBookNumber.TabIndex = 9;
            this.txtStudentBookNumber.TextChanged += new System.EventHandler(this.txtStudentBookNumber_TextChanged);
            // 
            // cmbGender
            // 
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.8F);
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Location = new System.Drawing.Point(250, 191);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(200, 33);
            this.cmbGender.TabIndex = 10;
            this.cmbGender.SelectedIndexChanged += new System.EventHandler(this.cmbGender_SelectedIndexChanged);
            // 
            // txtGroup
            // 
            this.txtGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.8F);
            this.txtGroup.Location = new System.Drawing.Point(250, 234);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(200, 30);
            this.txtGroup.TabIndex = 11;
            this.txtGroup.TextChanged += new System.EventHandler(this.txtGroup_TextChanged);
            // 
            // lblPositionId
            // 
            this.lblPositionId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.lblPositionId.Location = new System.Drawing.Point(30, 146);
            this.lblPositionId.Name = "lblPositionId";
            this.lblPositionId.Size = new System.Drawing.Size(220, 35);
            this.lblPositionId.TabIndex = 12;
            this.lblPositionId.Text = "Должность";
            // 
            // cmbPositionId
            // 
            this.cmbPositionId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPositionId.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.8F);
            this.cmbPositionId.FormattingEnabled = true;
            this.cmbPositionId.Location = new System.Drawing.Point(250, 145);
            this.cmbPositionId.Name = "cmbPositionId";
            this.cmbPositionId.Size = new System.Drawing.Size(200, 33);
            this.cmbPositionId.TabIndex = 13;
            this.cmbPositionId.SelectedIndexChanged += new System.EventHandler(this.cmbPositionId_SelectedIndexChanged);
            // 
            // lblDisciplineName
            // 
            this.lblDisciplineName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.lblDisciplineName.Location = new System.Drawing.Point(30, 30);
            this.lblDisciplineName.Name = "lblDisciplineName";
            this.lblDisciplineName.Size = new System.Drawing.Size(146, 28);
            this.lblDisciplineName.TabIndex = 14;
            this.lblDisciplineName.Text = "Дисциплина";
            // 
            // txtDisciplineName
            // 
            this.txtDisciplineName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.8F);
            this.txtDisciplineName.Location = new System.Drawing.Point(250, 31);
            this.txtDisciplineName.Name = "txtDisciplineName";
            this.txtDisciplineName.Size = new System.Drawing.Size(200, 30);
            this.txtDisciplineName.TabIndex = 15;
            this.txtDisciplineName.TextChanged += new System.EventHandler(this.txtDisciplineName_TextChanged);
            // 
            // lblDisciplineDescription
            // 
            this.lblDisciplineDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.lblDisciplineDescription.Location = new System.Drawing.Point(30, 69);
            this.lblDisciplineDescription.Name = "lblDisciplineDescription";
            this.lblDisciplineDescription.Size = new System.Drawing.Size(146, 28);
            this.lblDisciplineDescription.TabIndex = 16;
            this.lblDisciplineDescription.Text = "Описание";
            // 
            // txtDisciplineDescription
            // 
            this.txtDisciplineDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.8F);
            this.txtDisciplineDescription.Location = new System.Drawing.Point(250, 69);
            this.txtDisciplineDescription.Name = "txtDisciplineDescription";
            this.txtDisciplineDescription.Size = new System.Drawing.Size(200, 30);
            this.txtDisciplineDescription.TabIndex = 17;
            this.txtDisciplineDescription.TextChanged += new System.EventHandler(this.txtDisciplineDescription_TextChanged);
            // 
            // lblTeacherId
            // 
            this.lblTeacherId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.lblTeacherId.Location = new System.Drawing.Point(30, 107);
            this.lblTeacherId.Name = "lblTeacherId";
            this.lblTeacherId.Size = new System.Drawing.Size(212, 28);
            this.lblTeacherId.TabIndex = 18;
            this.lblTeacherId.Text = "Преподаватель";
            // 
            // txtTeacherId
            // 
            this.txtTeacherId.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.8F);
            this.txtTeacherId.Location = new System.Drawing.Point(250, 109);
            this.txtTeacherId.Name = "txtTeacherId";
            this.txtTeacherId.Size = new System.Drawing.Size(200, 30);
            this.txtTeacherId.TabIndex = 19;
            this.txtTeacherId.TextChanged += new System.EventHandler(this.txtTeacherId_TextChanged);
            // 
            // lblHoursCount
            // 
            this.lblHoursCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.lblHoursCount.Location = new System.Drawing.Point(30, 145);
            this.lblHoursCount.Name = "lblHoursCount";
            this.lblHoursCount.Size = new System.Drawing.Size(214, 28);
            this.lblHoursCount.TabIndex = 20;
            this.lblHoursCount.Text = "Количество часов";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.8F);
            this.textBox1.Location = new System.Drawing.Point(250, 145);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 30);
            this.textBox1.TabIndex = 21;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblStudentId
            // 
            this.lblStudentId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.lblStudentId.Location = new System.Drawing.Point(30, 30);
            this.lblStudentId.Name = "lblStudentId";
            this.lblStudentId.Size = new System.Drawing.Size(146, 28);
            this.lblStudentId.TabIndex = 22;
            this.lblStudentId.Text = "ФИО сстудента";
            // 
            // txtStudentId
            // 
            this.txtStudentId.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.8F);
            this.txtStudentId.Location = new System.Drawing.Point(250, 29);
            this.txtStudentId.Name = "txtStudentId";
            this.txtStudentId.Size = new System.Drawing.Size(200, 30);
            this.txtStudentId.TabIndex = 23;
            this.txtStudentId.TextChanged += new System.EventHandler(this.txtStudentId_TextChanged);
            // 
            // lblDisciplineId
            // 
            this.lblDisciplineId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.lblDisciplineId.Location = new System.Drawing.Point(30, 70);
            this.lblDisciplineId.Name = "lblDisciplineId";
            this.lblDisciplineId.Size = new System.Drawing.Size(146, 28);
            this.lblDisciplineId.TabIndex = 24;
            this.lblDisciplineId.Text = "Предмет";
            // 
            // cmbDisciplineId
            // 
            this.cmbDisciplineId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDisciplineId.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.8F);
            this.cmbDisciplineId.FormattingEnabled = true;
            this.cmbDisciplineId.Location = new System.Drawing.Point(250, 70);
            this.cmbDisciplineId.Name = "cmbDisciplineId";
            this.cmbDisciplineId.Size = new System.Drawing.Size(200, 33);
            this.cmbDisciplineId.TabIndex = 25;
            this.cmbDisciplineId.SelectedIndexChanged += new System.EventHandler(this.cmbDisciplineId_SelectedIndexChanged);
            // 
            // lblGrade
            // 
            this.lblGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.lblGrade.Location = new System.Drawing.Point(30, 107);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(214, 28);
            this.lblGrade.TabIndex = 26;
            this.lblGrade.Text = "Оценка";
            // 
            // txtGrade
            // 
            this.txtGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.8F);
            this.txtGrade.Location = new System.Drawing.Point(250, 108);
            this.txtGrade.Name = "txtGrade";
            this.txtGrade.Size = new System.Drawing.Size(200, 30);
            this.txtGrade.TabIndex = 27;
            this.txtGrade.TextChanged += new System.EventHandler(this.txtGrade_TextChanged);
            // 
            // lblGroupName
            // 
            this.lblGroupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.lblGroupName.Location = new System.Drawing.Point(30, 31);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(212, 28);
            this.lblGroupName.TabIndex = 28;
            this.lblGroupName.Text = "Название группы";
            // 
            // txtGroupName
            // 
            this.txtGroupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.8F);
            this.txtGroupName.Location = new System.Drawing.Point(250, 32);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(200, 30);
            this.txtGroupName.TabIndex = 29;
            this.txtGroupName.TextChanged += new System.EventHandler(this.txtGroupName_TextChanged);
            // 
            // lblDirectionId
            // 
            this.lblDirectionId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.lblDirectionId.Location = new System.Drawing.Point(30, 70);
            this.lblDirectionId.Name = "lblDirectionId";
            this.lblDirectionId.Size = new System.Drawing.Size(212, 28);
            this.lblDirectionId.TabIndex = 30;
            this.lblDirectionId.Text = "Направление";
            // 
            // cmbDirectionId
            // 
            this.cmbDirectionId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDirectionId.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.8F);
            this.cmbDirectionId.FormattingEnabled = true;
            this.cmbDirectionId.Location = new System.Drawing.Point(250, 70);
            this.cmbDirectionId.Name = "cmbDirectionId";
            this.cmbDirectionId.Size = new System.Drawing.Size(200, 33);
            this.cmbDirectionId.TabIndex = 31;
            this.cmbDirectionId.SelectedIndexChanged += new System.EventHandler(this.cmbDirectionId_SelectedIndexChanged);
            // 
            // lblQualificationId
            // 
            this.lblQualificationId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.lblQualificationId.Location = new System.Drawing.Point(30, 108);
            this.lblQualificationId.Name = "lblQualificationId";
            this.lblQualificationId.Size = new System.Drawing.Size(212, 28);
            this.lblQualificationId.TabIndex = 32;
            this.lblQualificationId.Text = "Квалификация";
            // 
            // cmbQualificationId
            // 
            this.cmbQualificationId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQualificationId.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.8F);
            this.cmbQualificationId.FormattingEnabled = true;
            this.cmbQualificationId.Location = new System.Drawing.Point(250, 106);
            this.cmbQualificationId.Name = "cmbQualificationId";
            this.cmbQualificationId.Size = new System.Drawing.Size(200, 33);
            this.cmbQualificationId.TabIndex = 33;
            this.cmbQualificationId.SelectedIndexChanged += new System.EventHandler(this.cmbQualificationId_SelectedIndexChanged);
            // 
            // lblAdmissionYear
            // 
            this.lblAdmissionYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.lblAdmissionYear.Location = new System.Drawing.Point(30, 146);
            this.lblAdmissionYear.Name = "lblAdmissionYear";
            this.lblAdmissionYear.Size = new System.Drawing.Size(212, 28);
            this.lblAdmissionYear.TabIndex = 34;
            this.lblAdmissionYear.Text = "Год выпуска";
            // 
            // txtAdmissionYear
            // 
            this.txtAdmissionYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.8F);
            this.txtAdmissionYear.Location = new System.Drawing.Point(250, 144);
            this.txtAdmissionYear.Name = "txtAdmissionYear";
            this.txtAdmissionYear.Size = new System.Drawing.Size(200, 30);
            this.txtAdmissionYear.TabIndex = 35;
            this.txtAdmissionYear.TextChanged += new System.EventHandler(this.txtAdmissionYear_TextChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnCancel.Location = new System.Drawing.Point(226, 394);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 33);
            this.btnCancel.TabIndex = 38;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnSave.Location = new System.Drawing.Point(35, 394);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(124, 33);
            this.btnSave.TabIndex = 39;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtAdmissionYear);
            this.Controls.Add(this.lblAdmissionYear);
            this.Controls.Add(this.cmbQualificationId);
            this.Controls.Add(this.lblQualificationId);
            this.Controls.Add(this.cmbDirectionId);
            this.Controls.Add(this.lblDirectionId);
            this.Controls.Add(this.txtGroupName);
            this.Controls.Add(this.lblGroupName);
            this.Controls.Add(this.txtGrade);
            this.Controls.Add(this.lblGrade);
            this.Controls.Add(this.cmbDisciplineId);
            this.Controls.Add(this.lblDisciplineId);
            this.Controls.Add(this.txtStudentId);
            this.Controls.Add(this.lblStudentId);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblHoursCount);
            this.Controls.Add(this.txtTeacherId);
            this.Controls.Add(this.lblTeacherId);
            this.Controls.Add(this.txtDisciplineDescription);
            this.Controls.Add(this.lblDisciplineDescription);
            this.Controls.Add(this.txtDisciplineName);
            this.Controls.Add(this.lblDisciplineName);
            this.Controls.Add(this.cmbPositionId);
            this.Controls.Add(this.lblPositionId);
            this.Controls.Add(this.txtGroup);
            this.Controls.Add(this.cmbGender);
            this.Controls.Add(this.txtStudentBookNumber);
            this.Controls.Add(this.lblStudentBookNumber);
            this.Controls.Add(this.dtpBirthDate);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblGroupId);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.lblBirthDate);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblFullName);
            this.Name = "AddForm";
            this.Text = "AddForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblGroupId;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.Label lblStudentBookNumber;
        private System.Windows.Forms.TextBox txtStudentBookNumber;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.TextBox txtGroup;
        private System.Windows.Forms.Label lblPositionId;
        private System.Windows.Forms.ComboBox cmbPositionId;
        private System.Windows.Forms.Label lblDisciplineName;
        private System.Windows.Forms.TextBox txtDisciplineName;
        private System.Windows.Forms.Label lblDisciplineDescription;
        private System.Windows.Forms.TextBox txtDisciplineDescription;
        private System.Windows.Forms.Label lblTeacherId;
        private System.Windows.Forms.TextBox txtTeacherId;
        private System.Windows.Forms.Label lblHoursCount;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblStudentId;
        private System.Windows.Forms.TextBox txtStudentId;
        private System.Windows.Forms.Label lblDisciplineId;
        private System.Windows.Forms.ComboBox cmbDisciplineId;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.TextBox txtGrade;
        private System.Windows.Forms.Label lblGroupName;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.Label lblDirectionId;
        private System.Windows.Forms.ComboBox cmbDirectionId;
        private System.Windows.Forms.Label lblQualificationId;
        private System.Windows.Forms.ComboBox cmbQualificationId;
        private System.Windows.Forms.Label lblAdmissionYear;
        private System.Windows.Forms.TextBox txtAdmissionYear;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}