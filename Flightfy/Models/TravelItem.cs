using System.Text.Json.Serialization;

namespace Flightfy.Models;

public abstract class TravelItem
{
    [JsonInclude]
    protected String name;
    [JsonInclude]
    protected String description;
    [JsonInclude]
    protected DateOnly startDate;
    [JsonInclude]
    protected DateOnly endDate;
    [JsonInclude]
    protected String reservationNumber;

    protected TravelItem(String name, String description, DateOnly startDate, DateOnly endDate, String reservationNumber)
    {
        this.name = name;
        this.description = description;
        this.startDate = startDate;
        this.endDate = endDate;
        this.reservationNumber = reservationNumber;
    }

    public string Name => name;
    public string Description => description;
    public DateOnly StartDate => startDate;
    public DateOnly EndDate => endDate;
    public String ReservationNumber => reservationNumber;

    public abstract override string ToString();
}