namespace AcademicManager
{
    partial class MainForm
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
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabHome = new System.Windows.Forms.TabPage();
            this.btnLogin = new System.Windows.Forms.Button();
            this.tabStudents = new System.Windows.Forms.TabPage();
            this.btnLManageStudents = new System.Windows.Forms.Button();
            this.tabCourses = new System.Windows.Forms.TabPage();
            this.btnManageCourses = new System.Windows.Forms.Button();
            this.tabGrades = new System.Windows.Forms.TabPage();
            this.btnRecordGrades = new System.Windows.Forms.Button();
            this.tabReports = new System.Windows.Forms.TabPage();
            this.btnViewRecords = new System.Windows.Forms.Button();
            this.tabControlMain.SuspendLayout();
            this.tabHome.SuspendLayout();
            this.tabStudents.SuspendLayout();
            this.tabCourses.SuspendLayout();
            this.tabGrades.SuspendLayout();
            this.tabReports.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabHome);
            this.tabControlMain.Controls.Add(this.tabStudents);
            this.tabControlMain.Controls.Add(this.tabCourses);
            this.tabControlMain.Controls.Add(this.tabGrades);
            this.tabControlMain.Controls.Add(this.tabReports);
            this.tabControlMain.Location = new System.Drawing.Point(1, 1);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1469, 907);
            this.tabControlMain.TabIndex = 3;
            // 
            // tabHome
            // 
            this.tabHome.Controls.Add(this.btnLogin);
            this.tabHome.Location = new System.Drawing.Point(4, 29);
            this.tabHome.Name = "tabHome";
            this.tabHome.Padding = new System.Windows.Forms.Padding(3);
            this.tabHome.Size = new System.Drawing.Size(1461, 874);
            this.tabHome.TabIndex = 0;
            this.tabHome.Text = "Home";
            this.tabHome.UseVisualStyleBackColor = true;
            this.tabHome.Click += new System.EventHandler(this.tabHome_Click_1);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(3, 3);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(190, 37);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click_1);
            // 
            // tabStudents
            // 
            this.tabStudents.Controls.Add(this.btnLManageStudents);
            this.tabStudents.Location = new System.Drawing.Point(4, 29);
            this.tabStudents.Name = "tabStudents";
            this.tabStudents.Padding = new System.Windows.Forms.Padding(3);
            this.tabStudents.Size = new System.Drawing.Size(1461, 874);
            this.tabStudents.TabIndex = 1;
            this.tabStudents.Text = "Students";
            this.tabStudents.UseVisualStyleBackColor = true;
            // 
            // btnLManageStudents
            // 
            this.btnLManageStudents.Location = new System.Drawing.Point(3, 6);
            this.btnLManageStudents.Name = "btnLManageStudents";
            this.btnLManageStudents.Size = new System.Drawing.Size(190, 37);
            this.btnLManageStudents.TabIndex = 0;
            this.btnLManageStudents.Text = "Manage Student";
            this.btnLManageStudents.UseVisualStyleBackColor = true;
            this.btnLManageStudents.Click += new System.EventHandler(this.btnLManageStudents_Click);
            // 
            // tabCourses
            // 
            this.tabCourses.Controls.Add(this.btnManageCourses);
            this.tabCourses.Location = new System.Drawing.Point(4, 29);
            this.tabCourses.Name = "tabCourses";
            this.tabCourses.Padding = new System.Windows.Forms.Padding(3);
            this.tabCourses.Size = new System.Drawing.Size(1461, 874);
            this.tabCourses.TabIndex = 2;
            this.tabCourses.Text = "Courses";
            this.tabCourses.UseVisualStyleBackColor = true;
            // 
            // btnManageCourses
            // 
            this.btnManageCourses.Location = new System.Drawing.Point(0, 6);
            this.btnManageCourses.Name = "btnManageCourses";
            this.btnManageCourses.Size = new System.Drawing.Size(190, 37);
            this.btnManageCourses.TabIndex = 0;
            this.btnManageCourses.Text = "Manage Courses";
            this.btnManageCourses.UseVisualStyleBackColor = true;
            this.btnManageCourses.Click += new System.EventHandler(this.btnManageCourses_Click_1);
            // 
            // tabGrades
            // 
            this.tabGrades.Controls.Add(this.btnRecordGrades);
            this.tabGrades.Location = new System.Drawing.Point(4, 29);
            this.tabGrades.Name = "tabGrades";
            this.tabGrades.Padding = new System.Windows.Forms.Padding(3);
            this.tabGrades.Size = new System.Drawing.Size(1461, 874);
            this.tabGrades.TabIndex = 3;
            this.tabGrades.Text = "Grades";
            this.tabGrades.UseVisualStyleBackColor = true;
            // 
            // btnRecordGrades
            // 
            this.btnRecordGrades.Location = new System.Drawing.Point(3, 6);
            this.btnRecordGrades.Name = "btnRecordGrades";
            this.btnRecordGrades.Size = new System.Drawing.Size(190, 37);
            this.btnRecordGrades.TabIndex = 0;
            this.btnRecordGrades.Text = "Record Grades";
            this.btnRecordGrades.UseVisualStyleBackColor = true;
            this.btnRecordGrades.Click += new System.EventHandler(this.btnRecordGrades_Click_1);
            // 
            // tabReports
            // 
            this.tabReports.Controls.Add(this.btnViewRecords);
            this.tabReports.Location = new System.Drawing.Point(4, 29);
            this.tabReports.Name = "tabReports";
            this.tabReports.Padding = new System.Windows.Forms.Padding(3);
            this.tabReports.Size = new System.Drawing.Size(1461, 874);
            this.tabReports.TabIndex = 4;
            this.tabReports.Text = "Reports";
            this.tabReports.UseVisualStyleBackColor = true;
            // 
            // btnViewRecords
            // 
            this.btnViewRecords.Location = new System.Drawing.Point(6, 6);
            this.btnViewRecords.Name = "btnViewRecords";
            this.btnViewRecords.Size = new System.Drawing.Size(190, 37);
            this.btnViewRecords.TabIndex = 0;
            this.btnViewRecords.Text = "View Reports";
            this.btnViewRecords.UseVisualStyleBackColor = true;
            this.btnViewRecords.Click += new System.EventHandler(this.btnViewRecords_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 611);
            this.Controls.Add(this.tabControlMain);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tabHome.ResumeLayout(false);
            this.tabStudents.ResumeLayout(false);
            this.tabCourses.ResumeLayout(false);
            this.tabGrades.ResumeLayout(false);
            this.tabReports.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabHome;
        private System.Windows.Forms.TabPage tabStudents;
        private System.Windows.Forms.TabPage tabCourses;
        private System.Windows.Forms.TabPage tabGrades;
        private System.Windows.Forms.TabPage tabReports;
        private System.Windows.Forms.Button btnLManageStudents;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnManageCourses;
        private System.Windows.Forms.Button btnRecordGrades;
        private System.Windows.Forms.Button btnViewRecords;
    }
}

