using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Vehicles;
using System.Collections;
using Garage.UI;
using Garage.Interfaces;


namespace Garage.GargeHelpers
{
    public class Garage<T> : IEnumerable<T> where T : IVehicle
    {
        private T?[] vehicles;
        public int maxGarageCapacity { get; private set; }
        public int CurrentVehicleNumber { get; private set; }

        public bool IsFull => CurrentVehicleNumber >= maxGarageCapacity;

        public Garage(int capacity)
        {
            maxGarageCapacity = capacity;
            vehicles = new T[capacity];
            CurrentVehicleNumber = 0;
        }

        internal bool AddVehicle(T vehicle)
        {
            if (IsFull)
            {
                return false;
            }

            vehicles[CurrentVehicleNumber] = vehicle;
            UserMessages.SuccessMessage($"Vehicle {vehicle.RegistrationNumber} added successfully");
            CurrentVehicleNumber++;
            return true;
        }

        internal bool DeleteVehicle(string registrationNumber)
        {
            for (int i = 0; i < CurrentVehicleNumber; i++)
            {
                if (vehicles[i].RegistrationNumber == registrationNumber.ToUpper())
                {
                    
                    vehicles[i] = vehicles[CurrentVehicleNumber - 1];
                    vehicles[CurrentVehicleNumber - 1] = default; //set the last vehicle slot to null
                    CurrentVehicleNumber--;
                    return true;
                }
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < CurrentVehicleNumber; i++)
            {
                yield return vehicles[i]!;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();

        }


    }
}