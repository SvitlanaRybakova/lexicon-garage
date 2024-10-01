using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Garage;
using Garage.Vehicles;

namespace Garage.GarageHandler
{
    public class GarageHandler<T> : IEnumerable<T> where T : Vehicle
    {
        private Garage<T> _garage;

        public GarageHandler(int capacity)
        {
            _garage = new Garage<T>(capacity); // new garage instance
        }

        public void AddVehicle(T vehicle)
        {
            _garage.AddVehicle(vehicle);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _garage.GetEnumerator(); 
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator(); 
        }

        
    }
}