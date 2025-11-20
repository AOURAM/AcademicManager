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
    public partial class StudentForm : Form
    {
        private int selectedStudentId = 0;

        public StudentForm()
        {
            InitializeComponent();
            // Set up DataGridView properties
            dataGridViewStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewStudents.MultiSelect = false;
            dataGridViewStudents.ReadOnly = true;
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void LoadStudents()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT StudentId, Name, Gender, Age, ClassName, Major FROM Students";
                    var adapter = new MySqlDataAdapter(query, conn);
                    var table = new DataTable();
                    adapter.Fill(table);
                    dataGridViewStudents.DataSource = table;

                    // Optional: Hide StudentId column
                    if (dataGridViewStudents.Columns.Contains("StudentId"))
                        dataGridViewStudents.Columns["StudentId"].Visible = false;

                    // Load gender combo box items only once
                    if (cmbGender.Items.Count == 0)
                    {
                        cmbGender.Items.AddRange(new object[] { "Male", "Female", "Other" });
                        cmbGender.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading students: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // This method can be empty
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Leave this method empty - it's for visual rendering
            // Do NOT throw NotImplementedException here
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 🔹 Validation
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Name is required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbGender.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a gender.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtAge.Text, out int age) || age < 10 || age > 50)
            {
                MessageBox.Show("Age must be between 10 and 50.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        INSERT INTO Students (Name, Gender, Age, ClassName, Major)
                        VALUES (@name, @gender, @age, @class, @major)";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@gender", cmbGender.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@age", age);
                        cmd.Parameters.AddWithValue("@class", txtClassName.Text ?? "");
                        cmd.Parameters.AddWithValue("@major", txtMajor.Text ?? "");

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("✅ Student added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadStudents(); // Refresh grid
                            ClearFields();  // Reset form
                        }
                        else
                        {
                            MessageBox.Show("⚠️ No rows were inserted.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Database Error:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewStudents_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewStudents.SelectedRows.Count > 0 && dataGridViewStudents.SelectedRows[0].Index >= 0)
            {
                try
                {
                    var row = dataGridViewStudents.SelectedRows[0];
                    selectedStudentId = Convert.ToInt32(row.Cells["StudentId"].Value);
                    txtName.Text = row.Cells["Name"].Value?.ToString();

                    // Set gender safely
                    string gender = row.Cells["Gender"].Value?.ToString();
                    if (!string.IsNullOrEmpty(gender))
                    {
                        cmbGender.SelectedItem = gender;
                    }

                    txtAge.Text = row.Cells["Age"].Value?.ToString();
                    txtClassName.Text = row.Cells["ClassName"].Value?.ToString();
                    txtMajor.Text = row.Cells["Major"].Value?.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error selecting student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedStudentId == 0)
            {
                MessageBox.Show("Please select a student to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 🔹 Validation
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Name is required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbGender.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a gender.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtAge.Text, out int age) || age < 10 || age > 50)
            {
                MessageBox.Show("Age must be between 10 and 50.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        UPDATE Students SET 
                        Name = @name, Gender = @gender, Age = @age, ClassName = @class, Major = @major
                        WHERE StudentId = @id";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@gender", cmbGender.SelectedItem?.ToString() ?? "Other");
                        cmd.Parameters.AddWithValue("@age", age);
                        cmd.Parameters.AddWithValue("@class", txtClassName.Text);
                        cmd.Parameters.AddWithValue("@major", txtMajor.Text);
                        cmd.Parameters.AddWithValue("@id", selectedStudentId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Student updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadStudents();
                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("No student was updated.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedStudentId == 0)
            {
                MessageBox.Show("Please select a student to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this student?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM Students WHERE StudentId = @id";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedStudentId);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Student deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadStudents();
                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("No student was deleted.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStudents();
            ClearFields();
        }

        private void ClearFields()
        {
            txtName.Clear();
            cmbGender.SelectedIndex = -1;
            txtAge.Clear();
            txtClassName.Clear();
            txtMajor.Clear();
            selectedStudentId = 0;
        }

        private void cmbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            // This method can be empty
        }

        private void dataGridViewStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell clicks as alternative selection method
            if (e.RowIndex >= 0)
            {
                try
                {
                    var row = dataGridViewStudents.Rows[e.RowIndex];
                    selectedStudentId = Convert.ToInt32(row.Cells["StudentId"].Value);
                    txtName.Text = row.Cells["Name"].Value?.ToString();

                    // Set gender safely using IndexOf
                    string gender = row.Cells["Gender"].Value?.ToString();
                    if (!string.IsNullOrEmpty(gender))
                    {
                        int index = cmbGender.Items.IndexOf(gender);
                        if (index >= 0)
                        {
                            cmbGender.SelectedIndex = index;
                        }
                    }

                    txtAge.Text = row.Cells["Age"].Value?.ToString();
                    txtClassName.Text = row.Cells["ClassName"].Value?.ToString();
                    txtMajor.Text = row.Cells["Major"].Value?.ToString();

                    // Clear any previous selection and select this row
                    dataGridViewStudents.ClearSelection();
                    row.Selected = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error selecting student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtClassName_TextChanged(object sender, EventArgs e)
        {
            // This method can be empty
        }

        // Additional method to handle cell clicks for better selection
        private void dataGridViewStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    var row = dataGridViewStudents.Rows[e.RowIndex];
                    selectedStudentId = Convert.ToInt32(row.Cells["StudentId"].Value);
                    txtName.Text = row.Cells["Name"].Value?.ToString();

                    // Set gender safely
                    string gender = row.Cells["Gender"].Value?.ToString();
                    if (!string.IsNullOrEmpty(gender))
                    {
                        cmbGender.SelectedItem = gender;
                    }

                    txtAge.Text = row.Cells["Age"].Value?.ToString();
                    txtClassName.Text = row.Cells["ClassName"].Value?.ToString();
                    txtMajor.Text = row.Cells["Major"].Value?.ToString();

                    // Ensure the row is selected
                    dataGridViewStudents.ClearSelection();
                    row.Selected = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error selecting student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}