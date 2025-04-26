namespace Flightfy.Models;

public class Acommodation : TravelItem
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
}