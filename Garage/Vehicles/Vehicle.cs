using Garage.Interfaces;

namespace Garage.Vehicles
{

    public class Vehicle : IVehicle
    {
        public string RegistrationNumber { get; set; }
        public string Color { get; set; }
        public int? NumberOfWheels { get; set; }

        public Vehicle(string registrationNumber, string color, int? numberOfWheels = null)
        {
            RegistrationNumber = registrationNumber;
            Color = color;
            NumberOfWheels = numberOfWheels;
        }

        public override string ToString()
        {
            return $"Type: {GetType().Name}\nRegistration number: {RegistrationNumber}\nColor: {Color}\nWheels: {NumberOfWheels}";
        }
    }
}