using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage.Vehicles
{
    public class Motorcycle : Vehicle
    {
        public int CylinderVolume { get; set; }
        public Motorcycle(string registrationNumber, string color, int numberOfWheels, int cylinderVolume) : base(registrationNumber, color, numberOfWheels)
        {
            CylinderVolume = cylinderVolume;
        }

        public override string ToString()
        {
            return $"Type: {GetType().Name}\nRegistration number: {RegistrationNumber}\nColor: {Color}\nWheels: {NumberOfWheels} \nCylinder Volume: {CylinderVolume}";
        }
    }
}