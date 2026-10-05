using MainApp.Interfaces;
namespace MainApp.Models;
public class Astronaut : Person, Isingable {

public string Mission { get; set; }
public Astronaut(string firstName, string lastName, string mission) : base(firstName,
lastName)
    {
        Mission = mission;
    }
    public void Sing()
    {
        
    }

    public string Fly()
    {
        return $"Astronaut {FirstName} {LastName} is flying on mission {Mission}.";
    }
}
