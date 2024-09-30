using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Garage.Constants;

namespace Garage.Vehicles
{
    public class Airplane : Vehicle
    {
        public NumberOfEngines Engines { get; set; }
        public Airplane(string registrationNumber, string color, int numberOfWheels, NumberOfEngines engines) : base(registrationNumber, color, numberOfWheels)
        {
            Engines = engines;
        }
        public override string ToString()
        {
            return $"Type: {GetType().Name}\nRegistration number: {RegistrationNumber}\nColor: {Color}\nWheels: {NumberOfWheels} \nAmmount of Engines: {Engines}";
        }
    }

}