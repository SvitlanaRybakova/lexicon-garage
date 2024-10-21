using Garage.Interfaces;

namespace Garage.Vehicles
{

    public class Vehicle : IVehicle
    {
        public string RegistrationNumber { get; }
        public string Color { get; }
        public int? NumberOfWheels { get;  }

        public string VehicleTypeName { get;  }
        public Vehicle(string registrationNumber, string color, int? numberOfWheels = null)
        {
            RegistrationNumber = registrationNumber;
            Color = color;
            NumberOfWheels = numberOfWheels;
            VehicleTypeName = GetType().Name;
        }

        public override string ToString()
        {
            return $"Type: {VehicleTypeName}\nRegistration number: {RegistrationNumber}\nColor: {Color}\nWheels: {NumberOfWheels}";
        }
    }
}