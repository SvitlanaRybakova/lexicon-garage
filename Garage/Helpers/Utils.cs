using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}