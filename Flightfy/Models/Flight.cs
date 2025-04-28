namespace Flightfy.Models;

public class Flight : TravelItem, IReservable
{
    protected String airline;
    protected String origin;
    protected String destination;
    protected String flightNumber;
        
    protected Flight(String name, String description, DateOnly startDate, DateOnly endDate, String airline, String origin, String destination, String flightNumber, String reservationNumber) : base(name, description, startDate, endDate, reservationNumber)
    {
         this.airline = airline;
         this.origin = origin;
         this.destination = destination;
         this.flightNumber = flightNumber;
         this.reservationNumber = reservationNumber;
    }

    public static Flight createFlight(String name, String description, DateOnly startDate, DateOnly endDate, String airline, String origin, String destination, String flightNumber, String reservationNumber)
    {
        return new Flight(name, description, startDate, endDate, airline, origin, destination, flightNumber, reservationNumber);
    }

    public void Reserve()
    {
        Console.WriteLine("Reserving Flight");
        Console.WriteLine();
    }

    public void Cancel()
    {
        Console.WriteLine("Canceling Flight");
    }

    public override string ToString()
    {
        return $"Airline: {airline}, Origin: {origin}, Destination: {destination}, FlightNumber: {flightNumber}";
    }
}