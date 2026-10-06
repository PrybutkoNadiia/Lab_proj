using System;
using System.Collections.Generic;
using MainApp.Models;

namespace MainApp.Services
{
    public class StudentService
    {
        private readonly List<Student> _students = new List<Student>();

        // Get all students
        public List<Student> GetAll()
        {
            return _students;
        }

        public void AddStudent(Student student)
        {
            if (student != null)
            {
                _students.Add(student);
            }
        }

        public void SetStudents(IEnumerable<Student> students)
        {
            _students.Clear();
            if (students != null)
            {
                _students.AddRange(students);
            }
        }

        public Student FindByLastNameAndId(string lastName, string studentId)
        {
            foreach (var student in _students)
            {
                if (string.Equals(student.LastName, lastName, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(student.StudentId, studentId, StringComparison.OrdinalIgnoreCase))
                {
                    return student;
                }
            }
            return null;
        }

        public List<Student> GetThirdCourseSummerStudents()
        {
            List<Student> result = new List<Student>();
            foreach (var student in _students)
            {
                int month = student.BirthDate.Month;
                if (student.Course == 3 && (month >= 6 && month <= 8))
                {
                    result.Add(student);
                }
            }
            return result;
        }
    }
}