namespace StudentGradeManagementSystem
{
    /// <summary>
    /// Console-based user interface for the Student Grade Management System.
    /// Provides a menu-driven interface with formatted output and error handling.
    /// </summary>
    public class ConsoleUI
    {
        private GradeManager gradeManager = new GradeManager();

        /// <summary>
        /// Runs the main application loop.
        /// </summary>
        public void Run()
        {
            DisplayHeader();

            while (true)
            {
                try
                {
                    DisplayMenu();
                    Console.Write("Select an option (1-9): ");
                    string? input = Console.ReadLine();

                    if (!int.TryParse(input, out int choice))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 9.");
                        Console.ResetColor();
                        continue;
                    }

                    switch (choice)
                    {
                        case 1:
                            AddStudent();
                            break;
                        case 2:
                            DisplayAllStudents();
                            break;
                        case 3:
                            SearchStudent();
                            break;
                        case 4:
                            CalculateAverage();
                            break;
                        case 5:
                            FindHighestLowest();
                            break;
                        case 6:
                            UpdateStudentGrade();
                            break;
                        case 7:
                            RemoveStudent();
                            break;
                        case 8:
                            ShowStatistics();
                            break;
                        case 9:
                            Console.WriteLine("Thank you for using Student Grade Management System!");
                            return;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid option. Please select 1-9.");
                            Console.ResetColor();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.ResetColor();
                }
            }
        }

        /// <summary>
        /// Displays the application header.
        /// </summary>
        private void DisplayHeader()
        {
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║   Student Grade Management System - Console Application    ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
        }

        /// <summary>
        /// Displays the main menu options.
        /// </summary>
        private void DisplayMenu()
        {
            Console.WriteLine("┌─ Main Menu ─────────────────────────────────────────────────┐");
            Console.WriteLine("│ 1. Add a Student                                            │");
            Console.WriteLine("│ 2. Display All Students                                     │");
            Console.WriteLine("│ 3. Search for a Student                                     │");
            Console.WriteLine("│ 4. Calculate Average Grade                                  │");
            Console.WriteLine("│ 5. Find Highest and Lowest Grades                           │");
            Console.WriteLine("│ 6. Update Student Grade                                     │");
            Console.WriteLine("│ 7. Remove a Student                                         │");
            Console.WriteLine("│ 8. Show Statistics                                          │");
            Console.WriteLine("│ 9. Exit                                                     │");
            Console.WriteLine("└─────────────────────────────────────────────────────────────┘");
        }

        /// <summary>
        /// Adds a new student to the system.
        /// </summary>
        private void AddStudent()
        {
            Console.WriteLine("\n┌─ Add Student ───────────────────────────────────────────────┐");
            Console.Write("│ Enter student name: ");
            string? name = Console.ReadLine();

            Console.Write("│ Enter grade (0-100): ");
            if (!double.TryParse(Console.ReadLine(), out double grade))
            {
                throw new ArgumentException("Invalid grade. Please enter a number between 0 and 100.");
            }

            gradeManager.AddStudent(name!, grade);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"│ ✓ Student '{name}' added successfully!");
            Console.ResetColor();
            Console.WriteLine("└─────────────────────────────────────────────────────────────┘");
        }

        /// <summary>
        /// Displays all students and their grades.
        /// </summary>
        private void DisplayAllStudents()
        {
            Console.WriteLine("\n┌─ All Students ──────────────────────────────────────────────┐");
            var students = gradeManager.GetAllStudents();

            if (students.Count == 0)
            {
                Console.WriteLine("│ No students in the system.                                  │");
            }
            else
            {
                var sortedStudents = students.OrderByDescending(x => x.Value);
                foreach (var student in sortedStudents)
                {
                    GradeCategory category = gradeManager.GetGradeCategory(student.Value);
                    Console.WriteLine($"│ {student.Key,-30} {student.Value,6:F2}  ({category,-12})│");
                }
            }
            Console.WriteLine("└─────────────────────────────────────────────────────────────┘");
        }

        /// <summary>
        /// Searches for a specific student.
        /// </summary>
        private void SearchStudent()
        {
            Console.WriteLine("\n┌─ Search Student ────────────────────────────────────────────┐");
            Console.Write("│ Enter student name to search: ");
            string? name = Console.ReadLine();

            double grade = gradeManager.SearchStudent(name!);
            GradeCategory category = gradeManager.GetGradeCategory(grade);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"│ ✓ Student found!                                            │");
            Console.ResetColor();
            Console.WriteLine($"│ Name: {name,-50}│");
            Console.WriteLine($"│ Grade: {grade:F2,-48}│");
            Console.WriteLine($"│ Category: {category,-44}│");
            Console.WriteLine("└─────────────────────────────────────────────────────────────┘");
        }

        /// <summary>
        /// Calculates and displays the average grade.
        /// </summary>
        private void CalculateAverage()
        {
            Console.WriteLine("\n┌─ Average Grade ─────────────────────────────────────────────┐");
            double average = gradeManager.CalculateAverageGrade();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"│ Average Grade: {average:F2,-42}│");
            Console.ResetColor();
            Console.WriteLine("└─────────────────────────────────────────────────────────────┘");
        }

        /// <summary>
        /// Finds and displays the highest and lowest grades.
        /// </summary>
        private void FindHighestLowest()
        {
            Console.WriteLine("\n┌─ Highest and Lowest Grades ────────────────────────────────┐");
            double highest = gradeManager.GetHighestGrade();
            double lowest = gradeManager.GetLowestGrade();
            string topStudent = gradeManager.GetTopStudent();
            string bottomStudent = gradeManager.GetBottomStudent();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"│ Highest Grade: {highest:F2,-41}│");
            Console.WriteLine($"│ Student: {topStudent,-48}│");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"│ Lowest Grade: {lowest:F2,-42}│");
            Console.WriteLine($"│ Student: {bottomStudent,-48}│");
            Console.ResetColor();
            Console.WriteLine("└─────────────────────────────────────────────────────────────┘");
        }

        /// <summary>
        /// Updates a student's grade.
        /// </summary>
        private void UpdateStudentGrade()
        {
            Console.WriteLine("\n┌─ Update Student Grade ──────────────────────────────────────┐");
            Console.Write("│ Enter student name: ");
            string? name = Console.ReadLine();

            Console.Write("│ Enter new grade (0-100): ");
            if (!double.TryParse(Console.ReadLine(), out double newGrade))
            {
                throw new ArgumentException("Invalid grade. Please enter a number between 0 and 100.");
            }

            gradeManager.UpdateStudentGrade(name!, newGrade);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"│ ✓ Student '{name}' grade updated to {newGrade:F2}!");
            Console.ResetColor();
            Console.WriteLine("└─────────────────────────────────────────────────────────────┘");
        }

        /// <summary>
        /// Removes a student from the system.
        /// </summary>
        private void RemoveStudent()
        {
            Console.WriteLine("\n┌─ Remove Student ────────────────────────────────────────────┐");
            Console.Write("│ Enter student name to remove: ");
            string? name = Console.ReadLine();

            Console.Write($"│ Are you sure you want to remove '{name}'? (y/n): ");
            string? confirm = Console.ReadLine();

            if (confirm?.ToLower() == "y")
            {
                gradeManager.RemoveStudent(name!);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"│ ✓ Student '{name}' removed successfully!");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("│ Operation cancelled.");
            }
            Console.WriteLine("└─────────────────────────────────────────────────────────────┘");
        }

        /// <summary>
        /// Displays comprehensive statistics about all students.
        /// </summary>
        private void ShowStatistics()
        {
            Console.WriteLine("\n┌─ Statistics ────────────────────────────────────────────────┐");
            int count = gradeManager.GetStudentCount();
            
            if (count == 0)
            {
                Console.WriteLine("│ No students in the system.                                  │");
            }
            else
            {
                double average = gradeManager.CalculateAverageGrade();
                double highest = gradeManager.GetHighestGrade();
                double lowest = gradeManager.GetLowestGrade();
                string topStudent = gradeManager.GetTopStudent();
                string bottomStudent = gradeManager.GetBottomStudent();

                Console.WriteLine($"│ Total Students: {count,-44}│");
                Console.WriteLine($"│ Average Grade: {average:F2,-42}│");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"│ Highest Grade: {highest:F2} ({topStudent}){new string(' ', 60 - topStudent.Length - 20)}│");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"│ Lowest Grade: {lowest:F2} ({bottomStudent}){new string(' ', 61 - bottomStudent.Length - 19)}│");
                Console.ResetColor();
            }
            Console.WriteLine("└─────────────────────────────────────────────────────────────┘");
        }
    }
}
