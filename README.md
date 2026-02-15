# Student-Grade-Management-System
A comprehensive console-based C# application for managing student records and grades. This project demonstrates essential programming concepts including data structures, control flow, functions, and exception handling.

## Features

The application provides a complete suite of features for managing student grades:

**Core Functionality**
- **Add Students**: Register new students with their grades (0-100 scale)
- **Display All Students**: View all students sorted by grade in descending order
- **Search Students**: Find a specific student and view their grade and category
- **Calculate Average**: Compute the average grade across all students
- **Find Highest/Lowest**: Identify the top and bottom performing students
- **Update Grades**: Modify a student's grade after registration
- **Remove Students**: Delete student records from the system
- **Show Statistics**: View comprehensive statistics including count, average, highest, and lowest grades

**Grade Categories**
The system automatically categorizes grades:
- **Excellent**: 90-100
- **Good**: 80-89
- **Satisfactory**: 70-79
- **Passing**: 60-69
- **Failing**: 0-59

## Technical Architecture

### Data Structures
The application uses a `Dictionary<string, double>` to store student names and grades, providing efficient O(1) lookup operations for searching and updating records.

### Core Classes

**GradeManager.cs** - Business logic layer handling all operations on student data with validation and error handling.

**Student.cs** - Data model class representing individual students with validation.

**GradeCategory.cs** - Enumeration defining the five grade categories.

**ConsoleUI.cs** - User interface layer providing a menu-driven console interface with formatted output.

## Requirements

- **.NET 7.0 or higher**
- **C# 11 or higher**
- **Windows, macOS, or Linux operating system**

## Installation and Setup

### Clone the Repository
```bash
git clone https://github.com/J0SHUALU/Student-Grade-Management-System.git
cd Student-Grade-Management-System
```

### Build the Project
```bash
dotnet build
```

### Run the Application
```bash
dotnet run
```

## Usage Guide

### Main Menu
When you launch the application, you'll see the main menu with nine options:

1. **Add a Student** - Enter a student's name and grade (0-100)
2. **Display All Students** - View all registered students sorted by grade
3. **Search for a Student** - Find a specific student and view their details
4. **Calculate Average Grade** - See the average grade of all students
5. **Find Highest and Lowest Grades** - Identify top and bottom performers
6. **Update Student Grade** - Modify an existing student's grade
7. **Remove a Student** - Delete a student record
8. **Show Statistics** - View comprehensive statistics
9. **Exit** - Close the application

### Example Workflow

```
1. Add a Student
   - Enter name: Alice
   - Enter grade: 95
   
2. Add a Student
   - Enter name: Bob
   - Enter grade: 87
   
3. Display All Students
   - View all students with their grades and categories
   
4. Show Statistics
   - See average, highest, and lowest grades
```

## Error Handling

The application includes comprehensive error handling for:

- **Invalid Grades**: Grades outside the 0-100 range are rejected
- **Empty Names**: Student names cannot be empty or whitespace
- **Duplicate Students**: Adding a student with an existing name is prevented
- **Non-existent Students**: Searching or updating non-existent students shows appropriate error messages
- **Invalid Input**: Non-numeric grade entries are caught and reported

## Code Quality

The project follows best practices including:

- **Clear Comments**: Every class and method includes XML documentation
- **Meaningful Names**: Variables and methods use descriptive names
- **Separation of Concerns**: Business logic is separated from UI
- **Input Validation**: All user inputs are validated before processing
- **Exception Handling**: Try-catch blocks ensure graceful error handling

## Project Structure

```
StudentGradeManagementSystem/
├── Program.cs                    # Application entry point
├── GradeManager.cs              # Business logic layer
├── Student.cs                   # Student data model
├── GradeCategory.cs             # Grade category enumeration
├── ConsoleUI.cs                 # Console UI implementation
├── StudentGradeManagementSystem.csproj  # Project configuration
├── .gitignore                   # Git ignore rules
└── README.md                    # This file
```

## Key Programming Concepts Demonstrated

**Data Structures**: Dictionary for efficient student storage and retrieval

**Control Flow**: If-else statements for menu navigation and validation, loops for displaying all students

**Functions**: Modular methods for each operation with clear responsibilities

**Exception Handling**: Try-catch blocks for graceful error management

**Enumerations**: GradeCategory enum for type-safe grade classification

**LINQ**: OrderBy, OrderByDescending, Max, Min for data manipulation

## Testing

The application has been tested with various scenarios:

- Adding multiple students with different grades
- Searching for existing and non-existing students
- Calculating statistics with various student counts
- Updating and removing student records
- Invalid input handling (negative grades, non-numeric values, duplicate names)

## Future Enhancements

Potential improvements for future versions:

- File persistence (save/load student data)
- Grade filtering and sorting options
- Student performance reports
- Database integration
- Batch import/export functionality

## License

This project is provided as-is for educational purposes.

## Author

Created as a comprehensive C# learning project demonstrating fundamental programming concepts and best practices.

## Support

For issues or questions about the application, please refer to the code comments and documentation within each class file.
