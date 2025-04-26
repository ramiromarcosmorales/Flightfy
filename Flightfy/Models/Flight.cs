namespace Flightfy.Models;

public class Flight : TravelItem
{
    protected String airline;
    protected String origin;
    protected String destination;
    protected String flightNumber;
    protected String reservationNumber;
        
    public Flight(String name, String description, DateOnly startDate, DateOnly endDate, String airline, String origin, String destination, String flightNumber, String reservationNumber) : base(name, description, startDate, endDate)
    {
         this.airline = airline;
         this.origin = origin;
         this.destination = destination;
         this.flightNumber = flightNumber;
         this.reservationNumber = reservationNumber;
    }
}