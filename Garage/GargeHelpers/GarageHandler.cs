using System.Collections;
using Garage.Helpers;
using Garage.Interfaces;
using Garage.UI;
using Garage.Vehicles;

namespace Garage.GargeHelpers
{
    public class GarageHandler : IHandler
    {
        private Garage<IVehicle> _garage;

        public GarageHandler(Garage<IVehicle> garage)
        {
            _garage = garage; // created instance in Program.cs, passed it to this constructor (like store)
        }

        public void AddVehicle()
        {
            //_garage.CurrentVehicleNumber = -2;
            //_garage.maxGarageCapacity = 5216;

            if(_garage.IsFull)
            {
                //
            }
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

                input = Utils.AskForMenuOption();

                if (input == (int)VehicleType.Exit)
                {
                    UserMessages.InfoMessage("Exiting to previos menu...\n");
                    return;
                }

                UserMessages.InfoMessage($"Adding the {(VehicleType)input}...\n");
                string regNumber = Utils.GetRegistrationNumberInput();
                string color = Utils.AskForString("Enter vehicle color ");
                int wheels = Utils.GetWheelsInput();

                switch (input)
                {
                    case (int)VehicleType.Airplane:
                        AddAirplane(regNumber, color, wheels);
                        break;

                    case (int)VehicleType.Boat:
                        AddBoat(regNumber, color);
                        break;

                    case (int)VehicleType.Bus:
                        AddBus(regNumber, color, wheels);
                        break;

                    case (int)VehicleType.Car:
                        AddCar(regNumber, color, wheels);
                        break;
                    case (int)VehicleType.Motorcycle:
                        AddMotorcycle(regNumber, color, wheels);
                        break;
                    default:
                        UserMessages.ErrorMessage("Invalid option, please try again");
                        break;
                }
            } while (input != (int)VehicleType.Exit);


        }

        public void PrintAllVehicles()
        {
            if (_garage.CurrentVehicleNumber == 0)
            {
                UserMessages.InfoMessage("\nThe Garage is empty\n");
                return;
            }
            foreach (var vehicle in _garage)
            {
                UserMessages.InfoMessage($"\n{vehicle}\n");
            }
        }


      

        // TODO: REFACTOR 
        public void AddCar(string regNumber, string color, int wheels)
        {

            FuelType fuelType = Utils.GetFuelTypeInput();

            var vehicle = new Car(regNumber, color, wheels, fuelType);
            _garage.AddVehicle(vehicle);
        }

        public void AddBus(string regNumber, string color, int wheels)
        {
            int passengerCapacity = Utils.GetPassengerCapacityInput();

            var vehicle = new Bus(regNumber, color, wheels, passengerCapacity);
            _garage.AddVehicle(vehicle);
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
            string registrationNumber = Utils.AskForString("Enter the registartion number for delete vehicle ");
            bool result = _garage.DeleteVehicle(registrationNumber);
            if (result) UserMessages.SuccessMessage($"The vehicle with reg number {registrationNumber} deleted successfully");
            else UserMessages.ErrorMessage("Smt went wrong. Cannot delete the vehicle");
        }

        public void SearchVehicle()
        {
            UserMessages.InfoMessage($"Enter the registration number (or press enter to skip): ");
            string registrationNumber = Console.ReadLine().ToUpper() ?? string.Empty;
            UserMessages.InfoMessage($"Enter the vehicle color (or press enter to skip): ");
            string color = Console.ReadLine().ToUpper() ?? string.Empty;
            UserMessages.InfoMessage($"Enter the number of wheels (or press enter to skip): ");
            string wheelsInput = Console.ReadLine().ToUpper() ?? string.Empty;
            int? numberOfWheels = null;

            if (!string.IsNullOrEmpty(wheelsInput) && int.TryParse(wheelsInput, out int wheels))
            {
                numberOfWheels = wheels;
            }


            IEnumerable<IVehicle> res = _garage;

            if (!string.IsNullOrEmpty(color))
            {
                res = res.Where(v => v.Color == color);
            } 
            
            if (!string.IsNullOrEmpty(registrationNumber))
            {
                res = res.Where(v => v.RegistrationNumber == registrationNumber);
            } 
            
            if (numberOfWheels.HasValue)
            {
                res = res.Where(v => v.NumberOfWheels == numberOfWheels);
            }





          //  List<IVehicle> foundVehicles = _garage.SearchVehicle(registrationNumber, color, numberOfWheels);
          //  List<IVehicle> foundVehicles = _garage.Where(v => string.IsNullOrEmpty(registrationNumber) || v.RegistrationNumber == registrationNumber && string.IsNullOrEmpty(color) , numberOfWheels);

            if (res.Any())
            {
                UserMessages.SuccessMessage($"Vehicle is founded:\n ");
                foreach (var vehicle in res)
                {
                    UserMessages.InfoMessage($"\n{vehicle}\n");
                }
            }
            else UserMessages.ErrorMessage("Smt went wrong. Cannot find the vehicle(s)");
        }

        public void PrintVehicleTypesAndCounts()
        {
            var res = _garage.GroupBy(v => v.GetType().Name).Select(v => new { Key = v.Key, Count = v.Count() });
          
            foreach (var vehicleType in res)
            {
                UserMessages.InfoMessage($"\n{vehicleType.Key} - {vehicleType.Count}\n");
            }
        }

        public void CreateGarage()
        {
            int capacity;

            string capacityInput = Utils.AskForString("Enter the capacity of the new garage: ");
            if (!int.TryParse(capacityInput, out capacity) || capacity <= 0)
            {
                UserMessages.ErrorMessage("Invalid input. Please enter a positive number for the garage capacity");
                return;
            }

            _garage = new Garage<T>(capacity); // Replace the old garage with a new instance
            UserMessages.SuccessMessage($"Created the new garage with a capacity of {capacity} vehicles.");
        }
    }
}