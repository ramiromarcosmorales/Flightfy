using Flightfy.Exceptions;

namespace Flightfy.Models;

public class Flight : TravelItem, IReservable
{
    protected String airline;
    protected String origin;
    protected String destination;
    protected String flightNumber;
    protected User[] seats = new User[80]; // Array para asientos.
        
    protected Flight(String name, String description, DateOnly startDate, DateOnly endDate, String airline, String origin, String destination, String flightNumber, String reservationNumber) : base(name, description, startDate, endDate, reservationNumber)
    {
         this.airline = airline;
         this.origin = origin;
         this.destination = destination;
         this.flightNumber = flightNumber;
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

    // Implementacon de Metodos que reciben como parametro indice para hacer uso del Array.
    public bool AssignSeat(int seat, User pax)
    {
        if (pax == null) 
            // manejo de error si el pasajero es null
            throw new ArgumentNullException("El pasajero no puede ser NULL!");
        
        if (seats[seat] != null)
            throw new TravelException("Asiento ya ocupado!", "SEAT_TAKEN");
        
        if (seat >= 0 && seat < seats.Length)
        {
            seats[seat] = pax; // Asignar el nombre del usuario al asiento.
            return true;
        } else
        {
            return false;
        }
    }
    
    public User GetSeat(int seat)
    {
        if (seat >= 0 && seat < seats.Length)
        {
            return seats[seat]; // Retorna el usuario asignado al asiento.
        }
        throw new IndexOutOfRangeException("Indice de asiento invalido!");
    }

    public override string ToString()
    {
        return $"Airline: {airline}, Origin: {origin}, Destination: {destination}, FlightNumber: {flightNumber}";
    }
}