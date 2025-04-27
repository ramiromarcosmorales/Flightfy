// See https://aka.ms/new-console-template for more information

using Flightfy.Models;

Acommodation acommodation1 = new Acommodation("House Coloosseum", "Booking", new DateOnly(2025, 05, 20), new DateOnly(2025, 05, 22), "departament", "C. Salamanca 2321", "AB-358392");
acommodation1.Reserve();
Console.WriteLine(acommodation1);

User user1 = new User("Felipe", "Lucas", "felipeluca@gmail.com");

user1.hasTravel();