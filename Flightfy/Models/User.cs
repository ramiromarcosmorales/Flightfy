using System.Runtime.CompilerServices;

namespace Flightfy.Models;

public class User
{
    private String name;
    private String surname;
    private String email;
    private Travel? travel;

    public User(String name, String surname, String email)
    {
        this.name = name;
        this.surname = surname;
        this.email = email;
    }
    
    public bool HasActiveTravel => travel != null;

    public void hasTravel()
    {
        if (HasActiveTravel)
        {
          Console.WriteLine("Travel is already active");  
        }
        else
        {
            Console.WriteLine("Travel is not active");
        }
    }


    // public void createTravel()
    // {
    //     travel = new Travel();
    // }
}