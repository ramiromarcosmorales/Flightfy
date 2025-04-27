namespace Flightfy.Models;

public class Travel
{
    private String title;
    private String destination;
    private DateOnly startDate;
    private DateOnly endDate;
    private List<TravelItem> items;

    public Travel(String title, String destination, DateOnly startDate, DateOnly endDate)
    {
        this.title = title;
        this.destination = destination;
        this.startDate = startDate;
        this.endDate = endDate;
    }

    public void addItem(TravelItem item)
    {
        items.Add(item);
    }
    
}