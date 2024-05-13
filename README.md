# CURD Operation
## Overview

This ASP.NET web form project is designed to perform CRUD operations (Create, Read, Update, Delete) on a MySQL database named `student_db`. It provides functionality to add, update, and delete student records stored in the database.

## Technologies Used

- ASP.NET Web Forms
- C#
- MySQL Database

## Database Schema

The `student` table in the `student_db` database has the following schema:
```
CREATE TABLE student (
Id INT PRIMARY KEY,
Name VARCHAR(255),
Email VARCHAR(255),
Phone VARCHAR(20),
Age INT,
Gender VARCHAR(10)
);
```

## Important Files

- **Default.aspx**: Main web form containing input fields for adding, updating, and deleting student records.
- **Default.aspx.cs**: Code-behind file for `Default.aspx`, containing C# logic for CRUD operations.
- **web.config**: Configuration file containing database connection string and other application settings.

## Important Methods

- **Page_Load**: Method executed when the page is loaded. Reads data from the database and displays it in a table.
- **Add_Click**: Method executed when the "Add Data" button is clicked. Adds a new student record to the database.
- **Update_Click**: Method executed when the "Update Data" button is clicked. Updates an existing student record in the database.
- **Delete_Click**: Method executed when the "Delete Data" button is clicked. Deletes a student record from the database.

## Database Queries

- **Insert Query**: Inserts a new student record into the `student` table.
- **Update Query**: Updates an existing student record in the `student` table.
- **Delete Query**: Deletes a student record from the `student` table based on the provided ID.

## How to Run

1. Ensure that MySQL server is running.
2. Update the database connection string in the `web.config` file if necessary.
3. Open the project in Visual Studio.
4. Build and run the project.

