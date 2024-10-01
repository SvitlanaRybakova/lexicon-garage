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
                        Console.WriteLine("Add airplane");
                        break;

                    case (int)Constants.AddMenuOptions.Boat:
                        Console.WriteLine("Add boat");
                        break;

                    case (int)Constants.AddMenuOptions.Bus:
                        AddBus();
                        break;

                    case (int)Constants.AddMenuOptions.Car:
                        AddCar();
                        break;
                    case (int)Constants.AddMenuOptions.Motorcycle:
                        Console.WriteLine("Add motorcycle");
                        break;
                    case (int)Constants.AddMenuOptions.Exit:
                        Console.WriteLine("Exiting");
                        break;
                    default:
                        UserMessages.ErrorMessage("Invalid option, please try again");
                        break;
                }
            } while (input != (int)Constants.AddMenuOptions.Exit);


        }

        public void PrintAllVehicles()
        {
           if(_garage.currentVehicleNumber == 0){
                UI.UserMessages.InfoMessage("The Garage is empty");
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
            string regNumber = Helpers.Utils.AskForString("Enter vehicle registration number ");
            string color = Helpers.Utils.AskForString("Enter vehicle color ");

            int wheels = Utils.GetWheelsInput();
            FuelType fuelType = Utils.GetFuelTypeInput();

            var vehicle = new Car(regNumber, color, wheels, fuelType);
            _garage.AddVehicle((T)(object)vehicle);
        }

        public void AddBus()
        {
            UI.UserMessages.InfoMessage("Adding the bus...\n");
            string regNumber = Helpers.Utils.AskForString("Enter vehicle registration number ");
            string color = Helpers.Utils.AskForString("Enter vehicle color ");

            int wheels = Utils.GetWheelsInput();
            int passengerCapacity = Utils.GetPassengerCapacityInput();

            var vehicle = new Bus(regNumber, color, wheels, passengerCapacity);
            _garage.AddVehicle((T)(object)vehicle);
        }



    }
}