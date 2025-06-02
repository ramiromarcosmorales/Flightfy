namespace Flightfy.Models;

public class Travel
{
    private String title;
    private String destination;
    private DateOnly startDate;
    private DateOnly endDate;
    private List<TravelItem> items; // Uso de Lista

    private Travel(String title, String destination, DateOnly startDate, DateOnly endDate)
    {
        this.title = title;
        this.destination = destination;
        this.startDate = startDate;
        this.endDate = endDate;
        items = new List<TravelItem>();
    }

    public static Travel CreateTravel(String title, String destination, DateOnly startDate, DateOnly endDate)
    {
        return new Travel(title, destination, startDate, endDate);
    }

    public event TravelItemHandler OnItemAdded;
    public event TravelItemHandler OnItemRemoved;

    public void AddItem(TravelItem item)
    {   
        items.Add(item);
        OnItemAdded?.Invoke(item);
    }


    // Metodos que reciben como parametro un índice para poder acceder o eliminar un item de la lista.
    public TravelItem GetItem(int index)
    {
        if (index >= 0 && index < items.Count)
        {
            return items[index];
        }
        throw new IndexOutOfRangeException("Indice inválido!");
    }

    public void RemoveItem(int index)
    {
        if (index >= 0 && index < items.Count)
        {
            var item = items[index];
            items.RemoveAt(index);
            OnItemRemoved?.Invoke(item);
        }

    }

    // Metodo que devuelve la lista de items ordenada por fecha de inicio.
    public List<TravelItem> GetItemsSortedByStartDate()
    {
        return items.OrderBy(item => item.getStartDate()).ToList();
    }

    // Metodo busqueda de item via numero de reservacion.
    public TravelItem FindItemByReservationNumber(string reservationNumber)
    {
        return items.FirstOrDefault(item => item.getReservationNumber() != null && item.getReservationNumber() == reservationNumber);
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