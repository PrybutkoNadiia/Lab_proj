using MainApp.Interfaces;
namespace MainApp.Models;
public class Student : Person, Isingable
{
    public int Course { get; set; }
    public string StudentId { get; set; }
    public string BirthDate { get; set; }
    public Student(string firstName, string lastName, int course, string studentId, string birthDate) : base(firstName, lastName)
    {
        Course = course;
        this.StudentId = studentId;
        BirthDate = birthDate;
    }
    public void Study()
    {
        
    }
    public void Sing()
    {
        
    }
}

