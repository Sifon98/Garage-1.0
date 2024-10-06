using Garage_1._0.Garage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0.UI
{
    internal class ConsoleUI : IConsoleUI
    {
        public static ConsoleKey GetKey() => Console.ReadKey(true).Key;
        public void PressEnterUI()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\nPress enter to continue.");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadLine();
        }
        public void ErrorMessageRed(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n{message}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public void CreateGarageUI()
        {
            Console.Write("How many parking spaces do you want to have in your garage?\n" +
                          "Amount of parking spaces: ");
        }
        public void MainMenuUI()
        {
            Console.WriteLine("MAIN MENU - Press one of the keys below (1, 2, 3, 4, 5, 6 or 7).\n" +
                              "1. Add a vehicle\n" +
                              "2. Display vehicles\n" +
                              "3. Display vehicle types\n" +
                              "4. Remove vehicle\n" +
                              "5. Search for vehicle\n" +
                              "6. Create a new garage\n" +
                              "7. Quit program");
        }
        public void AddVehicleMenuUI()
        {
            Console.WriteLine("ADD VEHICLE MENU - What vehicle do you wish to add to the garage? (1, 2, 3, 4, 5, 6)\n" +
                              "1. Airplane\n" +
                              "2. Motorcycle\n" +
                              "3. Car\n" +
                              "4. Bus\n" +
                              "5. Boat\n" +
                              "6. Return");
        }
    }
}
