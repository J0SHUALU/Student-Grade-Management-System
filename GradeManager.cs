namespace StudentGradeManagementSystem
{
    /// <summary>
    /// Manages student records and grade operations.
    /// Implements all core functionality for the application.
    /// </summary>
    public class GradeManager
    {
        private Dictionary<string, double> students = new Dictionary<string, double>();

        /// <summary>
        /// Adds a new student with their grade.
        /// </summary>
        public void AddStudent(string name, double grade)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Student name cannot be empty.");

            if (grade < 0 || grade > 100)
                throw new ArgumentException("Grade must be between 0 and 100.");

            if (students.ContainsKey(name))
                throw new InvalidOperationException($"Student '{name}' already exists.");

            students[name] = grade;
        }

        /// <summary>
        /// Retrieves all students and their grades.
        /// </summary>
        public Dictionary<string, double> GetAllStudents()
        {
            return new Dictionary<string, double>(students);
        }

        /// <summary>
        /// Searches for a student by name and returns their grade.
        /// </summary>
        public double SearchStudent(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Student name cannot be empty.");

            if (!students.ContainsKey(name))
                throw new KeyNotFoundException($"Student '{name}' not found.");

            return students[name];
        }

        /// <summary>
        /// Calculates the average grade of all students.
        /// </summary>
        public double CalculateAverageGrade()
        {
            if (students.Count == 0)
                throw new InvalidOperationException("No students in the system.");

            return students.Values.Average();
        }

        /// <summary>
        /// Finds the highest grade in the system.
        /// </summary>
        public double GetHighestGrade()
        {
            if (students.Count == 0)
                throw new InvalidOperationException("No students in the system.");

            return students.Values.Max();
        }

        /// <summary>
        /// Finds the lowest grade in the system.
        /// </summary>
        public double GetLowestGrade()
        {
            if (students.Count == 0)
                throw new InvalidOperationException("No students in the system.");

            return students.Values.Min();
        }

        /// <summary>
        /// Gets the student with the highest grade.
        /// </summary>
        public string GetTopStudent()
        {
            if (students.Count == 0)
                throw new InvalidOperationException("No students in the system.");

            return students.OrderByDescending(x => x.Value).First().Key;
        }

        /// <summary>
        /// Gets the student with the lowest grade.
        /// </summary>
        public string GetBottomStudent()
        {
            if (students.Count == 0)
                throw new InvalidOperationException("No students in the system.");

            return students.OrderBy(x => x.Value).First().Key;
        }

        /// <summary>
        /// Determines the grade category for a given grade.
        /// </summary>
        public GradeCategory GetGradeCategory(double grade)
        {
            if (grade >= 90)
                return GradeCategory.Excellent;
            else if (grade >= 80)
                return GradeCategory.Good;
            else if (grade >= 70)
                return GradeCategory.Satisfactory;
            else if (grade >= 60)
                return GradeCategory.Passing;
            else
                return GradeCategory.Failing;
        }

        /// <summary>
        /// Gets the total number of students.
        /// </summary>
        public int GetStudentCount()
        {
            return students.Count;
        }

        /// <summary>
        /// Removes a student from the system.
        /// </summary>
        public void RemoveStudent(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Student name cannot be empty.");

            if (!students.Remove(name))
                throw new KeyNotFoundException($"Student '{name}' not found.");
        }

        /// <summary>
        /// Updates a student's grade.
        /// </summary>
        public void UpdateStudentGrade(string name, double newGrade)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Student name cannot be empty.");

            if (newGrade < 0 || newGrade > 100)
                throw new ArgumentException("Grade must be between 0 and 100.");

            if (!students.ContainsKey(name))
                throw new KeyNotFoundException($"Student '{name}' not found.");

            students[name] = newGrade;
        }

        /// <summary>
        /// Clears all student records.
        /// </summary>
        public void ClearAllStudents()
        {
            students.Clear();
        }
    }
}
