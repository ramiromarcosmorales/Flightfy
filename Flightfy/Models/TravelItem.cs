namespace Flightfy.Models;

public abstract class TravelItem
{
    protected String name;
    protected String description;
    protected DateOnly startDate;
    protected DateOnly endDate;

    protected TravelItem(String name, String description, DateOnly startDate, DateOnly endDate)
    {
        this.name = name;
        this.description = description;
        this.startDate = startDate;
        this.endDate = endDate;
    }

    public abstract override string ToString();
}