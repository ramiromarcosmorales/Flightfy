namespace Flightfy.Models;

public abstract class TravelItem
{
    protected String name;
    protected String description;
    protected DateOnly? startDate;
    protected DateOnly? endDate;
    protected String reservationNumber;

    protected TravelItem(String name, String description, DateOnly startDate, DateOnly endDate, String reservationNumber)
    {
        this.name = name;
        this.description = description;
        this.startDate = startDate;
        this.endDate = endDate;
        this.reservationNumber = reservationNumber;
    }

    public DateOnly? getStartDate()
    {
        return startDate;
    }

    public String getReservationNumber()
    {
        return reservationNumber;
    }

    public abstract override string ToString();
}