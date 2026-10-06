namespace MainApp.Models;
public class Teacher : Person
{
    public string Subject { get; set; }
    public Teacher(string firstName, string lastName, string subject) : base(firstName, lastName)
    {
        Subject = subject;
    }
    public string Teach()
    {
        return $"Teacher {FirstName} {LastName} is conducting a class in {Subject}.";
    }

}