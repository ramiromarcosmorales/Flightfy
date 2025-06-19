using Flightfy.Models;
using Flightfy.Services;

User user1 = new User("Felipe", "Lucas", "felipeluca@gmail.com");

// Intentamos cargar el viaje desde el archivo
Travel? travel = FileManager.LoadData();

if (travel != null)
{
    user1.SetTravel(travel);
}
else
{
    Travel.OnTravelCreated += FileManager.SaveData;
    travel = user1.CreateTravel("Eurotrip", "Europa", new DateOnly(2025, 05, 23), new DateOnly(2025, 06, 23));
}

Travel.OnTravelChanged += FileManager.SaveData;
user1.ManageTravel();
