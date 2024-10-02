using System.Reflection.Metadata;
using Garage;
using Garage.Garage;
using Garage.GarageHandler;
using Garage.UI;
using Garage.Vehicles;
using static Garage.Constants;


int maxGarageCapacity = 10;
Garage<Vehicle> vehicleGarage = new Garage<Vehicle>(maxGarageCapacity); // generic garage for Vehicles
GarageHandler<Vehicle> garageHandler = new GarageHandler<Vehicle>(vehicleGarage); // Pass the same instance of the garage

SeedGarageWithDummyData(vehicleGarage);
GarageMenu.ShowMainMenu(garageHandler);


static void SeedGarageWithDummyData(Garage<Vehicle> garageHandler)
{

    garageHandler.AddVehicle(new Car("ABC123", "Red", 4, FuelType.Benzin));
    garageHandler.AddVehicle(new Car("XYZ789", "Blue", 4, FuelType.Diesel));
    garageHandler.AddVehicle(new Bus("BUS456", "Yellow", 6, 50));
    garageHandler.AddVehicle(new Boat("BOT001", "White", 23.4));
    garageHandler.AddVehicle(new Airplane("AIR498", "Red", 6, NumberOfEnginesType.Three));
    garageHandler.AddVehicle(new Motorcycle("MOT002", "Black", 6, 50));
    garageHandler.AddVehicle(new Bus("SUP003", "Rose", 8, 500));

    Console.WriteLine("Garage seeded with dummy data!");
}
