using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage.UI
{
    public class GarageMenu
    {
        public static void ShowMainMenu()
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

                string userInput = Console.ReadLine() ?? " ";
                if (!int.TryParse(userInput, out input))
                {
                    Console.WriteLine("Invalid input, please enter a number.");
                    continue;
                }

                switch (input)
                {
                    case (int)Constants.MainMenuOptions.PrintAllVehicles:
                        Console.WriteLine("PrintAllVehicles");
                        break;

                    case (int)Constants.MainMenuOptions.PrintVehicleTypesAndCounts:

                        Console.WriteLine("PrintVehicleTypesAndCounts");
                        break;

                    case (int)Constants.MainMenuOptions.AddOrRemoveVehicles:
                        AddDeleteMenu();
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


        public static void AddDeleteMenu()
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

                string userInput = Console.ReadLine() ?? " ";
                if (!int.TryParse(userInput, out input))
                {
                    UserMessages.ErrorMessage("Invalid input, please enter a number");
                    continue;
                }

                switch (input)
                {
                    case (int)Constants.AddDeleteMenuOptions.AddVehicle:
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