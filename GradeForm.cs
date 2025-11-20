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
    public partial class GradeForm : Form
    {
        private int selectedScoreId = 0;

        public GradeForm()
        {
            InitializeComponent();
            // Set up DataGridView properties
            dataGridViewGrades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewGrades.MultiSelect = false;
            dataGridViewGrades.ReadOnly = true;
        }

        private void lblCourseTitle_Click(object sender, EventArgs e)
        {
            // Empty method
        }

        private void LoadStudents()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT StudentId, Name FROM Students";
                    var adapter = new MySqlDataAdapter(query, conn);
                    var table = new DataTable();
                    adapter.Fill(table);

                    cmbStudent.DisplayMember = "Name";
                    cmbStudent.ValueMember = "StudentId";
                    cmbStudent.DataSource = table;
                    cmbStudent.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading students: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCourses()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT CourseId, CourseTitle FROM Courses";
                    var adapter = new MySqlDataAdapter(query, conn);
                    var table = new DataTable();
                    adapter.Fill(table);

                    cmbCourse.DisplayMember = "CourseTitle";
                    cmbCourse.ValueMember = "CourseId";
                    cmbCourse.DataSource = table;
                    cmbCourse.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading courses: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GradeForm_Load(object sender, EventArgs e)
        {
            LoadStudents();
            LoadCourses();
            LoadGrades();
        }

        private void LoadGrades()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                    SELECT s.ScoreId, st.StudentId, c.CourseId, 
                           st.Name AS StudentName, c.CourseTitle AS Course, s.Marks AS Grade
                    FROM Scores s
                    JOIN Students st ON s.StudentId = st.StudentId
                    JOIN Courses c ON s.CourseId = c.CourseId
                    ORDER BY st.Name, c.CourseTitle";

                    var adapter = new MySqlDataAdapter(query, conn);
                    var table = new DataTable();
                    adapter.Fill(table);
                    dataGridViewGrades.DataSource = table;

                    // Set column headers
                    if (dataGridViewGrades.Columns.Contains("StudentName"))
                        dataGridViewGrades.Columns["StudentName"].HeaderText = "Student Name";
                    if (dataGridViewGrades.Columns.Contains("Course"))
                        dataGridViewGrades.Columns["Course"].HeaderText = "Course";
                    if (dataGridViewGrades.Columns.Contains("Grade"))
                        dataGridViewGrades.Columns["Grade"].HeaderText = "Grade";

                    // Hide ID columns
                    if (dataGridViewGrades.Columns.Contains("ScoreId"))
                        dataGridViewGrades.Columns["ScoreId"].Visible = false;
                    if (dataGridViewGrades.Columns.Contains("StudentId"))
                        dataGridViewGrades.Columns["StudentId"].Visible = false;
                    if (dataGridViewGrades.Columns.Contains("CourseId"))
                        dataGridViewGrades.Columns["CourseId"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading grades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbStudent.SelectedValue == null)
            {
                MessageBox.Show("Please select a student.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbCourse.SelectedValue == null)
            {
                MessageBox.Show("Please select a course.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(txtGrade.Text, out double grade) || grade < 0 || grade > 100)
            {
                MessageBox.Show("Grade must be a number between 0 and 100.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                    INSERT INTO Scores (StudentId, CourseId, Marks)
                    VALUES (@studentId, @courseId, @grade)";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@studentId", cmbStudent.SelectedValue);
                        cmd.Parameters.AddWithValue("@courseId", cmbCourse.SelectedValue);
                        cmd.Parameters.AddWithValue("@grade", grade);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Grade added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadGrades();
                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("No grade was added.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding grade: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedScoreId == 0)
            {
                MessageBox.Show("Please select a grade to update.\nClick on a row in the table first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbStudent.SelectedValue == null)
            {
                MessageBox.Show("Please select a student.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbCourse.SelectedValue == null)
            {
                MessageBox.Show("Please select a course.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(txtGrade.Text, out double grade) || grade < 0 || grade > 100)
            {
                MessageBox.Show("Grade must be a number between 0 and 100.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                    UPDATE Scores SET 
                    StudentId = @studentId, CourseId = @courseId, Marks = @grade
                    WHERE ScoreId = @id";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@studentId", cmbStudent.SelectedValue);
                        cmd.Parameters.AddWithValue("@courseId", cmbCourse.SelectedValue);
                        cmd.Parameters.AddWithValue("@grade", grade);
                        cmd.Parameters.AddWithValue("@id", selectedScoreId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Grade updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadGrades();
                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("No grade was updated.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating grade: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedScoreId == 0)
            {
                MessageBox.Show("Please select a grade to delete.\nClick on a row in the table first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                $"Are you sure you want to delete this grade?\nStudent: {cmbStudent.Text}\nCourse: {cmbCourse.Text}\nGrade: {txtGrade.Text}",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM Scores WHERE ScoreId = @id";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedScoreId);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Grade deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadGrades();
                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("No grade was deleted.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting grade: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadGrades();
            ClearFields();
        }

        private void ClearFields()
        {
            cmbStudent.SelectedIndex = -1;
            cmbCourse.SelectedIndex = -1;
            txtGrade.Clear();
            selectedScoreId = 0;
        }

        // FIXED: This method handles row selection
        private void dataGridViewGrades_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewGrades.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow row = dataGridViewGrades.SelectedRows[0];

                    // Get the ScoreId from the hidden column
                    if (row.Cells["ScoreId"].Value != null && row.Cells["ScoreId"].Value != DBNull.Value)
                    {
                        selectedScoreId = Convert.ToInt32(row.Cells["ScoreId"].Value);
                    }

                    // Get StudentId and set ComboBox
                    if (row.Cells["StudentId"].Value != null && row.Cells["StudentId"].Value != DBNull.Value)
                    {
                        int studentId = Convert.ToInt32(row.Cells["StudentId"].Value);
                        cmbStudent.SelectedValue = studentId;
                    }

                    // Get CourseId and set ComboBox
                    if (row.Cells["CourseId"].Value != null && row.Cells["CourseId"].Value != DBNull.Value)
                    {
                        int courseId = Convert.ToInt32(row.Cells["CourseId"].Value);
                        cmbCourse.SelectedValue = courseId;
                    }

                    // Get Grade
                    if (row.Cells["Grade"].Value != null && row.Cells["Grade"].Value != DBNull.Value)
                    {
                        txtGrade.Text = row.Cells["Grade"].Value.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error selecting grade: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Alternative selection method - handle cell clicks
        private void dataGridViewGrades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Only handle clicks on valid rows (not header)
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dataGridViewGrades.Rows[e.RowIndex];

                    // Get the ScoreId from the hidden column
                    if (row.Cells["ScoreId"].Value != null && row.Cells["ScoreId"].Value != DBNull.Value)
                    {
                        selectedScoreId = Convert.ToInt32(row.Cells["ScoreId"].Value);
                    }

                    // Get StudentId and set ComboBox
                    if (row.Cells["StudentId"].Value != null && row.Cells["StudentId"].Value != DBNull.Value)
                    {
                        int studentId = Convert.ToInt32(row.Cells["StudentId"].Value);
                        cmbStudent.SelectedValue = studentId;
                    }

                    // Get CourseId and set ComboBox
                    if (row.Cells["CourseId"].Value != null && row.Cells["CourseId"].Value != DBNull.Value)
                    {
                        int courseId = Convert.ToInt32(row.Cells["CourseId"].Value);
                        cmbCourse.SelectedValue = courseId;
                    }

                    // Get Grade
                    if (row.Cells["Grade"].Value != null && row.Cells["Grade"].Value != DBNull.Value)
                    {
                        txtGrade.Text = row.Cells["Grade"].Value.ToString();
                    }

                    // Ensure the row is visually selected
                    dataGridViewGrades.ClearSelection();
                    row.Selected = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error selecting grade: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Empty method - required for panel rendering
        }

        // Keep this method but make it call the CellClick method
        private void dataGridViewGrades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewGrades_CellClick(sender, e);
        }

        // DEBUG METHOD: Add this temporary button to test selection
        private void btnDebugSelection_Click(object sender, EventArgs e)
        {
            if (dataGridViewGrades.SelectedRows.Count > 0)
            {
                var row = dataGridViewGrades.SelectedRows[0];
                string debugInfo = $"Selected ScoreId: {selectedScoreId}\n";
                debugInfo += $"StudentId: {row.Cells["StudentId"].Value}\n";
                debugInfo += $"CourseId: {row.Cells["CourseId"].Value}\n";
                debugInfo += $"Grade: {row.Cells["Grade"].Value}";
                MessageBox.Show(debugInfo, "Debug Info");
            }
            else
            {
                MessageBox.Show("No row selected", "Debug Info");
            }
        }
    }
}