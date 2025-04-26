namespace Flightfy.Models;

public class Acommodation : TravelItem, IReservable
{
    protected String type;
    protected String address;
    protected String reservationNumber;
    
    public Acommodation (String name, String description, DateOnly startDate, DateOnly endDate, String type, String address, String reservationNumber) : base(name, description, startDate, endDate)
    {
        this.type = type;
        this.address = address;
        this.reservationNumber = reservationNumber;
    }

    public void Reserve()
    {
        Console.WriteLine("Reserving Acommodation");
    }

    public void Cancel()
    {
        Console.WriteLine("Canceling Acommodation");
    }

    public override string ToString()
    {
        return $"Type: {type}, Address: {address}, Reservation Number: {reservationNumber}";
    }
}