using System;

public class Student
{
    public int StudentId { get; set; }
    public string FullName { get; set; } // Instead of "Name"
    public string Gender { get; set; }
    public int Age { get; set; }
    public string ClassName { get; set; }
    public string Major { get; set; }
    public DateTime EnrollmentDate { get; set; } // New property
}