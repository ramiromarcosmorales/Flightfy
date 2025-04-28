namespace Flightfy.Models;

public class Travel
{
    private String title;
    private String destination;
    private DateOnly startDate;
    private DateOnly endDate;
    private List<TravelItem> items;

    private Travel(String title, String destination, DateOnly startDate, DateOnly endDate)
    {
        this.title = title;
        this.destination = destination;
        this.startDate = startDate;
        this.endDate = endDate;
        this.items = new List<TravelItem>();
    }

    public static Travel CreateTravel(String title, String destination, DateOnly startDate, DateOnly endDate)
    {
        return new Travel(title, destination, startDate, endDate);
    }

    public event TravelItemHandler OnItemAdded;

    public void addItem(TravelItem item)
    {   
        items.Add(item);
        OnItemAdded?.Invoke(item);
    }

    public override string ToString()
    {
        string result = $"Title: {title}, Destination: {destination}, Start Date: {startDate.ToString()}, End Date: {endDate.ToString()}, ";

        if (items.Count > 0)
        {
            result += "Items: " + items;
        } else
        {
            result += "No items added.";
        }

        return result;
    }
}