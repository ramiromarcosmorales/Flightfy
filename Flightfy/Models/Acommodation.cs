namespace Flightfy.Models;

public class Acommodation : TravelItem, IReservable
{
    protected String type;
    protected String address;
    
    public Acommodation (String name, String description, DateOnly startDate, DateOnly endDate, String type, String address, String reservationNumber) : base(name, description, startDate, endDate, reservationNumber)
    {
        this.type = type;
        this.address = address;
        this.reservationNumber = reservationNumber;
    }

    public static Acommodation createAcommodation(String name, String description, DateOnly startDate, DateOnly endDate, String type, String address, String reservationNumber)
    {
        return new Acommodation(name, description, startDate, endDate, type, address, reservationNumber);
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