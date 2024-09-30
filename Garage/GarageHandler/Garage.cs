using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Vehicles;
using System.Collections;


namespace Garage.Garage
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private Vehicle[] vehicles;
        public int maxGarageCapacity { get; set; }
        public int currentVehicleNumber { get; set; }

        public Garage(int capacity)
        {
            maxGarageCapacity = capacity;
            vehicles = new Vehicle[capacity];
            currentVehicleNumber = 0;
        }


        public void AddVehicle(T vehicle)
        {
            if (currentVehicleNumber >= maxGarageCapacity)
            {
                throw new InvalidOperationException("Garage is full.");
            }

            vehicles[currentVehicleNumber] = vehicle;
            currentVehicleNumber++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < currentVehicleNumber; i++)
            {
                yield return (T)vehicles[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();

        }
    }
}