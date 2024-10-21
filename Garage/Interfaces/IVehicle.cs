
namespace Garage.Interfaces
{
    public interface IVehicle
    {
        string RegistrationNumber { get; }
        string Color { get;  }
        int? NumberOfWheels { get;  }
        public string VehicleTypeName { get; }

    }
}