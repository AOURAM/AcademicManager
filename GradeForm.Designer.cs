namespace AcademicManager
{
    partial class GradeForm
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblCourseTitle = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cmbStudent = new System.Windows.Forms.ComboBox();
            this.cmbCourse = new System.Windows.Forms.ComboBox();
            this.txtGrade = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblGrade = new System.Windows.Forms.Label();
            this.dataGridViewGrades = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGrades)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(347, 92);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(104, 37);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(11, 15);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(51, 20);
            this.lblName.TabIndex = 8;
            this.lblName.Text = "Name";
            this.lblName.Click += new System.EventHandler(this.lblCourseTitle_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(457, 92);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(104, 37);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(677, 92);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 37);
            this.btnRefresh.TabIndex = 15;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblCourseTitle
            // 
            this.lblCourseTitle.AutoSize = true;
            this.lblCourseTitle.Location = new System.Drawing.Point(11, 73);
            this.lblCourseTitle.Name = "lblCourseTitle";
            this.lblCourseTitle.Size = new System.Drawing.Size(97, 20);
            this.lblCourseTitle.TabIndex = 9;
            this.lblCourseTitle.Text = "Course Title:";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(567, 92);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(104, 37);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cmbStudent
            // 
            this.cmbStudent.FormattingEnabled = true;
            this.cmbStudent.Location = new System.Drawing.Point(137, 12);
            this.cmbStudent.Name = "cmbStudent";
            this.cmbStudent.Size = new System.Drawing.Size(121, 28);
            this.cmbStudent.TabIndex = 16;
            // 
            // cmbCourse
            // 
            this.cmbCourse.FormattingEnabled = true;
            this.cmbCourse.Location = new System.Drawing.Point(137, 70);
            this.cmbCourse.Name = "cmbCourse";
            this.cmbCourse.Size = new System.Drawing.Size(121, 28);
            this.cmbCourse.TabIndex = 17;
            // 
            // txtGrade
            // 
            this.txtGrade.Location = new System.Drawing.Point(384, 14);
            this.txtGrade.Name = "txtGrade";
            this.txtGrade.Size = new System.Drawing.Size(100, 26);
            this.txtGrade.TabIndex = 18;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblGrade);
            this.panel1.Controls.Add(this.cmbStudent);
            this.panel1.Controls.Add(this.txtGrade);
            this.panel1.Controls.Add(this.cmbCourse);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.lblCourseTitle);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(801, 188);
            this.panel1.TabIndex = 19;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.Location = new System.Drawing.Point(311, 15);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(58, 20);
            this.lblGrade.TabIndex = 19;
            this.lblGrade.Text = "Grade:";
            // 
            // dataGridViewGrades
            // 
            this.dataGridViewGrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGrades.Location = new System.Drawing.Point(1, 194);
            this.dataGridViewGrades.Name = "dataGridViewGrades";
            this.dataGridViewGrades.RowHeadersWidth = 62;
            this.dataGridViewGrades.RowTemplate.Height = 28;
            this.dataGridViewGrades.Size = new System.Drawing.Size(801, 244);
            this.dataGridViewGrades.TabIndex = 20;
            this.dataGridViewGrades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGrades_CellContentClick);
            this.dataGridViewGrades.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGrades_CellClick);
            this.dataGridViewGrades.SelectionChanged += new System.EventHandler(this.dataGridViewGrades_SelectionChanged);
            this.dataGridViewGrades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewGrades.MultiSelect = false;
            // 
            // GradeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewGrades);
            this.Controls.Add(this.panel1);
            this.Name = "GradeForm";
            this.Text = "GradeForm";
            this.Load += new System.EventHandler(this.GradeForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGrades)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblCourseTitle;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cmbStudent;
        private System.Windows.Forms.ComboBox cmbCourse;
        private System.Windows.Forms.TextBox txtGrade;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.DataGridView dataGridViewGrades;
    }
}