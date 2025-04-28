using System.Runtime.CompilerServices;

namespace Flightfy.Models;

public class User
{
    private String name;
    private String surname;
    private String email;
    private Travel? travel;

    public User(String name, String surname, String email)
    {
        this.name = name;
        this.surname = surname;
        this.email = email;
    }
    
    public bool HasActiveTravel => travel != null;

    public Travel? CreateTravel()
    {
        if (HasActiveTravel)
        {
            return null;
        }

        Console.WriteLine("Ingrese nombre del Viaje:");
        String title = Console.ReadLine();

        Console.WriteLine("Ingrese destino del Viaje:");
        String destination = Console.ReadLine();

        DateOnly startDate;
        Console.WriteLine("Ingrese fecha de inicio del viaje (yyyy-mm-dd)");
        while (!DateOnly.TryParse(Console.ReadLine(), out startDate))
        {
            Console.WriteLine("Ingresaste una fecha inválida! Vuelve a intentar:");
        }

        DateOnly endDate;
        Console.WriteLine("Ingrese fecha de fin del viaje (yyyy-mm-dd)");
        while (!DateOnly.TryParse(Console.ReadLine(), out endDate))
        {
            Console.WriteLine("Ingresaste una fecha inválida! Vuelve a intentar:");
        }

        travel = Travel.CreateTravel(title, destination, startDate, endDate);
        return travel;
    }

    public void ManageTravel()
    {
        if (!HasActiveTravel) return;

        travel.OnItemAdded += (item) =>
        {
            Console.WriteLine($"Added: {item.ToString()}");
        };

        Console.WriteLine("Ingrese a continuación una opción:");
        Console.WriteLine("1 - Agregar Vuelo");
        Console.WriteLine("2 - Agregar Alojamiento");
        Console.WriteLine("3 - Agregar Actividad");
        Console.WriteLine("4 - Imprimir detalles del Viaje");
        Console.WriteLine("5 - Salir");


        while (true)
        {
            int numeroInput = 0;

            while (true)
            {
                try
                {
                    numeroInput = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ingrese un número entero válido!");
                }
            }

            var basicData = (name: "", description: "", startDate: DateOnly.MinValue, endDate: DateOnly.MinValue, reservationNumber: "");
           

            switch (numeroInput)
            {
                
                case 1:
                    Console.WriteLine("Agregar vuelo");
                    basicData = itemDataEntry();

                    Console.WriteLine("Ingrese nombre de la aerolinea");
                    string airline = Console.ReadLine();

                    Console.WriteLine("Ingrese origen");
                    string origin = Console.ReadLine();

                    Console.WriteLine("Ingrese destino");
                    string destination = Console.ReadLine();


                    Console.WriteLine("Ingrese número de Vuelo:");
                    string flightNumber = Console.ReadLine();

                    Flight flight = Flight.createFlight(basicData.name, basicData.description, basicData.startDate, basicData.endDate, airline, origin, destination, flightNumber, basicData.reservationNumber);
                    travel.addItem(flight);
                    break;
                case 2:
                    Console.WriteLine("Agregar alojamiento");
                    basicData = itemDataEntry();

                    Console.WriteLine("Ingrese un tipo de alojamiento:");
                    string acommodationType = Console.ReadLine();

                    Console.WriteLine("Ingrese la dirección:");
                    string accommodationAddress = Console.ReadLine();

                    Acommodation accommodation = Acommodation.createAcommodation(basicData.name, basicData.description, basicData.startDate, basicData.endDate, acommodationType, accommodationAddress, basicData.reservationNumber);
                    travel.addItem(accommodation);
                    break;
                case 3:
                    Console.WriteLine("Agregar actividad");
                    basicData = itemDataEntry();

                    Console.WriteLine("Ingrese un tipo ");
                    string activityType = Console.ReadLine();

                    Console.WriteLine("Ingrese la dirección:");
                    string activityAddress = Console.ReadLine();

                    Console.WriteLine("Ingrese notas:");
                    string notes = Console.ReadLine();

                    Activity activity = Activity.createActivity(basicData.name, basicData.description, basicData.startDate, basicData.endDate, activityType, activityAddress, notes, basicData.reservationNumber);
                    travel.addItem(activity);
                    break;
                case 4:
                    Console.WriteLine(travel);
                    break;
                case 5:
                    Console.WriteLine("Gracias por usar el sistema!");
                    return;
                default:
                    Console.WriteLine("Opción Invalida");
                    break;
            }
            
        }
    }

    private void Travel_OnItemAdded(TravelItem item)
    {
        throw new NotImplementedException();
    }

    private (string name, string description, DateOnly startDate, DateOnly endDate, string reservationNumber) itemDataEntry()
    {
        Console.WriteLine("Ingrese el nombre:");
        string name = Console.ReadLine();

        Console.WriteLine("Ingrese la descripción");
        string description = Console.ReadLine();

        DateOnly startDate;
        Console.WriteLine("Ingrese fecha de inicio (yyyy-mm-dd)");
        while (!DateOnly.TryParse(Console.ReadLine(), out startDate))
        {
            Console.WriteLine("Ingresaste una fecha inválida! Vuelve a intentar:");
        }

        DateOnly endDate;
        Console.WriteLine("Ingrese fecha de fin (yyyy-mm-dd)");
        while (!DateOnly.TryParse(Console.ReadLine(), out endDate))
        {
            Console.WriteLine("Ingresaste una fecha inválida! Vuelve a intentar:");
        }

        Console.WriteLine("Ingrese el número de reserva:");
        string reservationNumber = Console.ReadLine();

        return (name, description, startDate, endDate, reservationNumber);
    }


    public override string ToString()
    {
        return $"Name: {name}, Surname: {surname}, Email: {email}, Travel: {travel}";
    }
}