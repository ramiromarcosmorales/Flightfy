namespace Flightfy.Models;

public class Travel
{
    private String title;
    private String destination;
    private DateOnly startDate;
    private DateOnly endDate;
    private List<TravelItem> items; // modificar el tipo de dato cuando cree la clase Item
}