using System;
using System.Security.Cryptography;

namespace Garage_1._0
{
    interface IVehicle
    {
        void Do(string regNumber, string color, double width);
        string Stats();
    }
    internal class Vehicle : IVehicle
    {
        private string regNumber;
        private string color;
        private double width;

        public string RegNumber
        {
            get { return regNumber; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException(String.Format("You can't a field blank."));
                else
                    regNumber = value;
            }
        }
        public string Color
        {
            get { return color; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException(String.Format("You can't a field blank."));
                else
                    color = value;
            }
        }
        public double Width
        {
            get { return width; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException(String.Format("You must input a positive number."));
                else
                    width = value;
            }
        }

        public void Do(string regNumber, string color, double width)
        {
            RegNumber = regNumber;
            Color = color;
            Width = width;
        }

        public string BaseStats()
        {
            return $"Registration number: {RegNumber}, Color: {Color}, Width: {Width}";
        }

        public virtual string Stats()
        {
            return BaseStats();
        }
    }
    internal class Airplane : Vehicle, IVehicle
    {
        private int motors;

        public int Motors
        {
            get { return motors; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException(String.Format("The number of motors must be a positive number."));
                else
                    motors = value;
            }
        }

        public void Do(string regNumber, string color, double width, int subclassSpecific)
        {
            RegNumber = regNumber;
            Color = color;
            Width = width;
            Motors = subclassSpecific;
        }

        public override string Stats()
        {
            return $"{BaseStats()}, Motors: {Motors}";
        }
    }
    internal class Motorcycle : Vehicle, IVehicle
    {
        private string cylinderVolume;

        public string CylinderVolume
        {
            get { return cylinderVolume; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException(String.Format("You can't a field blank."));
                else
                    cylinderVolume = value;
            }
        }

        public void Do(string regNumber, string color, double width, string subclassSpecific)
        {
            RegNumber = regNumber;
            Color = color;
            Width = width;
            CylinderVolume = subclassSpecific;
        }

        public override string Stats()
        {
            return $"{BaseStats()}, Cylinder Volume: {CylinderVolume}";
        }
    }
    internal class Car : Vehicle, IVehicle
    {
        private string fuelType;

        public string FuelType
        {
            get { return fuelType; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException(String.Format("You can't a field blank."));
                else
                    fuelType = value;
            }
        }

        public void Do(string regNumber, string color, double width, string subclassSpecific)
        {
            RegNumber = regNumber;
            Color = color;
            Width = width;
            FuelType = subclassSpecific;
        }

        public override string Stats()
        {
            return $"{BaseStats()}, Fuel Type: {FuelType}";
        }
    }
    internal class Bus : Vehicle, IVehicle
    {
        private int seats;
        public int Seats
        {
            get { return seats; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException(String.Format("The number of seats must be a positive number."));
                else
                    seats = value;
            }
        }

        public void Do(string regNumber, string color, double width, int subclassSpecific)
        {
            RegNumber = regNumber;
            Color = color;
            Width = width;
            Seats = subclassSpecific;
        }

        public override string Stats()
        {
            return $"{BaseStats()}, Seats: {Seats}";
        }
    }
    internal class Boat : Vehicle, IVehicle
    {
        private double length;

        public double Length
        {
            get { return length; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException(String.Format("The length must be a positive number."));
                else
                    length = value;
            }
        }

        public void Do(string regNumber, string color, double width, double subclassSpecific)
        {
            RegNumber = regNumber;
            Color = color;
            Width = width;
            Length = subclassSpecific;
        }

        public override string Stats()
        {
            return $"{BaseStats()}, Length: {Length}";
        }
    }
}