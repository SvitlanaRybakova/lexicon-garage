using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage.Vehicles
{
    public class Boat : Vehicle
    {
        public double Widht { get; set; }

        public Boat(string registrationNumber, string color, double widht)
            : base(registrationNumber, color, null)  // No wheels for the boat
        {
            Widht = widht;
        }

        public override string ToString()
        {
            return $"Type: {GetType().Name}\nRegistration number: {RegistrationNumber}\nColor: {Color}\nWheels: {NumberOfWheels} \nBoat Widht: {Widht}";
        }
    }
}