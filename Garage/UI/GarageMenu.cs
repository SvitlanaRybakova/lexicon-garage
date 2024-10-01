using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.GarageHandler;
using Garage.Vehicles;

namespace Garage.UI
{
    public class GarageMenu
    {
        public static void ShowMainMenu(GarageHandler<Vehicle> garageHandler)
        {
            int input;
            do
            {
                Console.WriteLine(
                                "************ Main Menu ******************"
                                + "\n1. Print all vehicle"
                                + "\n2. Print vehicle types and number of each"
                                + "\n3. Add/remove vehicles from the garage (via registration number)"
                                + "\n4. Search vehicles"
                                + "\n5. Create a new garage"
                                + "\n0. Exit the application"
                                + "\n ***************************************");

                input = Helpers.Utils.AskForMenuOption();

                switch (input)
                {
                    case (int)Constants.MainMenuOptions.PrintAllVehicles:
                        Console.WriteLine("PrintAllVehicles");
                        break;

                    case (int)Constants.MainMenuOptions.PrintVehicleTypesAndCounts:

                        Console.WriteLine("PrintVehicleTypesAndCounts");
                        break;

                    case (int)Constants.MainMenuOptions.AddOrRemoveVehicles:
                        AddDeleteMenu(garageHandler);
                        Console.WriteLine("AddOrRemoveVehicles");
                        break;

                    case (int)Constants.MainMenuOptions.SearchVehicles:

                        Console.WriteLine("SearchVehicles");
                        break;
                    case (int)Constants.MainMenuOptions.CreateNewGarage:
                        Console.WriteLine("CreateNewGarage");
                        break;
                    case (int)Constants.MainMenuOptions.Exit:
                        Console.WriteLine("Exiting the application...");
                        Environment.Exit(0);
                        break;
                    default:
                        UserMessages.ErrorMessage("Invalid option, please try again");
                        break;
                }

            } while (input != (int)Constants.MainMenuOptions.Exit);

        }


        public static void AddDeleteMenu(GarageHandler<Vehicle> garageHandler)
        {
            int input;
            do
            {
                Console.WriteLine(
                                "************ Add or Delete Vehicle ******************"
                                + "\n1. Add vehicle"
                                + "\n2. Delete vehicle"
                                + "\n0. Go to Main Menu"
                                + "\n ***************************************");

                input = Helpers.Utils.AskForMenuOption();

                switch (input)
                {
                    case (int)Constants.AddDeleteMenuOptions.AddVehicle:
                        garageHandler.AddVehicle();
                        Console.WriteLine("Add vehicle");
                        break;

                    case (int)Constants.AddDeleteMenuOptions.DeleteVehicle:

                        Console.WriteLine("Delete vehicle");
                        break;

                    case (int)Constants.AddDeleteMenuOptions.Exit:
                        Console.WriteLine("Go to the Main Menu");
                        break;
                    default:
                        UserMessages.ErrorMessage("Invalid option, please try again");
                        break;
                }

            } while (input != (int)Constants.AddDeleteMenuOptions.Exit);

        }


    }

}