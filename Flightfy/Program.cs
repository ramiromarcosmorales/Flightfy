using Flightfy.Models;

User user1 = new User("Felipe", "Lucas", "felipeluca@gmail.com");

// Para que un usuario pueda crear items, primero debe crear un viaje
Travel travel1 = user1.CreateTravel();
user1.ManageTravel();
