using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Garage.Constants;

namespace Garage.Vehicles
{
    public class Car : Vehicle
    {
        public FuelType Fuel { get; set; }
        public Car(string registrationNumber, string color, int numberOfWheels, FuelType fuel) : base(registrationNumber, color, numberOfWheels)
        {
            Fuel = fuel;
        }
    }
}