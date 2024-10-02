using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Xml.XPath;
using Garage.Garage;
using Garage.Helpers;
using Garage.UI;
using Garage.Vehicles;
using static Garage.Constants;

namespace Garage.GarageHandler
{
    public class GarageHandler<T> : IEnumerable<T> where T : Vehicle
    {
        private Garage<T> _garage;

        public GarageHandler(Garage<T> garage)
        {
            _garage = garage; // created instance in Program.cs, passed it to this constructor (like store)
        }

        public void AddVehicle()
        {
            int input;
            do
            {
                Console.WriteLine(
                                                "\nWhat type of vehicle you want to add?"
                                                + "\n1. Airplane"
                                                + "\n2. Boat"
                                                + "\n3. Bus"
                                                + "\n4. Car"
                                                + "\n5. Motorcycle"
                                                + "\n0. Go to Previos Menu"
                                                + "\n ***************************************\n");

                input = Helpers.Utils.AskForMenuOption();

                if (input == (int)Constants.VehicleType.Exit)
                {
                    UI.UserMessages.InfoMessage("Exiting to previos menu...\n");
                    return;
                }

                UI.UserMessages.InfoMessage($"Adding the {(VehicleType)input}...\n");
                string regNumber = Utils.GetRegistrationNumberInput();
                string color = Helpers.Utils.AskForString("Enter vehicle color ");
                int wheels = Utils.GetWheelsInput();

                switch (input)
                {
                    case (int)Constants.VehicleType.Airplane:
                        AddAirplane(regNumber, color, wheels);
                        break;

                    case (int)Constants.VehicleType.Boat:
                        AddBoat(regNumber, color);
                        break;

                    case (int)Constants.VehicleType.Bus:
                        AddBus(regNumber, color, wheels);
                        break;

                    case (int)Constants.VehicleType.Car:
                        AddCar(regNumber, color, wheels);
                        break;
                    case (int)Constants.VehicleType.Motorcycle:
                        AddMotorcycle(regNumber, color, wheels);
                        break;
                    default:
                        UserMessages.ErrorMessage("Invalid option, please try again");
                        break;
                }
            } while (input != (int)Constants.VehicleType.Exit);


        }

        public void PrintAllVehicles()
        {
            if (_garage.currentVehicleNumber == 0)
            {
                UI.UserMessages.InfoMessage("\nThe Garage is empty\n");
                return;
            }
            foreach (var vehicle in _garage)
            {
                UserMessages.InfoMessage($"\n{vehicle}\n");
            }
        }


        public IEnumerator<T> GetEnumerator()
        {
            return _garage.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // TODO: REFACTOR 
        public void AddCar(string regNumber, string color, int wheels)
        {

            FuelType fuelType = Utils.GetFuelTypeInput();

            var vehicle = new Car(regNumber, color, wheels, fuelType);
            _garage.AddVehicle((T)(object)vehicle);
        }

        public void AddBus(string regNumber, string color, int wheels)
        {
            int passengerCapacity = Utils.GetPassengerCapacityInput();

            var vehicle = new Bus(regNumber, color, wheels, passengerCapacity);
            _garage.AddVehicle((T)(object)vehicle);
        }

        public void AddAirplane(string regNumber, string color, int wheels)
        {
            NumberOfEnginesType numberOfEngines = Utils.GetNumberOfEnginesInput();

            var vehicle = new Airplane(regNumber, color, wheels, numberOfEngines);
            _garage.AddVehicle((T)(object)vehicle);
        }

        public void AddBoat(string regNumber, string color)
        {
            double width = Utils.GetWidthInput();

            var vehicle = new Boat(regNumber, color, width);
            _garage.AddVehicle((T)(object)vehicle);
        }

        public void AddMotorcycle(string regNumber, string color, int wheels)
        {
            int cylinderVolume = Utils.GetCylinderVolumeInput();

            var vehicle = new Motorcycle(regNumber, color, wheels, cylinderVolume);
            _garage.AddVehicle((T)(object)vehicle);
        }

        public void DeleteVehicle()
        {
            string registrationNumber = Helpers.Utils.AskForString("Enter the registartion number for delete vehicle ");
            bool result = _garage.DeleteVehicle(registrationNumber);
            if (result) UI.UserMessages.SuccessMessage($"The vehicle with reg number {registrationNumber} deleted successfully");
            else UI.UserMessages.ErrorMessage("Smt went wrong. Cannot delete the vehicle");
        }

        public void SearchVehicle()
        {
            string registrationNumber = Helpers.Utils.AskForString("Enter the registartion number for vehicle to search ");
            T findedVehicle = _garage.SearchVehicle(registrationNumber);
            if (findedVehicle != null) UI.UserMessages.SuccessMessage($"Vehicle is founded:\n{findedVehicle} ");
            else UI.UserMessages.ErrorMessage("Smt went wrong. Cannot find the vehicle");
        }

        public void PrintVehicleTypesAndCounts()
        {
            Dictionary<string, int> vehiclesTypesAndCounts = _garage.GetVehicleTypesAndCounts();
            if (vehiclesTypesAndCounts.Count == 0)
            {
                UI.UserMessages.InfoMessage("\nThe Garage is empty\n");
                return;
            }
            foreach (var vehicleType in vehiclesTypesAndCounts)
            {
                UserMessages.InfoMessage($"\n{vehicleType.Key} - {vehicleType.Value}\n");
            }
        }

        public void CreateGarage()
        {
            int capacity;

            string capacityInput = Helpers.Utils.AskForString("Enter the capacity of the new garage: ");
            if (!int.TryParse(capacityInput, out capacity) || capacity <= 0)
            {
                UI.UserMessages.ErrorMessage("Invalid input. Please enter a positive number for the garage capacity");
                return;
            }

            _garage = new Garage<T>(capacity); // Replace the old garage with a new instance
            UI.UserMessages.SuccessMessage($"Created the new garage with a capacity of {capacity} vehicles.");
        }
    }
}