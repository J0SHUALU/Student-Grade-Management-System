namespace StudentGradeManagementSystem
{
    /// <summary>
    /// Represents a student with their name and grade.
    /// </summary>
    public class Student
    {
        public string Name { get; set; }
        public double Grade { get; set; }

        public Student(string name, double grade)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Student name cannot be empty.");
            
            if (grade < 0 || grade > 100)
                throw new ArgumentException("Grade must be between 0 and 100.");

            Name = name;
            Grade = grade;
        }

        public override string ToString()
        {
            return $"{Name}: {Grade:F2}";
        }
    }
}
