using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage.UI
{
    public class UserMessages
    {
        public static void DefaultConsoleColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void ErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            DefaultConsoleColor();
        }

        public static void SuccessMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            DefaultConsoleColor();
        }
    }
}