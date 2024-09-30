using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage.UI
{
    public class UserInterface
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
                                + "***************************************");

                input = int.Parse(Console.ReadLine() ?? "");

                switch (input)
                {
                    case (int)Constants.MainMenuOptions.PrintAllVehicles:
                        Console.WriteLine("PrintAllVehicles");
                        break;

                    case (int)Constants.MainMenuOptions.PrintVehicleTypesAndCounts:

                        Console.WriteLine("PrintVehicleTypesAndCounts");
                        break;

                    case (int)Constants.MainMenuOptions.AddOrRemoveVehicles:
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
                        // TODO: create the error class
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }

            } while (input != (int)Constants.MainMenuOptions.Exit);

        }
    }
}