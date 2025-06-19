using Flightfy.Models;
using Flightfy.Services;

User user1 = new User("Felipe", "Lucas", "felipeluca@gmail.com");

// Para que un usuario pueda crear items, primero debe crear un viaje

Travel.OnTravelCreated += FileManager.SaveData;
Travel travel2 = user1.CreateTravel("Eurotrip", "Europa", new DateOnly(2025,05,23), new DateOnly(2025,06,23));
user1.ManageTravel();
