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
 
    public partial class CourseForm : Form
    {
        private int selectedCourseId = 0;
        public CourseForm()
        {
            InitializeComponent();
        }

        private void CourseForm_Load(object sender, EventArgs e)
        {
            LoadCourses();
        }
        private void LoadCourses()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT CourseId, CourseTitle, Hours FROM Courses";
                    var adapter = new MySqlDataAdapter(query, conn);
                    var table = new DataTable();
                    adapter.Fill(table);
                    dataGridViewCourses.DataSource = table;

                    // Optional: Hide CourseId column
                    if (dataGridViewCourses.Columns.Contains("CourseId"))
                        dataGridViewCourses.Columns["CourseId"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading courses: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCourseTitle.Text))
            {
                MessageBox.Show("Course Title is required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtHours.Text, out int hours) || hours <= 0)
            {
                MessageBox.Show("Hours must be a positive number!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                INSERT INTO Courses (CourseTitle, Hours)
                VALUES (@title, @hours)";

                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@title", txtCourseTitle.Text);
                    cmd.Parameters.AddWithValue("@hours", hours);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Course added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCourses(); // Refresh grid
                    ClearFields(); // Optional: clear inputs
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding course: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedCourseId == 0)
            {
                MessageBox.Show("Please select a course to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtHours.Text, out int hours) || hours <= 0)
            {
                MessageBox.Show("Hours must be a positive number!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                UPDATE Courses SET 
                CourseTitle = @title, Hours = @hours
                WHERE CourseId = @id";

                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@title", txtCourseTitle.Text);
                    cmd.Parameters.AddWithValue("@hours", hours);
                    cmd.Parameters.AddWithValue("@id", selectedCourseId);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Course updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCourses();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating course: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedCourseId == 0)
            {
                MessageBox.Show("Please select a course to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this course?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM Courses WHERE CourseId = @id";
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", selectedCourseId);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Course deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCourses();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting course: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCourses();
            ClearFields();
        }
        private void ClearFields()
        {
            txtCourseTitle.Clear();
            txtHours.Clear();
            selectedCourseId = 0;
        }

        private void dataGridCourses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void dataGridCourses_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewCourses.SelectedRows.Count > 0)
            {
                var row = dataGridViewCourses.SelectedRows[0];
                selectedCourseId = Convert.ToInt32(row.Cells["CourseId"].Value);
                txtCourseTitle.Text = row.Cells["CourseTitle"].Value?.ToString();
                txtHours.Text = row.Cells["Hours"].Value?.ToString();
            }

        }
    }
}
