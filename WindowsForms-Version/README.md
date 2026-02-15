# Student Grade Management System - Windows Forms Version

A professional Windows Forms GUI application for managing student records and grades.

## ⚠️ Important: Windows Only

This version requires **Windows** to run. It will NOT work on Mac or Linux.

## Features

**5 Tabs with All Features:**

1. **Add Student Tab** - Add new students with grades
2. **View All Students Tab** - See all students in a data grid
3. **Search Student Tab** - Find specific students
4. **Statistics Tab** - View comprehensive statistics
5. **Manage Grades Tab** - Update or remove students

## Requirements

- **Windows 10 or later**
- **.NET 7.0 SDK or higher**
- **C# 11 or higher**
- **Visual Studio 2022 or VS Code**

## Quick Start

### Step 1: Install .NET 7.0 SDK
Download from: https://dotnet.microsoft.com/download/dotnet/7.0

### Step 2: Build
```bash
dotnet build
```

### Step 3: Run
```bash
dotnet run
```

A Windows Forms window will open!

## Features Included

✅ Add students with validation
✅ Display all students sorted by grade
✅ Search for specific students
✅ Calculate average grade
✅ Find highest and lowest grades
✅ Update student grades
✅ Remove students with confirmation
✅ Show comprehensive statistics
✅ Color-coded feedback
✅ Professional GUI layout
✅ Data grid display
✅ Tab-based navigation
✅ Error handling
✅ Input validation

## Grade Categories

- **Excellent**: 90-100
- **Good**: 80-89
- **Satisfactory**: 70-79
- **Passing**: 60-69
- **Failing**: 0-59

## Usage

1. **Add Student Tab**
   - Enter name and grade
   - Click "Add Student"
   - See success message

2. **View All Students Tab**
   - Click "Refresh"
   - See data grid with all students
   - Sorted by grade (highest first)

3. **Search Student Tab**
   - Enter student name
   - Click "Search"
   - See student details

4. **Statistics Tab**
   - Click "Calculate Statistics"
   - See total, average, highest, lowest

5. **Manage Grades Tab**
   - Update: Enter name and new grade, click "Update Grade"
   - Remove: Enter name, click "Remove Student", confirm

## Error Handling

- Invalid grades (outside 0-100)
- Empty student names
- Duplicate students
- Non-existent students
- Invalid input

## Project Structure

```
├── Program.cs                    # Entry point
├── GradeManager.cs              # Business logic
├── Student.cs                   # Data model
├── GradeCategory.cs             # Grade enum
├── MainForm.cs                  # GUI implementation
├── MainForm.Designer.cs         # Designer file
├── StudentGradeManagementSystem.csproj  # Project config
├── .gitignore                   # Git ignore
└── README.md                    # This file
```

## Key Programming Concepts

- **Data Structures**: Dictionary for efficient storage
- **Control Flow**: If-else, loops, switch statements
- **Functions**: 25+ methods with clear responsibilities
- **Exception Handling**: Try-catch for error management
- **Enumerations**: GradeCategory enum
- **LINQ**: OrderBy, Max, Min, Average operations
- **Windows Forms**: TabControl, DataGridView, TextBox, Button


## For Mac Users

If you're on Mac, use the **Console Version** instead. It has all the same features and works perfectly on Mac.

## License

Educational purposes only.

## Support

Refer to code comments and documentation in each class file.
