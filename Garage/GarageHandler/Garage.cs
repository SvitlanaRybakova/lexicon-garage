using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Vehicles;
using System.Collections;
using Garage.UI;


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

        internal void AddVehicle(T vehicle)
        {
            if (currentVehicleNumber >= maxGarageCapacity)
            {
                throw new InvalidOperationException("Garage is full.");
            }

            vehicles[currentVehicleNumber] = vehicle;
            UserMessages.SuccessMessage($"Vehicle {vehicle.RegistrationNumber} added successfully");
            currentVehicleNumber++;
        }

        internal bool DeleteVehicle(string registrationNumber)
        {
            for (int i = 0; i < currentVehicleNumber; i++)
            {
                if (vehicles[i].RegistrationNumber == registrationNumber.ToUpper())
                {
                    vehicles[i] = null;
                    for (int j = i; j < currentVehicleNumber - 1; j++) // // Shift all vehicles after the removed one to the left by one position.
                    {
                        vehicles[j] = vehicles[j + 1];
                    }
                    vehicles[currentVehicleNumber - 1] = null; //set the last vehicle slot to null
                    currentVehicleNumber--;
                    return true;
                }
            }
            return false;
        }

        internal List<T>? SearchVehicle(string? registrationNumber, string? color, int? numberOfWheels)
        {

            if (currentVehicleNumber == 0) return null;
            List<T> foundedVehicles = new List<T>();
            foreach (var vehicle in vehicles)
            {
                bool matches = false;

                if (!string.IsNullOrEmpty(registrationNumber) && vehicle?.RegistrationNumber.ToUpper() == registrationNumber.ToUpper()) matches = true;
                if (!string.IsNullOrEmpty(color) && vehicle?.Color.ToUpper() == color.ToUpper()) matches = true;
                if (numberOfWheels != null && vehicle?.NumberOfWheels == numberOfWheels) matches = true;

                if (matches) foundedVehicles.Add((T)vehicle);

            }

            return foundedVehicles;
        }

        public Dictionary<string, int> GetVehicleTypesAndCounts()
        {
            Dictionary<string, int> vehicleCounts = new Dictionary<string, int>(); // new collection to write the founded values

            for (int i = 0; i < currentVehicleNumber; i++)
            {
                string vehicleType = vehicles[i].GetType().Name; // the vehicle type name

                if (vehicleCounts.ContainsKey(vehicleType))
                {
                    vehicleCounts[vehicleType]++;
                }
                else
                {
                    vehicleCounts[vehicleType] = 1; // count for new type
                }
            }

            return vehicleCounts;
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