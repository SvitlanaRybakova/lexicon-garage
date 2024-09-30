using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage.Vehicles
{
    public class Bus : Vehicle
    {

        public int PassengerCapacity { get; set; }

        public Bus(string registrationNumber, string color, int numberOfWheels, int passengerCapacity)
            : base(registrationNumber, color, numberOfWheels)
        {
            PassengerCapacity = passengerCapacity;
        }
        public override string ToString()
        {
            return $"Type: {GetType().Name}\nRegistration number: {RegistrationNumber}\nColor: {Color}\nWheels: {NumberOfWheels} \nPassengerCapacity: {PassengerCapacity}";
        }
    }
}