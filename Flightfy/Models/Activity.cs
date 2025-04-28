namespace Flightfy.Models;

public class Activity : TravelItem, IReservable
{
    protected String type;
    protected String address;
    protected String notes;
    
    
    public Activity(String name, String description, DateOnly startDate, DateOnly endDate, String type, String address, String notes, String reservationNumber) : base(name, description, startDate, endDate, reservationNumber)
    {
        this.type = type;
        this.address = address;
        this.notes = notes;
        this.reservationNumber = reservationNumber;
    }
    public static Activity createActivity(String name, String description, DateOnly startDate, DateOnly endDate, String type, String address, String notes, String reservationNumber)
    {
        return new Activity(name, description, startDate, endDate, type, address, notes, reservationNumber);
    }

    public void Reserve()
    {
        Console.WriteLine("Reserving Activty");
    }

    public void Cancel()
    {
        Console.WriteLine("Canceling Activty");
    }

    public override string ToString()
    {
        return $"Type: {type}, Address : {address}, Notes : {notes}";
    }
}