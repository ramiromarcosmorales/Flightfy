using Flightfy.Exceptions;

namespace Flightfy.Models;

public static class Validations
{
    // Creación de una función para validar los strings ingresados (evitar repetir la lógica)
    public static string ValideString(string inputName)
    {
        string inputValue = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(inputValue))
            throw new TravelException($"El campo {inputName} no puede estar vacio! Vuelve a reintentar");
        
        return inputValue;
    }
    
}