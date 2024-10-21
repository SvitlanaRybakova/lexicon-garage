using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.GargeHelpers;
using Garage.Helpers;
using Garage.Interfaces;
using Garage.Vehicles;

namespace Garage.UI
{
    public class GarageMenu
    {
        //private readonly IHandler handler;

        //public GarageMenu(IHandler handeler)
        //{
        //    this.handler = handeler;
        //}

        public static void ShowMainMenu(IHandler garageHandler)
        {

            
            int input;
            do
            {
                Console.WriteLine(
                                "\n************ Main Menu ******************"
                                + "\n1. Print all vehicle"
                                + "\n2. Print vehicle types and number of each"
                                + "\n3. Add/remove vehicles from the garage (via registration number)"
                                + "\n4. Search vehicles"
                                + "\n5. Create a new garage"
                                + "\n0. Exit the application"
                                + "\n ***************************************\n");

                input = Helpers.Utils.AskForMenuOption();

                switch (input)
                {
                    case (int)MainMenuOptions.PrintAllVehicles:
                        garageHandler.PrintAllVehicles();
                        break;

                    case (int)MainMenuOptions.PrintVehicleTypesAndCounts:
                        garageHandler.PrintVehicleTypesAndCounts();
                        break;

                    case (int)Constants.MainMenuOptions.AddOrRemoveVehicles:
                        AddDeleteMenu(garageHandler);
                        break;

                    case (int)Constants.MainMenuOptions.SearchVehicles:
                        garageHandler.SearchVehicle();
                        break;
                    case (int)Constants.MainMenuOptions.CreateNewGarage:
                        garageHandler.CreateGarage();
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


        public static void AddDeleteMenu(IHandler garageHandler)
        {
            int input;
            do
            {
                Console.WriteLine(
                                "\n************ Add or Delete Vehicle ******************"
                                + "\n1. Add vehicle"
                                + "\n2. Delete vehicle"
                                + "\n0. Go to Main Menu"
                                + "\n ***************************************\n");

                input = Helpers.Utils.AskForMenuOption();

                switch (input)
                {
                    case (int)Constants.AddDeleteMenuOptions.AddVehicle:


                        garageHandler.AddVehicle();

                        break;

                    case (int)Constants.AddDeleteMenuOptions.DeleteVehicle:
                        garageHandler.DeleteVehicle();
                        break;

                    case (int)Constants.AddDeleteMenuOptions.Exit:
                        Console.WriteLine("Go to the Main Menu");
                        break;
                    default:
                        UserMessages.ErrorMessage("Invalid option, please try again");
                        break;
                }

            } while (input != (int)AddDeleteMenuOptions.Exit);

        }


    }

}