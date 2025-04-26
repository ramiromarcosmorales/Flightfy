namespace Flightfy.Models;

public class Activity : TravelItem, IReservable
{
    protected String type;
    protected String address;
    protected String notes;
    
    
    public Activity(String name, String description, DateOnly startDate, DateOnly endDate, String type, String address, String notes) : base(name, description, startDate, endDate)
    {
        this.type = type;
        this.address = address;
        this.notes = notes;
    }

    public void Reserve()
    {
        Console.WriteLine("Reserving Activty");
    }

    public void Cancel()
    {
        Console.WriteLine("Canceling Flight");
    }

    public override string ToString()
    {
        return $"Type: {type}, Address : {address}, Notes : {notes}";
    }
}