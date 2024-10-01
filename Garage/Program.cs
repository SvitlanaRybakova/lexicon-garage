using System.Reflection.Metadata;
using Garage;
using Garage.Garage;
using Garage.GarageHandler;
using Garage.UI;
using Garage.Vehicles;


int maxGarageCapacity = 10;
Garage<Vehicle> vehicleGarage = new Garage<Vehicle>(maxGarageCapacity); // generic garage for Vehicles
GarageHandler<Vehicle> garageHandler = new GarageHandler<Vehicle>(vehicleGarage); // Pass the same instance of the garage

GarageMenu.ShowMainMenu(garageHandler);

