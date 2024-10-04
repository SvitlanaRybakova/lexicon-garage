using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Vehicles;

namespace Garage.Interfaces
{
    public interface IHandler<T> where T : Vehicle
    {
        void AddVehicle();
        void PrintAllVehicles();
        void AddCar(string regNumber, string color, int wheels);
        void AddBus(string regNumber, string color, int wheels);
        void AddAirplane(string regNumber, string color, int wheels);
        void AddBoat(string regNumber, string color);
        void AddMotorcycle(string regNumber, string color, int wheels);
        void DeleteVehicle();
        void SearchVehicle();
        void PrintVehicleTypesAndCounts();
        void CreateGarage();
    }
}