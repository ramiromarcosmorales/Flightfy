using System.Diagnostics;
using System.Runtime.CompilerServices;
using Flightfy.Exceptions;

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
    
    public Travel? CreateTravel(string title, string destination, DateOnly startDate, DateOnly endDate)
    {
        // Excepciones propias para el manejo de entrada de datos (evitar fechas ilógicas, datos vacios, etc)
        if (HasActiveTravel)
            throw new TravelException("Ya existe un viaje activo", "ACTIVE_TRAVEL");

        if (String.IsNullOrWhiteSpace(title) || String.IsNullOrWhiteSpace(destination))
            throw new TravelException("Titulo o Destino no puede estar vacio", "MISSING_DATA");
            
        if (startDate > endDate)
            throw new TravelException("La fecha de inicio no puede ser mayor a la de finalizacion", "INVALID_DATE");

        // Manejo de error en la creación de viaje
        try
        {
            travel = Travel.CreateTravel(title, destination, startDate, endDate);
            return travel;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error creando el viaje: " + ex.Message);
            return null;
        }
    }

    /* La clase Usuario no debería tener tantas responsabilidades, más adelante se va a simplificar la función de administrar el
       viaje mediante otras clases. */

    // Manejo de excepciones en caso de entrada de datos inválidos
    public void ManageTravel()
    {
        if (!HasActiveTravel) return;

        travel.OnItemAdded += (item) =>
        {
            Console.WriteLine($"Added: {item.ToString()}");
        };

        Console.WriteLine("Ingrese a continuacion una opcion:");
        Console.WriteLine("1 - Agregar Vuelo");
        Console.WriteLine("2 - Agregar Alojamiento");
        Console.WriteLine("3 - Agregar Actividad");
        Console.WriteLine("4 - Imprimir detalles del Viaje");
        Console.WriteLine("5 - Eliminar item");
        Console.WriteLine("6 - Busqueda via numero de reserva");
        Console.WriteLine("7 - Salir");


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
                    Console.WriteLine("Ingrese un numero entero valido!");
                }
            }

            var basicData = (name: "", description: "", startDate: DateOnly.MinValue, endDate: DateOnly.MinValue, reservationNumber: "");
           

            switch (numeroInput)
            {
                
                case 1:
                    bool vueloCorrecto = false;
                    while (!vueloCorrecto)
                    {
                        try
                        {
                            Console.WriteLine("Agregar vuelo");
                            basicData = itemDataEntry();

                            Console.WriteLine("Ingrese nombre de la aerolinea");
                            string airline = Validations.ValideString("airline");

                            Console.WriteLine("Ingrese origen");
                            string origin = Validations.ValideString("origin");

                            Console.WriteLine("Ingrese destino");
                            string destination = Validations.ValideString("destination");

                            Console.WriteLine("Ingrese numero de Vuelo:");
                            string flightNumber = Validations.ValideString("flightNumber");

                            Flight flight = Flight.createFlight(
                                basicData.name, basicData.description,
                                basicData.startDate, basicData.endDate,
                                airline, origin, destination,
                                flightNumber, basicData.reservationNumber
                            );

                            travel.AddItem(flight);
                            vueloCorrecto = true;
                        }
                        catch (TravelException e)
                        {
                            Console.WriteLine($"Error: {e.Message}");
                            Console.WriteLine("Vuelve a ingresar los datos del vuelo");
                        }
                    }
                    break;
                case 2:
                    bool alojamientoCorrecto = false;
                    while (!alojamientoCorrecto)
                    {
                        try
                        {
                            Console.WriteLine("Agregar alojamiento");
                            basicData = itemDataEntry();

                            Console.WriteLine("Ingrese un tipo de alojamiento:");
                            string acommodationType = Validations.ValideString("acommodationType");

                            Console.WriteLine("Ingrese la direccion:");
                            string accommodationAddress = Validations.ValideString("accommodationAddress");

                            Acommodation accommodation = Acommodation.createAcommodation(
                                basicData.name, basicData.description,
                                basicData.startDate, basicData.endDate,
                                acommodationType, accommodationAddress,
                                basicData.reservationNumber
                            );

                            travel.AddItem(accommodation);
                            alojamientoCorrecto = true;
                        }
                        catch (TravelException e)
                        {
                            Console.WriteLine($"Error: {e.Message}");
                            Console.WriteLine("Vuelve a ingresar los datos del alojamiento");
                        }
                    }
                    break;
                case 3:
                    bool actividadCorrecta = false;
                    while (!actividadCorrecta)
                    {
                        try
                        {
                            Console.WriteLine("Agregar actividad");
                            basicData = itemDataEntry();

                            Console.WriteLine("Ingrese un tipo de actividad");
                            string activityType = Validations.ValideString("activityType");

                            Console.WriteLine("Ingrese la direccion:");
                            string activityAddress = Validations.ValideString("activityAddress");

                            Console.WriteLine("Ingrese notas:");
                            string notes = Console.ReadLine(); // Las notas pueden ser opcionales, por eso no usamos Validations

                            Activity activity = Activity.createActivity(
                                basicData.name, basicData.description,
                                basicData.startDate, basicData.endDate,
                                activityType, activityAddress,
                                notes, basicData.reservationNumber
                            );

                            travel.AddItem(activity);
                            actividadCorrecta = true;
                        }
                        catch (TravelException e)
                        {
                            Console.WriteLine($"Error: {e.Message}");
                            Console.WriteLine("Vuelve a ingresar los datos de la actividad");
                        }
                    }
                    break;
                case 4:
                    Console.WriteLine(travel);
                    break;
                case 5:
                    Console.WriteLine("Ingrese un indice del item a eliminar:");
                    int indice = int.Parse(Console.ReadLine());
                    travel.RemoveItem(indice);       
                    break;
                case 6:
                    Console.WriteLine("Ingrese el numero de reserva del item:");
                    string reservationNumber = Console.ReadLine();
                    Console.WriteLine(travel.FindItemByReservationNumber(reservationNumber));
                    break;
                case 7:
                    Console.WriteLine("Gracias por usar el sistema!");
                    return;
                default:
                    Console.WriteLine("Opcion Invalida");
                    break;
            }
            
        }
    }

    private (string name, string description, DateOnly startDate, DateOnly endDate, string reservationNumber) itemDataEntry()
    {
        string name;
        string description;
        string reservationNumber;
        while (true)
        {
            try
            {
                Console.WriteLine("Ingrese el nombre:");
                name = Validations.ValideString("nombre");

                Console.WriteLine("Ingrese la descripcion");
                description = Validations.ValideString("descripcion");

                Console.WriteLine("Ingrese el numero de reserva:");
                reservationNumber = Validations.ValideString("reservationNumber");
                
                break;
            }
            catch (TravelException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        DateOnly startDate;
        Console.WriteLine("Ingrese fecha de inicio");
        while (!DateOnly.TryParse(Console.ReadLine(), out startDate))
        {
            Console.WriteLine("Ingresaste una fecha invalida! Vuelve a intentar:");
        }

        DateOnly endDate;
        while (true) 
        {
            Console.WriteLine("Ingresa la fecha de fin");
            if (!DateOnly.TryParse(Console.ReadLine(), out endDate))
            {
                Console.WriteLine("Ingresaste una fecha invalida! Vuelve a intentar:");
                continue;
            }

            if (endDate < startDate)
            {
                Console.WriteLine("La fecha de fin no puede ser menor a la de inicio! Vuelve a reintentar:");
                continue;
            }

            break;
        }
        

        return (name, description, startDate, endDate, reservationNumber);
    }


    public override string ToString()
    {
        return $"Name: {name}, Surname: {surname}, Email: {email}, Travel: {travel}";
    }
}