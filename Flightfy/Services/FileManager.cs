using System.Text.Json;
using Flightfy.DTOs;
using Flightfy.Models;

namespace Flightfy.Services
{
    public static class FileManager
    {
        static FileManager()
        {
            LoadConfig();
        }

        private static string ConfigFile = "Flightfy-Config.json";
        private static string DefaultDirectory = AppContext.BaseDirectory;
        private static Config config;

        // Metodo que se encarga de la logica de carga de la configuracion al iniciar la aplicacion.
        private static void LoadConfig()
        {
            if (File.Exists(ConfigFile))
            {
                string json = File.ReadAllText(ConfigFile);
                config = JsonSerializer.Deserialize<Config>(json);
            } else
            {
                config = new Config
                {
                    SavePath = DefaultDirectory
                };
                SaveConfig();
            }
        }

        // Metodo que se encarga de guardar la configuracion en un archivo JSON
        private static void SaveConfig()
        {
            string json = JsonSerializer.Serialize(config, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(ConfigFile, json);
        }


        // Setter para cambiar la ruta de guardado de los datos
        public static void SetPath(string path)
        {
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);


            string oldPath = config.SavePath;
            string oldFile = Path.Combine(oldPath, "Flightfy-Data.json");
            string newFile = Path.Combine(path, "Flightfy-Data.json");

            if (File.Exists(oldFile))
            {
                try
                {
                    File.Move(oldFile, newFile, true);
                    Console.WriteLine("Archivo trasladadao correctamente");
                } catch (Exception ex)
                {
                    Console.WriteLine($"Error moviendo los archivos: {ex.Message}");
                }
            }

            config.SavePath = path;
            SaveConfig();
            Console.WriteLine($"Nueva ruta: {config.SavePath}");
        }


        // Metodo que se encarga de guardar los datos de un viaje en un archivo JSON
        public static void SaveData(Travel travel)
        {
            TravelDTO dto = new TravelDTO
            {
                Title = travel.Title,
                Destination = travel.Destination,
                StartDate = travel.StartDate,
                EndDate = travel.EndDate,
                Items = travel.Items.Select(item => new TravelItemDTO
                {
                    Name = item.Name,
                    Description = item.Description,
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                    ReservationNumber = item.ReservationNumber,
                }).ToList()
            };

            string json = JsonSerializer.Serialize(dto, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            string filePath = Path.Combine(config.SavePath, "Flightfy-Data.json");

            File.WriteAllText(filePath, json);
        }

        // Metodo que se encarga de cargar los datos de un viaje desde un archivo JSON
        public static Travel LoadData()
        {
            string filePath = Path.Combine(config.SavePath, "Flightfy-Data.json");

            if (!File.Exists(filePath))
            {
                Console.WriteLine("No existe un registro de data. Crear un Travel");
                return null;
            }

            string json = File.ReadAllText(filePath);
            TravelDTO dto = JsonSerializer.Deserialize<TravelDTO>(json);

            Travel travel = Travel.CreateTravel(dto.Title, dto.Destination, dto.StartDate, dto.EndDate);
            foreach (var itemDto in dto.Items)
            {
                var item = new GenericTravelItem(
                    itemDto.Name,
                    itemDto.Description,
                    itemDto.StartDate,
                    itemDto.EndDate,
                    itemDto.ReservationNumber
                );

                travel.AddItem(item);
            }

            Console.WriteLine("Voy a cargar los datos desde el archivo");
            return travel;
        }

        // Metodo que se encarga de eliminar todos los datos guardados en el archivo JSON y restaurar la ruta de guardado a la predeterminada
        public static void DeleteAllData()
        {
            string path = config.SavePath;
            string file = Path.Combine(path, "Flightfy-Data.json");


            if (File.Exists(file))
            {
                File.Delete(file);
            }

            config.SavePath = DefaultDirectory;
            SaveConfig();
            Console.WriteLine($"Ruta de guardado restaurada a: {config.SavePath}");
        }
    }
}   
