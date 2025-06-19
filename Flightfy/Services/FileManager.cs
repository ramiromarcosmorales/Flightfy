using System.Text.Json;
using Flightfy.Models;

namespace Flightfy.Services
{
    public static class FileManager
    {
        public static void SaveData(Travel travel)
        {

            string json = JsonSerializer.Serialize(travel, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText("travel.json", json);
            Console.WriteLine("Datos guardados correctamente en travel.json");
        }
    }
}
