using AutoPark.Data.Services;
using AutoPark.Data.UserCollection;
using AutoPark.Models.Base;
using AutoPark.Models.Other;
using AutoPark.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark.Data
{
    /// <summary>
    /// Collection context, that helps to work properly with Csv Deseriallizer
    /// </summary>
    public class CollectionContext
    {
        /// <summary>
        /// User collection
        /// </summary>
        public Collections UserCollection { get; set; }

        public string VehicleFilePath { get; set; }

        public string VehicleTypeFilePath { get; set; }

        public string RentFilePath { get; set; }

        public CollectionContext()
        {
            VehicleFilePath = @"Data\Files\vehicles.csv";
            VehicleTypeFilePath = @"Data\Files\types.csv";
            RentFilePath = @"Data\Files\rents.csv";
        }

        public CollectionContext(
            string vehicleFilePath,
            string vehicleTypeFilePath,
            string rentFilePath)
        {
            VehicleFilePath = vehicleFilePath;
            VehicleTypeFilePath = vehicleTypeFilePath;
            RentFilePath = rentFilePath;
        }

        public List<Rent> LoadRents()
        {
            var csvStrings = CsvDeseriallizerService.GetCsvStringsFromFile(RentFilePath);
            var listOfRents = new List<Rent>();

            foreach (var csvString in csvStrings)
            {
                listOfRents.Add(CsvDeseriallizerService.CreateRent(csvString));
            }

            return listOfRents;
        }

        public List<VehicleType> LoadTypes()
        {
            var csvStrings = CsvDeseriallizerService.GetCsvStringsFromFile(VehicleTypeFilePath);
            var listOfTypes = new List<VehicleType>();

            foreach (var csvString in csvStrings)
            {
                listOfTypes.Add(CsvDeseriallizerService.CreateType(csvString));
            }

            return listOfTypes;

        }

        public List<Vehicle> LoadVehicles(IEnumerable<Rent> rents, IEnumerable<VehicleType> types)
        {
            var csvStrings = CsvDeseriallizerService.GetCsvStringsFromFile(VehicleFilePath);
            var listOfVehicles = new List<Vehicle>();

            foreach (var csvString in csvStrings)
            {
                listOfVehicles.Add(CsvDeseriallizerService.CreateVehicle(csvString, rents, types));
            }

            return listOfVehicles;
        }
    }
}
