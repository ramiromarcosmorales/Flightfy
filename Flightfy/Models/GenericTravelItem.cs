namespace Flightfy.Models
{

    // Creacion de un item de viaje generico para solucionar el problema de que no se puede deserializar un objeto abstracto
    public class GenericTravelItem : TravelItem
    {
        public GenericTravelItem(string name, string description, DateOnly startDate, DateOnly endDate, string reservationNumber) : base(name, description, startDate, endDate, reservationNumber)
        {
        }

        public override string ToString()
        {
            return "Name: " + name + ", Description: " + description +
                   ", Start Date: " + startDate.ToString("d") +
                   ", End Date: " + endDate.ToString("d") +
                   ", Reservation Number: " + reservationNumber;
        }
    }
}
