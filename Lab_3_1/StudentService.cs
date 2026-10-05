using MainApp.Models;
namespace MainApp.Services;

public class StudentService
{
    private Student[] _students = new Student[0];
    public Student[] GetAll => _students;
    public void SetStudents(Student[] students)
    {
        _students = students ?? new Student[0];
    }
    public void AddStudent(Student newStudent)
    {
        Student[] newArr = new Student[_students.Length + 1];
        for (int i = 0; i < _students.Length; i++)
        {
            newArr[i] = _students[i];
        }
        newArr[_students.Length] = newStudent;
        _students = newArr;
    }
    public Student[] GetThirdCourseSummerStudents()
    {
        int count = 0;
        for(int i = 0; i < _students.Length; i++)
        {
            if(IsThirdCourseSummer(_students[i]))
            {
                count++;
            }
        }
        Student[] result = new Student[count];
        int index = 0;
        for(int i = 0; i < _students.Length; i++)
        {
            if(IsThirdCourseSummer(_students[i]))
            {
                result[index++] = _students[i];
            }
        }
        return result;
    }
    private bool IsThirdCourseSummer(Student s)
    {
        if(s.Course != 3 || string.IsNullOrWhiteSpace(s.BirthDate))
        return false;

    string[] parts = s.BirthDate.Split('-');
    if (parts.Length == 3)
    {
        string month = parts[1];
        return month == "06" || month == "07" || month == "08";
    }
    return false;
}
public Student? FindByLastNameId (string lastName, string studentId)
    {
        for(int i = 0; i < _students.Length; i++)
        {
            if (string.Equals(_students[i].LastName, lastName, StringComparison.OrdinalIgnoreCase) &&
            string.Equals(_students[i].StudentId, studentId, StringComparison.OrdinalIgnoreCase))
            {
                return _students[i];
            }
        }
        return null;
    }
}