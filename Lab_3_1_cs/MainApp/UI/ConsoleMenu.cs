using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FileIO.Lib;
using MainApp.Models;
using MainApp.Services;

namespace MainApp.UI
{
    public class ConsoleMenu
    {
        private readonly StudentService _service = new StudentService();
        private const string Path = "students.txt";

        public void Run()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("=== Student Management System ===");
                Console.WriteLine("1. Load students from file");
                Console.WriteLine("2. Add a new student");
                Console.WriteLine("3. Display all students");
                Console.WriteLine("4. Display 3rd-course summer students (Variant 1)");
                Console.WriteLine("5. Find student by Last Name and ID");
                Console.WriteLine("6. Demonstrate entities (OOP Polymorphism)");
                Console.WriteLine("7. Save changes to file");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");

                switch (Console.ReadLine()?.Trim())
                {
                    case "1": LoadFromFile(); break;
                    case "2": AddNewStudent(); break;
                    case "3": PrintStudents("--- All Students ---", _service.GetAll()); break;
                    case "4":
                        var summer = _service.GetThirdCourseSummerStudents();
                        PrintStudents("--- 3rd-Course Students Born in Summer ---", summer);
                        Console.WriteLine($"Total found: {summer.Count}");
                        break;
                    case "5": FindStudent(); break;
                    case "6": DemonstrateEntities(); break;
                    case "7": SaveToFile(); break;
                    case "0": Console.WriteLine("Exiting program. Goodbye!"); return;
                    default: Console.WriteLine("Invalid option. Please try again."); break;
                }
            }
        }

        private void LoadFromFile()
        {
            string content = FileManager.ReadAll(Path);
            if (string.IsNullOrWhiteSpace(content))
            {
                Console.WriteLine($"File '{Path}' is empty or does not exist.");
                return;
            }

            var list = content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                              .Select(Student.FromFileLine)
                              .Where(s => s != null)
                              .ToList();

            _service.SetStudents(list);
            Console.WriteLine($"Successfully loaded {list.Count} students from '{Path}'.");
        }

        private void SaveToFile()
        {
            var students = _service.GetAll();
            if (students.Count == 0) { Console.WriteLine("No students to save."); return; }

            StringBuilder sb = new StringBuilder();
            students.ForEach(s => sb.AppendLine(s.ToFileLine()));
            FileManager.WriteAll(Path, sb.ToString());
            Console.WriteLine($"Saved {students.Count} students to '{Path}'.");
        }

        private void AddNewStudent()
        {
            Console.WriteLine("--- Add New Student ---");
            Console.Write("First Name: "); string first = Console.ReadLine()?.Trim();
            Console.Write("Last Name: ");  string last = Console.ReadLine()?.Trim();

            int course;
            do { Console.Write("Course (1-6): "); }
            while (!int.TryParse(Console.ReadLine(), out course) || course < 1 || course > 6);

            Console.Write("Student ID (e.g. KB123456): "); string id = Console.ReadLine()?.Trim();

            DateTime birth;
            do { Console.Write("Birth Date (yyyy-MM-dd): "); }
            while (!DateTime.TryParse(Console.ReadLine(), out birth));

            _service.AddStudent(new Student(first, last, course, id, birth));
            Console.WriteLine("Student added successfully!");
        }

        private void PrintStudents(string title, List<Student> list)
        {
            Console.WriteLine(title);
            if (list.Count == 0) { Console.WriteLine("No students found."); return; }
            list.ForEach(s => Console.WriteLine(s));
        }

        private void FindStudent()
        {
            Console.WriteLine("--- Find Student ---");
            Console.Write("Enter Last Name: "); string last = Console.ReadLine()?.Trim();
            Console.Write("Enter Student ID: "); string id = Console.ReadLine()?.Trim();

            var student = _service.FindByLastNameAndId(last, id);
            Console.WriteLine(student != null ? $"\nStudent found:\n{student}" : "No student found with these credentials.");
        }

        private void DemonstrateEntities()
        {
            Console.WriteLine("--- OOP Demonstration ---");
            new Student("Nadiia", "Shevchenko", 3, "KB123456", new DateTime(2004, 7, 15)).Study();
            new Teacher("Oleksandr", "Petrov", "Computer Science").Teach();
            new Astronaut("Yurii", "Gagarin", "Commander").Fly();
        }
    }
}