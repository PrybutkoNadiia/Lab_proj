using System;

namespace MainApp.Models
{
    public class Student : Person
    {
        public int Course { get; set; }
        public string StudentId { get; set; }
        public DateTime BirthDate { get; set; }

        public Student(string firstName, string lastName, int course, string studentId, DateTime birthDate)
            : base(firstName, lastName)
        {
            Course = course;
            StudentId = studentId;
            BirthDate = birthDate;
        }

        public void Study()
        {
            Console.WriteLine($"{FirstName} {LastName} is studying in course {Course}.");
        }

        public string ToFileLine()
        {
            return $"{LastName};{FirstName};{Course};{StudentId};{BirthDate:yyyy-MM-dd}";
        }

        public static Student FromFileLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line)) return null;

            string[] parts = line.Split(';');
            if (parts.Length < 5) return null;

            string lastName = parts[0];
            string firstName = parts[1];
            int course = int.Parse(parts[2]);
            string studentId = parts[3];
            DateTime birthDate = DateTime.Parse(parts[4]);

            return new Student(firstName, lastName, course, studentId, birthDate);
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName}, Course: {Course}, Student ID: {StudentId}, Birth Date: {BirthDate:yyyy-MM-dd}";
        }
    }
}
