using Garage_1._0.Garage;
using Garage_1._0.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0
{
    internal class Program
    {
        public static GarageHandler handler = new GarageHandler();
        public static bool running = true;

        static void Main(string[] args)
        {
            handler.CreateGarage();

            while (running)
            {
                try
                {
                    handler.MainMenu();
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine();
                    Console.WriteLine(e);
                    GarageHandler.consoleUI.PressEnterUI();
                }
            }
        }
    }
}