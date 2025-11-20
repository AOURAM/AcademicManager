using MySql.Data.MySqlClient;
using StudentInfoSystem;
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
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            LoadClassNames();
            LoadCourseNames();
        }
        private void LoadClassNames()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT DISTINCT ClassName FROM Students ORDER BY ClassName";
                    var adapter = new MySqlDataAdapter(query, conn);
                    var table = new DataTable();
                    adapter.Fill(table);

                    cmbClassName.DisplayMember = "ClassName";
                    cmbClassName.ValueMember = "ClassName";
                    cmbClassName.DataSource = table;

                    // Optional: Add empty item
                    cmbClassName.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading classes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadCourseNames()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT CourseId, CourseTitle FROM Courses ORDER BY CourseTitle";
                    var adapter = new MySqlDataAdapter(query, conn);
                    var table = new DataTable();
                    adapter.Fill(table);

                    cmbCourseName.DisplayMember = "CourseTitle";
                    cmbCourseName.ValueMember = "CourseId";
                    cmbCourseName.DataSource = table;

                    // Optional: Add empty item
                    cmbCourseName.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading courses: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClassSummary_Click(object sender, EventArgs e)
        {
            if (cmbClassName.SelectedValue == null)
            {
                MessageBox.Show("Please select a class.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string className = cmbClassName.SelectedValue.ToString();

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                SELECT s.ClassName, AVG(sc.Marks) AS AvgGrade, COUNT(sc.ScoreId) AS StudentCount
                FROM Students s
                JOIN Scores sc ON s.StudentId = sc.StudentId
                WHERE s.ClassName = @className
                GROUP BY s.ClassName";

                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@className", className);

                    var adapter = new MySqlDataAdapter(cmd);
                    var table = new DataTable();
                    adapter.Fill(table);
                    dataGridViewReports.DataSource = table;

                    // Optional: Set column headers
                    if (dataGridViewReports.Columns.Contains("ClassName"))
                        dataGridViewReports.Columns["ClassName"].HeaderText = "Class";
                    if (dataGridViewReports.Columns.Contains("AvgGrade"))
                        dataGridViewReports.Columns["AvgGrade"].HeaderText = "Average Grade";
                    if (dataGridViewReports.Columns.Contains("StudentCount"))
                        dataGridViewReports.Columns["StudentCount"].HeaderText = "Students";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating class summary: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCourseSummary_Click(object sender, EventArgs e)
        {
            if (cmbCourseName.SelectedValue == null)
            {
                MessageBox.Show("Please select a course.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int courseId = Convert.ToInt32(cmbCourseName.SelectedValue);

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                SELECT c.CourseTitle, AVG(sc.Marks) AS AvgGrade, COUNT(sc.ScoreId) AS StudentCount
                FROM Courses c
                JOIN Scores sc ON c.CourseId = sc.CourseId
                WHERE c.CourseId = @courseId
                GROUP BY c.CourseTitle";

                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@courseId", courseId);

                    var adapter = new MySqlDataAdapter(cmd);
                    var table = new DataTable();
                    adapter.Fill(table);
                    dataGridViewReports.DataSource = table;

                    // Optional: Set column headers
                    if (dataGridViewReports.Columns.Contains("CourseTitle"))
                        dataGridViewReports.Columns["CourseTitle"].HeaderText = "Course";
                    if (dataGridViewReports.Columns.Contains("AvgGrade"))
                        dataGridViewReports.Columns["AvgGrade"].HeaderText = "Average Grade";
                    if (dataGridViewReports.Columns.Contains("StudentCount"))
                        dataGridViewReports.Columns["StudentCount"].HeaderText = "Students";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating course summary: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ClearFields()
        {
            cmbClassName.SelectedIndex = -1;
            cmbCourseName.SelectedIndex = -1;
            dataGridViewReports.DataSource = null;
        }
    }
}
