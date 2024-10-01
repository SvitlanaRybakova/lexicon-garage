using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

                switch (input)
                {
                    case (int)Constants.AddMenuOptions.Airplane:
                        AddAirplane();
                        break;

                    case (int)Constants.AddMenuOptions.Boat:
                        AddBoat();
                        break;

                    case (int)Constants.AddMenuOptions.Bus:
                        AddBus();
                        break;

                    case (int)Constants.AddMenuOptions.Car:
                        AddCar();
                        break;
                    case (int)Constants.AddMenuOptions.Motorcycle:
                        AddMotorcycle();
                        break;
                    case (int)Constants.AddMenuOptions.Exit:
                        UI.UserMessages.InfoMessage("Exiting to previos menu...\n");
                        break;
                    default:
                        UserMessages.ErrorMessage("Invalid option, please try again");
                        break;
                }
            } while (input != (int)Constants.AddMenuOptions.Exit);


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
        public void AddCar()
        {
            UI.UserMessages.InfoMessage("Adding the car...\n");
            string regNumber = Utils.GetRegistrationNumberInput();
            string color = Helpers.Utils.AskForString("Enter vehicle color ");

            int wheels = Utils.GetWheelsInput();
            FuelType fuelType = Utils.GetFuelTypeInput();

            var vehicle = new Car(regNumber, color, wheels, fuelType);
            _garage.AddVehicle((T)(object)vehicle);
        }

        public void AddBus()
        {
            UI.UserMessages.InfoMessage("Adding the bus...\n");
            string regNumber = Utils.GetRegistrationNumberInput();
            string color = Helpers.Utils.AskForString("Enter vehicle color ");

            int wheels = Utils.GetWheelsInput();
            int passengerCapacity = Utils.GetPassengerCapacityInput();

            var vehicle = new Bus(regNumber, color, wheels, passengerCapacity);
            _garage.AddVehicle((T)(object)vehicle);
        }

        public void AddAirplane()
        {
            UI.UserMessages.InfoMessage("Adding the airplane...\n");
            string regNumber = Utils.GetRegistrationNumberInput();
            string color = Helpers.Utils.AskForString("Enter vehicle color ");

            int wheels = Utils.GetWheelsInput();
            NumberOfEnginesType numberOfEngines = Utils.GetNumberOfEnginesInput();

            var vehicle = new Airplane(regNumber, color, wheels, numberOfEngines);
            _garage.AddVehicle((T)(object)vehicle);
        }

        public void AddBoat()
        {
            UI.UserMessages.InfoMessage("Adding the boat...\n");
            string regNumber = Utils.GetRegistrationNumberInput();
            string color = Helpers.Utils.AskForString("Enter vehicle color ");
            double width = Utils.GetWidthInput();

            var vehicle = new Boat(regNumber, color, width);
            _garage.AddVehicle((T)(object)vehicle);
        }

        public void AddMotorcycle()
        {
            UI.UserMessages.InfoMessage("Adding the motorcycle...\n");
            string regNumber = Utils.GetRegistrationNumberInput();
            string color = Helpers.Utils.AskForString("Enter vehicle color ");
            int wheels = Utils.GetWheelsInput();
            int cylinderVolume = Utils.GetCylinderVolumeInput();

            var vehicle = new Motorcycle(regNumber, color, wheels, cylinderVolume);
            _garage.AddVehicle((T)(object)vehicle);
        }

    }
}