namespace StudentGradeManagementSystem
{
    /// <summary>
    /// Windows Forms GUI for Student Grade Management System.
    /// Provides a user-friendly graphical interface for managing student records.
    /// </summary>
    public partial class MainForm : Form
    {
        private GradeManager gradeManager = new GradeManager();

        public MainForm()
        {
            InitializeComponent();
            this.Text = "Student Grade Management System";
            this.Size = new Size(900, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(240, 240, 240);
            CreateUI();
        }

        private void CreateUI()
        {
            // Title Label
            Label titleLabel = new Label
            {
                Text = "Student Grade Management System",
                Font = new Font("Arial", 18, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 102, 204),
                AutoSize = true,
                Location = new Point(20, 20)
            };
            this.Controls.Add(titleLabel);

            // Main Panel with Tabs
            TabControl tabControl = new TabControl
            {
                Location = new Point(20, 60),
                Size = new Size(850, 600),
                Font = new Font("Arial", 10)
            };

            // Tab 1: Add Student
            TabPage addStudentTab = CreateAddStudentTab();
            tabControl.TabPages.Add(addStudentTab);

            // Tab 2: View Students
            TabPage viewStudentsTab = CreateViewStudentsTab();
            tabControl.TabPages.Add(viewStudentsTab);

            // Tab 3: Search Student
            TabPage searchTab = CreateSearchTab();
            tabControl.TabPages.Add(searchTab);

            // Tab 4: Statistics
            TabPage statsTab = CreateStatisticsTab();
            tabControl.TabPages.Add(statsTab);

            // Tab 5: Manage Grades
            TabPage manageTab = CreateManageGradesTab();
            tabControl.TabPages.Add(manageTab);

            this.Controls.Add(tabControl);
        }

        private TabPage CreateAddStudentTab()
        {
            TabPage tab = new TabPage("Add Student");
            tab.BackColor = Color.White;

            Label nameLabel = new Label { Text = "Student Name:", Location = new Point(20, 20), AutoSize = true };
            TextBox nameTextBox = new TextBox { Location = new Point(150, 20), Size = new Size(300, 25) };

            Label gradeLabel = new Label { Text = "Grade (0-100):", Location = new Point(20, 70), AutoSize = true };
            TextBox gradeTextBox = new TextBox { Location = new Point(150, 70), Size = new Size(300, 25) };

            Button addButton = new Button
            {
                Text = "Add Student",
                Location = new Point(150, 120),
                Size = new Size(120, 35),
                BackColor = Color.FromArgb(0, 153, 76),
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            Label resultLabel = new Label
            {
                Location = new Point(20, 170),
                Size = new Size(400, 100),
                AutoSize = false,
                Text = "",
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(5)
            };

            addButton.Click += (s, e) =>
            {
                try
                {
                    string name = nameTextBox.Text;
                    if (!double.TryParse(gradeTextBox.Text, out double grade))
                    {
                        resultLabel.Text = "Error: Please enter a valid grade number.";
                        resultLabel.ForeColor = Color.Red;
                        return;
                    }

                    gradeManager.AddStudent(name, grade);
                    resultLabel.Text = $"✓ Student '{name}' added successfully with grade {grade:F2}!";
                    resultLabel.ForeColor = Color.Green;
                    nameTextBox.Clear();
                    gradeTextBox.Clear();
                }
                catch (Exception ex)
                {
                    resultLabel.Text = $"Error: {ex.Message}";
                    resultLabel.ForeColor = Color.Red;
                }
            };

            tab.Controls.Add(nameLabel);
            tab.Controls.Add(nameTextBox);
            tab.Controls.Add(gradeLabel);
            tab.Controls.Add(gradeTextBox);
            tab.Controls.Add(addButton);
            tab.Controls.Add(resultLabel);

            return tab;
        }

        private TabPage CreateViewStudentsTab()
        {
            TabPage tab = new TabPage("View All Students");
            tab.BackColor = Color.White;

            DataGridView dataGridView = new DataGridView
            {
                Location = new Point(20, 20),
                Size = new Size(750, 450),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
                ReadOnly = true,
                AllowUserToAddRows = false,
                BackgroundColor = Color.White
            };

            dataGridView.Columns.Add("Name", "Student Name");
            dataGridView.Columns.Add("Grade", "Grade");
            dataGridView.Columns.Add("Category", "Grade Category");

            Button refreshButton = new Button
            {
                Text = "Refresh",
                Location = new Point(20, 480),
                Size = new Size(100, 35),
                BackColor = Color.FromArgb(0, 102, 204),
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            refreshButton.Click += (s, e) =>
            {
                dataGridView.Rows.Clear();
                var students = gradeManager.GetAllStudents();
                var sortedStudents = students.OrderByDescending(x => x.Value);

                foreach (var student in sortedStudents)
                {
                    GradeCategory category = gradeManager.GetGradeCategory(student.Value);
                    dataGridView.Rows.Add(student.Key, $"{student.Value:F2}", category.ToString());
                }
            };

            tab.Controls.Add(dataGridView);
            tab.Controls.Add(refreshButton);

            return tab;
        }

        private TabPage CreateSearchTab()
        {
            TabPage tab = new TabPage("Search Student");
            tab.BackColor = Color.White;

            Label searchLabel = new Label { Text = "Enter Student Name:", Location = new Point(20, 20), AutoSize = true };
            TextBox searchTextBox = new TextBox { Location = new Point(200, 20), Size = new Size(300, 25) };

            Button searchButton = new Button
            {
                Text = "Search",
                Location = new Point(200, 70),
                Size = new Size(100, 35),
                BackColor = Color.FromArgb(0, 102, 204),
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            Label resultLabel = new Label
            {
                Location = new Point(20, 120),
                Size = new Size(700, 300),
                AutoSize = false,
                Text = "Search results will appear here",
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(10),
                Font = new Font("Arial", 11)
            };

            searchButton.Click += (s, e) =>
            {
                try
                {
                    string name = searchTextBox.Text;
                    double grade = gradeManager.SearchStudent(name);
                    GradeCategory category = gradeManager.GetGradeCategory(grade);

                    resultLabel.Text = $"Student Found!\n\nName: {name}\nGrade: {grade:F2}\nCategory: {category}";
                    resultLabel.ForeColor = Color.Green;
                }
                catch (Exception ex)
                {
                    resultLabel.Text = $"Error: {ex.Message}";
                    resultLabel.ForeColor = Color.Red;
                }
            };

            tab.Controls.Add(searchLabel);
            tab.Controls.Add(searchTextBox);
            tab.Controls.Add(searchButton);
            tab.Controls.Add(resultLabel);

            return tab;
        }

        private TabPage CreateStatisticsTab()
        {
            TabPage tab = new TabPage("Statistics");
            tab.BackColor = Color.White;

            Label statsLabel = new Label
            {
                Location = new Point(20, 20),
                Size = new Size(700, 400),
                AutoSize = false,
                Text = "Click 'Calculate' to see statistics",
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(15),
                Font = new Font("Arial", 12),
                BackColor = Color.FromArgb(240, 240, 240)
            };

            Button calculateButton = new Button
            {
                Text = "Calculate Statistics",
                Location = new Point(20, 430),
                Size = new Size(150, 35),
                BackColor = Color.FromArgb(0, 153, 76),
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            calculateButton.Click += (s, e) =>
            {
                try
                {
                    int count = gradeManager.GetStudentCount();
                    if (count == 0)
                    {
                        statsLabel.Text = "No students in the system yet.";
                        return;
                    }

                    double average = gradeManager.CalculateAverageGrade();
                    double highest = gradeManager.GetHighestGrade();
                    double lowest = gradeManager.GetLowestGrade();
                    string topStudent = gradeManager.GetTopStudent();
                    string bottomStudent = gradeManager.GetBottomStudent();

                    statsLabel.Text = $"STATISTICS\n\n" +
                        $"Total Students: {count}\n" +
                        $"Average Grade: {average:F2}\n\n" +
                        $"HIGHEST GRADE\n" +
                        $"Student: {topStudent}\n" +
                        $"Grade: {highest:F2}\n\n" +
                        $"LOWEST GRADE\n" +
                        $"Student: {bottomStudent}\n" +
                        $"Grade: {lowest:F2}";
                    statsLabel.ForeColor = Color.FromArgb(0, 102, 204);
                }
                catch (Exception ex)
                {
                    statsLabel.Text = $"Error: {ex.Message}";
                    statsLabel.ForeColor = Color.Red;
                }
            };

            tab.Controls.Add(statsLabel);
            tab.Controls.Add(calculateButton);

            return tab;
        }

        private TabPage CreateManageGradesTab()
        {
            TabPage tab = new TabPage("Manage Grades");
            tab.BackColor = Color.White;

            Label updateLabel = new Label { Text = "Update Grade", Font = new Font("Arial", 12, FontStyle.Bold), Location = new Point(20, 20), AutoSize = true };
            Label nameLabel = new Label { Text = "Student Name:", Location = new Point(20, 60), AutoSize = true };
            TextBox nameTextBox = new TextBox { Location = new Point(150, 60), Size = new Size(300, 25) };

            Label newGradeLabel = new Label { Text = "New Grade:", Location = new Point(20, 110), AutoSize = true };
            TextBox newGradeTextBox = new TextBox { Location = new Point(150, 110), Size = new Size(300, 25) };

            Button updateButton = new Button
            {
                Text = "Update Grade",
                Location = new Point(150, 160),
                Size = new Size(120, 35),
                BackColor = Color.FromArgb(255, 153, 0),
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            Label removeLabel = new Label { Text = "Remove Student", Font = new Font("Arial", 12, FontStyle.Bold), Location = new Point(20, 220), AutoSize = true };
            Label removeNameLabel = new Label { Text = "Student Name:", Location = new Point(20, 260), AutoSize = true };
            TextBox removeNameTextBox = new TextBox { Location = new Point(150, 260), Size = new Size(300, 25) };

            Button removeButton = new Button
            {
                Text = "Remove Student",
                Location = new Point(150, 310),
                Size = new Size(120, 35),
                BackColor = Color.FromArgb(204, 0, 0),
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            Label resultLabel = new Label
            {
                Location = new Point(20, 360),
                Size = new Size(700, 80),
                AutoSize = false,
                Text = "",
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(5)
            };

            updateButton.Click += (s, e) =>
            {
                try
                {
                    string name = nameTextBox.Text;
                    if (!double.TryParse(newGradeTextBox.Text, out double newGrade))
                    {
                        resultLabel.Text = "Error: Please enter a valid grade number.";
                        resultLabel.ForeColor = Color.Red;
                        return;
                    }

                    gradeManager.UpdateStudentGrade(name, newGrade);
                    resultLabel.Text = $"✓ Student '{name}' grade updated to {newGrade:F2}!";
                    resultLabel.ForeColor = Color.Green;
                    nameTextBox.Clear();
                    newGradeTextBox.Clear();
                }
                catch (Exception ex)
                {
                    resultLabel.Text = $"Error: {ex.Message}";
                    resultLabel.ForeColor = Color.Red;
                }
            };

            removeButton.Click += (s, e) =>
            {
                try
                {
                    string name = removeNameTextBox.Text;
                    DialogResult result = MessageBox.Show($"Are you sure you want to remove '{name}'?", "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        gradeManager.RemoveStudent(name);
                        resultLabel.Text = $"✓ Student '{name}' removed successfully!";
                        resultLabel.ForeColor = Color.Green;
                        removeNameTextBox.Clear();
                    }
                }
                catch (Exception ex)
                {
                    resultLabel.Text = $"Error: {ex.Message}";
                    resultLabel.ForeColor = Color.Red;
                }
            };

            tab.Controls.Add(updateLabel);
            tab.Controls.Add(nameLabel);
            tab.Controls.Add(nameTextBox);
            tab.Controls.Add(newGradeLabel);
            tab.Controls.Add(newGradeTextBox);
            tab.Controls.Add(updateButton);
            tab.Controls.Add(removeLabel);
            tab.Controls.Add(removeNameLabel);
            tab.Controls.Add(removeNameTextBox);
            tab.Controls.Add(removeButton);
            tab.Controls.Add(resultLabel);

            return tab;
        }
    }
}
