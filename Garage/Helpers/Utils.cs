using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Garage.Constants;

namespace Garage.Helpers
{
    public class Utils
    {
        public static int AskForMenuOption()
        {
            int menuOption = 0;
            bool success;

            do
            {
                string answer = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(answer))
                {
                    UI.UserMessages.ErrorMessage("Invalid input, please enter a number");
                    success = false;
                }
                else if (int.TryParse(answer, out menuOption))
                {
                    success = true;
                }
                else
                {
                    UI.UserMessages.ErrorMessage("Invalid input, please enter a valid number");
                    success = false;
                }

            } while (!success);

            return menuOption;
        }

        public static string AskForString(string prompt)
        {
            bool success = false;
            string answer;

            do
            {
                UI.UserMessages.InfoMessage($"{prompt}: ");
                answer = Console.ReadLine() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(answer))
                {
                    UI.UserMessages.ErrorMessage($"Invalid input, please enter a {prompt}");
                }
                else
                {
                    success = true;
                }

            } while (!success);

            return answer;
        }

        public static int GetWheelsInput()
        {
            int wheels;
            while (true)
            {
                string wheelsInput = AskForString("Enter number of wheels ");
                if (int.TryParse(wheelsInput, out wheels))
                {
                    return wheels;
                }
                UI.UserMessages.ErrorMessage("Invalid input. Please enter a valid number for wheels");
            }
        }

        public static FuelType GetFuelTypeInput()
        {
            FuelType fuelType;
            while (true)
            {
                string fuelTypeInput = AskForString("Enter fuel type (Benzin or Diesel) ");
                if (Enum.TryParse(fuelTypeInput, true, out fuelType) && Enum.IsDefined(typeof(FuelType), fuelType))
                {
                    return fuelType;
                }
                UI.UserMessages.ErrorMessage("Invalid input. Please enter either 'Benzin' or 'Diesel'");

            }
        }

        public static int GetPassengerCapacityInput()
        {
            int passengerCapacity;
            while (true)
            {
                string passengerCapacityInput = AskForString("Enter a passenger capacity number ");
                if (int.TryParse(passengerCapacityInput, out passengerCapacity))
                {
                    return passengerCapacity;
                }
                UI.UserMessages.ErrorMessage("Invalid input. Please enter a valid passenger capacity number");
            }
        }

        public static NumberOfEnginesType GetNumberOfEnginesInput()
        {
            NumberOfEnginesType numberOfEngines;
            while (true)
            {
                string numberOfEnginesInput = AskForString("Enter a number of engines ");
                if (Enum.TryParse(numberOfEnginesInput, true, out numberOfEngines) && Enum.IsDefined(typeof(NumberOfEnginesType), numberOfEngines))
                {
                    return numberOfEngines;
                }
                UI.UserMessages.ErrorMessage("Invalid input. Please enter a valid number of engines. Options: 1, 2, 3, 4, 6");
            }
        }

        public static double GetWidthInput()
        {
            double width;
            while (true)
            {
                string widhtInput = AskForString("Enter a boat width ");
                if (double.TryParse(widhtInput, out width))
                {
                    return width;
                }
                UI.UserMessages.ErrorMessage("Invalid input. Please enter a valid boat width");
            }
        }

        public static int GetCylinderVolumeInput()
        {
            int cylinderVolume;
            while (true)
            {
                string cylinderVolumeInput = AskForString("Enter number of cylinder volume ");
                if (int.TryParse(cylinderVolumeInput, out cylinderVolume))
                {
                    return cylinderVolume;
                }
                UI.UserMessages.ErrorMessage("Invalid input. Please enter a valid number for cylinder volume");
            }
        }

        public static string GetRegistrationNumberInput()
        {
            string pattern = @"^[a-z]{3}\d{3}$";

            while (true)
            {
                string regNumberInput = AskForString("Enter vehicle registration number ");
                if (Regex.IsMatch(regNumberInput, pattern))
                {
                    return regNumberInput.ToUpper();
                }
                UI.UserMessages.ErrorMessage("Invalid input. Please enter a valid registration number. Correct format is ABC123");
            }
        }
    }
}