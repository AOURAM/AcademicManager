using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcademicManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void ShowChildForm(Form childForm)
        {
            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }
        private void btnManageStudents_Click(object sender, EventArgs e)
        {
            var studentForm = new StudentForm();
            ShowChildForm(studentForm);
        }

        private void btnManageCourses_Click(object sender, EventArgs e)
        {
            var courseForm = new CourseForm();
            ShowChildForm(courseForm);
        }

        private void btnRecordGrades_Click(object sender, EventArgs e)
        {
            var gradeForm = new GradeForm();
            ShowChildForm(gradeForm);
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            var reportForm = new ReportForm();
            ShowChildForm(reportForm);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (var loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Login successful — enable all tabs
                    tabCourses.Enabled = true;
                    tabStudents.Enabled = true;
                    tabGrades.Enabled = true;
                    tabReports.Enabled = true;

                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Login failed — keep tabs disabled
                    MessageBox.Show("Login failed. Access denied.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tabHome_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Disable all tabs initially
            tabStudents.Enabled = false;
            tabCourses.Enabled = false;
            tabGrades.Enabled = false;
            tabReports.Enabled = false;
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            using (var loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Login successful — enable all tabs
                    tabStudents.Enabled = true;
                    tabCourses.Enabled = true;
                    tabGrades.Enabled = true;
                    tabReports.Enabled = true;

                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Login failed — keep tabs disabled
                    MessageBox.Show("Login failed. Access denied.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLManageStudents_Click(object sender, EventArgs e)
        {
            StudentForm studentForm = new StudentForm();
            studentForm.Show();
        }

        private void btnManageCourses_Click_1(object sender, EventArgs e)
        {
            CourseForm courseForm = new CourseForm();
            courseForm.Show();
        }

        private void btnRecordGrades_Click_1(object sender, EventArgs e)
        {
            GradeForm gradeForm = new GradeForm();
            gradeForm.Show();
        }

        private void btnViewRecords_Click(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm();
            reportForm.Show();
        }

        private void tabHome_Click_1(object sender, EventArgs e)
        {

        }
    }
}
