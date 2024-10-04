
namespace Garage.Interfaces
{
    public interface IVehicle
    {
        string RegistrationNumber { get; set; }
        string Color { get; set; }
        int? NumberOfWheels { get; set; }

        string ToString();
    }
}