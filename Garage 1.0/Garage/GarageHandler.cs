using Garage_1._0.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0.Garage
{
    internal class GarageHandler : IGarageHandler
    {
        private static readonly Garage<Vehicle> garage = new Garage<Vehicle>();
        public static readonly ConsoleUI consoleUI = new ConsoleUI();

        public void CreateGarage()
        {
            Console.Clear();
            consoleUI.CreateGarageUI();
            int.TryParse(Console.ReadLine(), out int menuInput);

            if (menuInput <= 0)
            {
                consoleUI.ErrorMessageRed("You should add at least 1 parking space.");
                consoleUI.PressEnterUI();
                CreateGarage();
            }
            else
            {
                garage.CreateArray(menuInput);
                Console.WriteLine($"\nA garage with {menuInput} parking spaces has been created.");
                consoleUI.PressEnterUI();
            }
        }

        public void MainMenu()
        {
            Console.Clear();
            consoleUI.MainMenuUI();
            var keyPressed = ConsoleUI.GetKey();

            switch (keyPressed)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    AddVehicleMenu();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    DisplayVehicles();
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    DisplayTypes();
                    break;
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    RemoveVehicle();
                    break;
                case ConsoleKey.NumPad5:
                case ConsoleKey.D5:
                    SearchFunction();
                    break;
                case ConsoleKey.NumPad6:
                case ConsoleKey.D6:
                    CreateGarage();
                    break;
                case ConsoleKey.NumPad7:
                case ConsoleKey.D7:
                    Environment.Exit(0);
                    break;
                default:
                    consoleUI.ErrorMessageRed("Type one of the numbers in the list.");
                    consoleUI.PressEnterUI();
                    break;
            }
        }

        public void AddVehicleMenu()
        {
            bool runningChoose = true;
            while (runningChoose)
            {
                Console.Clear();
                consoleUI.AddVehicleMenuUI();

                var keyPressed = ConsoleUI.GetKey();

                switch (keyPressed)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        AddVehicle("airplane");
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        AddVehicle("motorcycle");
                        break;
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        AddVehicle("car");
                        break;
                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:
                        AddVehicle("bus");
                        break;
                    case ConsoleKey.NumPad5:
                    case ConsoleKey.D5:
                        AddVehicle("boat");
                        break;
                    case ConsoleKey.NumPad6:
                    case ConsoleKey.D6:
                        runningChoose = false;
                        break;
                    default:
                        Console.WriteLine("Type one of the numbers in the list.");
                        break;
                }
            }
        }

        public void AddVehicle(string type)
        {
            Console.Clear();
            Console.WriteLine($"Write the properties of your {type}.\n");
            Console.Write("Write the registration number: ");
            string regNumber = Console.ReadLine();

            Console.Write("Write the color: ");
            string color = Console.ReadLine();

            Console.Write("Write the width (meters): ");
            double.TryParse(Console.ReadLine(), out double width);

            if (type == "airplane")
            {
                Airplane airplane = new Airplane();
                Console.Write("Write the amount of motors: ");
                int.TryParse(Console.ReadLine(), out int motors);
                airplane.Do(regNumber, color, width, motors);
                garage.AddToGarage(airplane);
            }
            else if (type == "motorcycle")
            {
                Motorcycle motorcycle = new Motorcycle();
                Console.Write("Write the cylinder Volume: ");
                string cylinderVolume = Console.ReadLine();
                motorcycle.Do(regNumber, color, width, cylinderVolume);
                garage.AddToGarage(motorcycle);
            }
            else if (type == "car")
            {
                Car car = new Car();
                Console.Write("Write the Fuel Type: ");
                string fuelType = Console.ReadLine();
                car.Do(regNumber, color, width, fuelType);
                garage.AddToGarage(car);
            }
            else if (type == "bus")
            {
                Bus bus = new Bus();
                Console.Write("Write the Seats: ");
                int.TryParse(Console.ReadLine(), out int seats);
                bus.Do(regNumber, color, width, seats);
                garage.AddToGarage(bus);
            }
            else if (type == "boat")
            {
                Boat boat = new Boat();
                Console.Write("Write the length (meters): ");
                double.TryParse(Console.ReadLine(), out double length);
                boat.Do(regNumber, color, width, length);
                garage.AddToGarage(boat);
            }
            else
            {
                Console.WriteLine("Error, if you somehow see this that means the programmer was stupid.");
            }

            consoleUI.PressEnterUI();
        }

        public void DisplayVehicles()
        {
            Console.Clear();
            Console.WriteLine("Here are all parked vehicles in your garage.\n");

            IEnumerable<Vehicle> vehicles = garage.GetVehicles();
            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle == null)
                    break;

                Console.WriteLine($"{vehicle.GetType().Name} - {vehicle.Stats()}");
            }
            consoleUI.PressEnterUI();
        }

        public void DisplayTypes()
        {
            Console.Clear();
            Console.WriteLine("The types of vehicles in your garage.\n");

            int airplanes = 0, motorcycles = 0, cars = 0, buses = 0, boats = 0;
            IEnumerable<Vehicle> vehicles = garage.GetVehicles();

            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle == null)
                    break;

                if (vehicle.GetType().Name == "Airplane")
                    airplanes++;
                else if (vehicle.GetType().Name == "Motorcycle")
                    motorcycles++;
                else if (vehicle.GetType().Name == "Car")
                    cars++;
                else if (vehicle.GetType().Name == "Bus")
                    buses++;
                else if (vehicle.GetType().Name == "Boat")
                    boats++;
            }

            if (airplanes > 0)
                Console.WriteLine($"Airplanes: {airplanes}");
            if (motorcycles > 0)
                Console.WriteLine($"Motorcycles: {motorcycles}");
            if (cars > 0)
                Console.WriteLine($"Cars: {cars}");
            if (buses > 0)
                Console.WriteLine($"Buses: {buses}");
            if (boats > 0)
                Console.WriteLine($"Boats: {boats}");

            consoleUI.PressEnterUI();
        }

        public void RemoveVehicle()
        {
            Console.Clear();
            Console.WriteLine("Choose what vehicle to remove by typing it's registration number. Below are your parked vehicles.\n");
            bool removedVehicle = false;

            IEnumerable<Vehicle> vehicles = garage.GetVehicles();
            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle == null)
                    break;

                Console.WriteLine($"{vehicle.GetType().Name} - {vehicle.Stats()}");
            }

            Console.Write("\nRegistration number: ");
            string regNumber = Console.ReadLine();

            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle == null)
                    break;

                if (vehicle.RegNumber.ToUpper() == regNumber.ToUpper())
                {
                    removedVehicle = true;
                    garage.RemoveFromGarage(vehicle);
                }
            }

            if (removedVehicle)
                Console.WriteLine("\nVehicle was removed!");
            else
                consoleUI.ErrorMessageRed("No vehicle was removed, perhaps the spelling was incorrect.");

            consoleUI.PressEnterUI();
        }

        public void SearchFunction()
        {
            Console.Clear();
            Console.Write("Look up a specific vehicle by searching for registration number, color and/or width. Seperate each word with a space.\n" +
                          "Search: ");
            string[] searchArray = Console.ReadLine().ToUpper().Split(' ');

            Console.WriteLine("\nResults");
            IEnumerable<Vehicle> vehicles = garage.GetVehicles();
            foreach (Vehicle vehicle in vehicles)
            {
                int correctSearches = 0;

                for (int i = 0; i < searchArray.Length; i++)
                {
                    if (vehicle == null)
                        break;

                    if (vehicle.RegNumber.ToUpper() == searchArray[i])
                        correctSearches++;
                    else if (vehicle.Color.ToUpper() == searchArray[i])
                        correctSearches++;
                    else if (Convert.ToString(vehicle.Width).ToUpper() == searchArray[i])
                        correctSearches++;
                }

                if (correctSearches >= searchArray.Length)
                {
                    Console.WriteLine($"Stats: {vehicle.Stats()}");
                }
            }

            consoleUI.PressEnterUI();
        }
    }
}
