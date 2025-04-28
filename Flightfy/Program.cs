// See https://aka.ms/new-console-template for more information

using Flightfy.Models;

User user1 = new User("Felipe", "Lucas", "felipeluca@gmail.com");
Travel travel1 = user1.CreateTravel();
Console.WriteLine("TEST");
user1.ManageTravel();

Console.WriteLine(user1);