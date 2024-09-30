namespace Garage
{
    public class Constants
    {
        public enum FuelType
        {
            Benzin,
            Diesel
        }

        public enum NumberOfEngines
        {
            One = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            SixOrMore = 6
        }


        public enum MainMenuOptions
        {
            Exit = 0,
            PrintAllVehicles = 1,
            PrintVehicleTypesAndCounts = 2,
            AddOrRemoveVehicles = 3,
            SearchVehicles = 4,
            CreateNewGarage = 5
        }
    }
}