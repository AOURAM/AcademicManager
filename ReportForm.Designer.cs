namespace AcademicManager
{
    partial class ReportForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.cmbClassName = new System.Windows.Forms.ComboBox();
            this.cmbCourseName = new System.Windows.Forms.ComboBox();
            this.lblCourseTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCourseSummary = new System.Windows.Forms.Button();
            this.btnClassSummary = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewReports = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReports)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbReportType
            // 
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Location = new System.Drawing.Point(76, 42);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(121, 28);
            this.cmbReportType.TabIndex = 17;
            // 
            // cmbClassName
            // 
            this.cmbClassName.FormattingEnabled = true;
            this.cmbClassName.Location = new System.Drawing.Point(322, 42);
            this.cmbClassName.Name = "cmbClassName";
            this.cmbClassName.Size = new System.Drawing.Size(121, 28);
            this.cmbClassName.TabIndex = 18;
            // 
            // cmbCourseName
            // 
            this.cmbCourseName.FormattingEnabled = true;
            this.cmbCourseName.Location = new System.Drawing.Point(578, 42);
            this.cmbCourseName.Name = "cmbCourseName";
            this.cmbCourseName.Size = new System.Drawing.Size(121, 28);
            this.cmbCourseName.TabIndex = 19;
            // 
            // lblCourseTitle
            // 
            this.lblCourseTitle.AutoSize = true;
            this.lblCourseTitle.Location = new System.Drawing.Point(574, 19);
            this.lblCourseTitle.Name = "lblCourseTitle";
            this.lblCourseTitle.Size = new System.Drawing.Size(64, 20);
            this.lblCourseTitle.TabIndex = 20;
            this.lblCourseTitle.Text = "Course:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(318, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "Class :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Generate Report:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnCourseSummary
            // 
            this.btnCourseSummary.Location = new System.Drawing.Point(447, 99);
            this.btnCourseSummary.Name = "btnCourseSummary";
            this.btnCourseSummary.Size = new System.Drawing.Size(196, 42);
            this.btnCourseSummary.TabIndex = 24;
            this.btnCourseSummary.Text = "Course Summary";
            this.btnCourseSummary.UseVisualStyleBackColor = true;
            this.btnCourseSummary.Click += new System.EventHandler(this.btnCourseSummary_Click);
            // 
            // btnClassSummary
            // 
            this.btnClassSummary.Location = new System.Drawing.Point(161, 99);
            this.btnClassSummary.Name = "btnClassSummary";
            this.btnClassSummary.Size = new System.Drawing.Size(196, 42);
            this.btnClassSummary.TabIndex = 23;
            this.btnClassSummary.Text = "Class Summary";
            this.btnClassSummary.UseVisualStyleBackColor = true;
            this.btnClassSummary.Click += new System.EventHandler(this.btnClassSummary_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClassSummary);
            this.panel1.Controls.Add(this.lblCourseTitle);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnCourseSummary);
            this.panel1.Controls.Add(this.cmbReportType);
            this.panel1.Controls.Add(this.cmbClassName);
            this.panel1.Controls.Add(this.cmbCourseName);
            this.panel1.Location = new System.Drawing.Point(3, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 144);
            this.panel1.TabIndex = 25;
            // 
            // dataGridViewReports
            // 
            this.dataGridViewReports.AllowUserToAddRows = false;
            this.dataGridViewReports.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGray;
            this.dataGridViewReports.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewReports.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReports.GridColor = System.Drawing.Color.Silver;
            this.dataGridViewReports.Location = new System.Drawing.Point(3, 148);
            this.dataGridViewReports.MultiSelect = false;
            this.dataGridViewReports.Name = "dataGridViewReports";
            this.dataGridViewReports.ReadOnly = true;
            this.dataGridViewReports.RowHeadersWidth = 62;
            this.dataGridViewReports.RowTemplate.Height = 28;
            this.dataGridViewReports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewReports.Size = new System.Drawing.Size(800, 313);
            this.dataGridViewReports.TabIndex = 26;
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewReports);
            this.Controls.Add(this.panel1);
            this.Name = "ReportForm";
            this.Text = "ReportForm";
            this.Load += new System.EventHandler(this.ReportForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReports)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.ComboBox cmbClassName;
        private System.Windows.Forms.ComboBox cmbCourseName;
        private System.Windows.Forms.Label lblCourseTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCourseSummary;
        private System.Windows.Forms.Button btnClassSummary;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewReports;
    }
}