namespace Flightfy.DTOs
{
    public class TravelDTO
    {
        public string Title { get; set; }
        public string Destination { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public List<TravelItemDTO> Items { get; set; }
    }

    public class TravelItemDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string ReservationNumber { get; set; }
    }
}
