﻿using System.Reflection.Metadata;
using Garage;
using Garage.Garage;
using Garage.UI;
using Garage.Vehicles;

Garage<Car> carGarage = new Garage<Car>(2); // max capacity => 2 cars
carGarage.AddVehicle(new Car("CAR001", "Red", 4, Constants.FuelType.Benzin));
carGarage.AddVehicle(new Car("CAR002", "Blue", 4, Constants.FuelType.Diesel));

foreach (var car in carGarage)
{
    Console.WriteLine(car.ToString());
    Console.WriteLine();
}

UserInterface.ShowMainMenu();

