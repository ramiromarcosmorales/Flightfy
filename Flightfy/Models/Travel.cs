using System.Text.Json.Serialization;
using Flightfy.Exceptions;

namespace Flightfy.Models;

public class Travel
{
    [JsonInclude]
    private String title;
    [JsonInclude]
    private String destination;
    [JsonInclude]
    private DateOnly startDate;
    [JsonInclude]
    private DateOnly endDate;
    [JsonInclude]
    private List<TravelItem> items; // Uso de Lista

    [JsonConstructor]

    private Travel(String title, String destination, DateOnly startDate, DateOnly endDate)
    {
        this.title = title;
        this.destination = destination;
        this.startDate = startDate;
        this.endDate = endDate;
        items = new List<TravelItem>();
    }

    public string Title => title;
    public string Destination => destination;
    public DateOnly StartDate => startDate;
    public DateOnly EndDate => endDate;
    public List<TravelItem> Items => items;

    public static event TravelCreateHandler OnTravelCreated;

    public static Travel CreateTravel(String title, String destination, DateOnly startDate, DateOnly endDate)
    {
        Travel travel = new Travel(title, destination, startDate, endDate);
        OnTravelCreated?.Invoke(travel);
        return travel;
    }

    public static event TravelChangeHandler OnTravelChanged;
    public event TravelItemHandler OnItemAdded;
    public event TravelItemHandler OnItemRemoved;


    public void AddItem(TravelItem item)
    {   
        if (item == null)
            throw new ArgumentNullException("El item no puede ser null.");

        if (FindItemByReservationNumber(item.ReservationNumber) != null)
        {
            throw new TravelException("Item existente!", "DUPLICATE_RESERVATION_NUMBER");
        }
        
        items.Add(item);
        OnItemAdded?.Invoke(item);

        OnTravelChanged?.Invoke(this);
    }


    // Metodos que reciben como parametro un indice para poder acceder o eliminar un item de la lista.
    public TravelItem GetItem(int index)
    {
        if (index >= 0 && index < items.Count)
        {
            return items[index];
        }
        throw new IndexOutOfRangeException("Indice invalido!");
    }

    public void RemoveItem(int index)
    {
        // Manejo para evitar el uso de RemoveItem en caso de que no haya ningun item
        if (items.Count == 0)
            throw new TravelException("No hay items creados!", "UNINITIALIZED_LIST");
        
        // Manejo de ingreso de indices inválidos
        if (index < 0 || index >= items.Count) 
            throw new IndexOutOfRangeException("Indice invalido!");
        
        var item = items[index]; 
        items.RemoveAt(index); 
        OnItemRemoved?.Invoke(item);

        OnTravelChanged?.Invoke(this);
    }

    // Metodo que devuelve la lista de items ordenada por fecha de inicio.
    public List<TravelItem> GetItemsSortedByStartDate()
    {
        return items.OrderBy(item => item.ReservationNumber).ToList();
    }

    // Metodo busqueda de item via numero de reservacion.
    public TravelItem FindItemByReservationNumber(string reservationNumber)
    {
        return items.FirstOrDefault(item => item.ReservationNumber != null && item.ReservationNumber ==  reservationNumber);
    }

    public override string ToString()
    {
        string result = $"Title: {title}, Destination: {destination}, Start Date: {startDate.ToString()}, End Date: {endDate.ToString()}, ";

        if (items.Count > 0)
        {
            result += "Items: " + string.Join("; ", GetItemsSortedByStartDate().Select(i => i.ToString()));
        } else
        {
            result += "No items added.";
        }

        return result;
    }
}