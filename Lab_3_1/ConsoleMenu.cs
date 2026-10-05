using System;
using FileIO.Lib;
using MainApp.Models;
using MainApp.Services;

namespace MainApp.UI;
public class ConsoleMenu
{
    private readonly StudentService _studentService = new StudentService();
    private readonly FileManager _fileManager = new FileManager();
    private const string FilePath = "students.txt";

public void Run()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Load students from file");
            Console.WriteLine("2. Add a new student");
            Console.WriteLine("3. Display all students");
            Console.WriteLine("4. Display third course summer students");
            Console.WriteLine("5. Find student by last name and ID");
            Console.WriteLine("6. Demonstration of entities (Student, Teacher, Astronaut)");
            Console.WriteLine("7. Save changes to file");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");
            
            string? choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    LoadFromFile();
                    break;
                case "2":
                    AddNewStudent();
                    break;
                case "3":
                    PrintStudents(_studentService.GetAll, "All Students:");
                    break;
                case "4":
                    ShowSummerThirdCourseStudents();
                    break;
                case "5":
                    FindStudent();
                    break;
                case "6":
                    DemonstrateEntities();
                    break;
                case "7":
                    SaveToFile();
                    break;
                case "0":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
            
        }
    }
    private void LoadFromFile()
    {
        string raw = _fileManager.ReadFromFile(FilePath);
        if (string.IsNullOrWhiteSpace(raw))
        {
            Console.WriteLine($"File '{FilePath}' is empty or not found.");
            return;
        }
        Student[] loaded = DataSerializer.Deserialize(raw);
        _studentService.SetStudents(loaded);
        Console.WriteLine($"{loaded.Length} Students loaded successfully.");
    }
    private void SaveToFile()
    {
        Student[] current = _studentService.GetAll;
        string serialized = DataSerializer.Serialize(current);
        _fileManager.WriteToFile(FilePath, serialized);
        Console.WriteLine($"Data saved to file successfully '{FilePath}'.");
    }
    private void AddNewStudent()
    {
        Console.WriteLine("Add New Student:");
        string firstName = ReadValidInput("First Name: ", Validator.IsValidName, "Mistake! Name must contain at least 2 letters and only letters.");
        string lastName = ReadValidInput("Last Name: ", Validator.IsValidName, "Mistake! Last name must contain at least 2 letters and only letters.");
        string studentId = ReadValidInput("Student Id: ", Validator.IsValidStudentId, "Mistake! Format: 2 letters and 6-8 digits.");
        string courseStr = ReadValidInput("Course (1-6): ", Validator.IsValidCourse, "Mistake! Enter a number between 1 and 6.");
        string birthDate = ReadValidInput("Birth Date (yyyy-MM-dd): ", Validator.IsValidBirthDate, "Mistake! Enter a valid date in the format yyyy-MM-dd.");

        int course = int.Parse(courseStr);
        Student newStudent = new Student(firstName, lastName, course, studentId, birthDate);
        _studentService.AddStudent(newStudent);
        Console.WriteLine("Student added successfully.");
    }
    private void ShowSummerThirdCourseStudents()
    {
        Student[] result = _studentService.GetThirdCourseSummerStudents();
        Console.WriteLine($"Found {result.Length} students in the third course who were born in summer:");
        PrintStudents(result, "Summer students in the third course:");
    }
    private void FindStudent()
    {
        Console.Write("Enter Last Name: ");
        string? lastName = Console.ReadLine() ?? "";
        Console.Write("Enter Student ID: ");
        string? id = Console.ReadLine() ?? "";

        Student? found = _studentService.FindByLastNameId(lastName, id);
        if (found != null)
        {
            Console.WriteLine($"Found: {found.FirstName} {found.LastName}, ID: {found.StudentId}, Course: {found.Course}, Birth Date: {found.BirthDate}");
        }
        else
        {
            Console.WriteLine($"Not found student with given data.");
        }
    }
    private void DemonstrateEntities()
    {
        Console.WriteLine("---Demonstration of polymorphism and class methods---");
        Student s = new Student("John", "Doe",  3, "AB123456", "2000-06-15");
        Teacher t = new Teacher("Jane", "Smith", "Mathematics");
        Astronaut a = new Astronaut("Neil", "Armstrong", "ISS-Expedition");

        Console.WriteLine(t.Teach());
        Console.WriteLine(a.Fly());
        a.Sing();
    }
    private void PrintStudents(Student[] students, string title)
    {
        Console.WriteLine($"\n---{title}---");
        if (students.Length == 0)
        {
            Console.WriteLine("No students found.");
            return;
        }
        for (int i = 0; i < students.Length; i++)
        {
            Student s = students[i];
            Console.WriteLine($"{i + 1}. {s.LastName} {s.FirstName} | Course: {s.Course} | ID: {s.StudentId} | Birth Date: {s.BirthDate}");
        }
    }
    private string ReadValidInput(string prompt, Func<string, bool> validator, string errorMessage)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string? input = Console.ReadLine()?.Trim();
            if (!string.IsNullOrEmpty(input) && validator(input))
            {
                return input;
            }
            Console.WriteLine(errorMessage);
        }
    }
}