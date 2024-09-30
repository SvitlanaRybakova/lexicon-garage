using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage.Vehicles
{
    public class Boat : Vehicle
    {
        public string Widht { get; set; }

        public Boat(string registrationNumber, string color, string widht)
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