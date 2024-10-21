using System.Reflection.Metadata;
using Garage.GargeHelpers;
using Garage.Helpers;
using Garage.Interfaces;
using Garage.UI;
using Garage.Vehicles;


int maxGarageCapacity = 10;
Garage<IVehicle> vehicleGarage = new Garage<IVehicle>(maxGarageCapacity); // generic garage for Vehicles
GarageHandler garageHandler = new GarageHandler(vehicleGarage); // Pass the same instance of the garage


SeedGarageWithDummyData();
GarageMenu.ShowMainMenu(garageHandler);


void SeedGarageWithDummyData()
{

    vehicleGarage.AddVehicle(new Car("ABC123", "Red", 4, FuelType.Benzin));
    vehicleGarage.AddVehicle(new Car("XYZ789", "Blue", 4, FuelType.Diesel));
    vehicleGarage.AddVehicle(new Bus("BUS456", "Yellow", 6, 50));
    vehicleGarage.AddVehicle(new Boat("BOT001", "White", 23.4));
    vehicleGarage.AddVehicle(new Airplane("AIR498", "Red", 6, NumberOfEnginesType.Three));
    vehicleGarage.AddVehicle(new Motorcycle("MOT002", "Black", 6, 50));
    vehicleGarage.AddVehicle(new Bus("SUP003", "Rose", 8, 500));

    Console.WriteLine("Garage seeded with dummy data!");
}
