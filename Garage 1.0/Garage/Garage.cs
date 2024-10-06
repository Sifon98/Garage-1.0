using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0.Garage
{
    internal class Garage<T> where T : Vehicle
    {
        private Vehicle[] garage;
        private int counter;

        public void CreateArray(int num)
        {
            counter = 0;
            garage = new Vehicle[num];
        }

        internal void AddToGarage(Vehicle vehicle)
        {
            if (counter >= garage.Length)
            {
                GarageHandler.consoleUI.ErrorMessageRed("Your garage is full!");
            }
            else
            {
                garage[counter] = vehicle;
                counter++;
                Console.WriteLine("\nYour vehicle has been created and parked in your garage!");
            }
        }

        internal void RemoveFromGarage(Vehicle vehicle)
        {
            garage = garage.Where(val => val != vehicle).ToArray();
            Array.Resize(ref garage, garage.Length + 1);
            counter--;
        }

        internal IEnumerable<Vehicle> GetVehicles()
        {
            return garage.ToArray();
        }
    }
}
