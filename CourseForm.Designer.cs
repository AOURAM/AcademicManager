namespace AcademicManager
{
    partial class CourseForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblCourseTitle = new System.Windows.Forms.Label();
            this.lblHours = new System.Windows.Forms.Label();
            this.txtCourseTitle = new System.Windows.Forms.TextBox();
            this.txtHours = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridViewCourses = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCourses)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCourseTitle
            // 
            this.lblCourseTitle.AutoSize = true;
            this.lblCourseTitle.Location = new System.Drawing.Point(29, 25);
            this.lblCourseTitle.Name = "lblCourseTitle";
            this.lblCourseTitle.Size = new System.Drawing.Size(97, 20);
            this.lblCourseTitle.TabIndex = 0;
            this.lblCourseTitle.Text = "Course Title:";
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Location = new System.Drawing.Point(29, 72);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(56, 20);
            this.lblHours.TabIndex = 1;
            this.lblHours.Text = "Hours:";
            // 
            // txtCourseTitle
            // 
            this.txtCourseTitle.Location = new System.Drawing.Point(132, 22);
            this.txtCourseTitle.Name = "txtCourseTitle";
            this.txtCourseTitle.Size = new System.Drawing.Size(141, 26);
            this.txtCourseTitle.TabIndex = 2;
            // 
            // txtHours
            // 
            this.txtHours.Location = new System.Drawing.Point(132, 69);
            this.txtHours.Name = "txtHours";
            this.txtHours.Size = new System.Drawing.Size(141, 26);
            this.txtHours.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.lblCourseTitle);
            this.panel1.Controls.Add(this.txtHours);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.txtCourseTitle);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.lblHours);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 180);
            this.panel1.TabIndex = 17;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(117, 134);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(86, 36);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(240, 134);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(96, 36);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(492, 134);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(99, 36);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(365, 134);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(98, 36);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dataGridViewCourses
            // 
            this.dataGridViewCourses.AllowUserToAddRows = false;
            this.dataGridViewCourses.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.dataGridViewCourses.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewCourses.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCourses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCourses.GridColor = System.Drawing.Color.Silver;
            this.dataGridViewCourses.Location = new System.Drawing.Point(0, 180);
            this.dataGridViewCourses.MultiSelect = false;
            this.dataGridViewCourses.Name = "dataGridViewCourses";
            this.dataGridViewCourses.ReadOnly = true;
            this.dataGridViewCourses.RowHeadersWidth = 62;
            this.dataGridViewCourses.RowTemplate.Height = 28;
            this.dataGridViewCourses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCourses.Size = new System.Drawing.Size(800, 270);
            this.dataGridViewCourses.TabIndex = 18;
            this.dataGridViewCourses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridCourses_CellContentClick);
            this.dataGridViewCourses.SelectionChanged += new System.EventHandler(this.dataGridCourses_SelectionChanged);
            // 
            // CourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewCourses);
            this.Controls.Add(this.panel1);
            this.Name = "CourseForm";
            this.Text = "CourseForm";
            this.Load += new System.EventHandler(this.CourseForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCourses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCourseTitle;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.TextBox txtCourseTitle;
        private System.Windows.Forms.TextBox txtHours;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewCourses;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDelete;
    }
}