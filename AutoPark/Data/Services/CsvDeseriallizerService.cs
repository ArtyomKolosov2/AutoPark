using AutoPark.Models.Base;
using AutoPark.Models.Engines;
using AutoPark.Models.Other;
using AutoPark.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark.Data.Services
{
    public static class CsvDeseriallizerService
    {
        private const string CSV_EXTENSION = ".csv";
        private const char CSV_SEPARATOR = ',';
        private const char CSV_NEWLINE = '\n';
        public static List<string> GetCsvStringsFromFile(string inFile)
        {
            if (File.Exists(inFile) && new FileInfo(inFile).Extension == CSV_EXTENSION)
            {
                var result = new List<string>();
                using var textStream = new StreamReader(inFile);
                var csvStrings = textStream.ReadToEnd().Split
                    (
                    CSV_NEWLINE,
                    StringSplitOptions.RemoveEmptyEntries |
                    StringSplitOptions.TrimEntries
                    );
                result.AddRange(csvStrings);
                return result;
            }
            throw new ArgumentException("Invalid csv file path!");
        }
        public static Rent CreateRent(string csvString)
        {
            if (csvString is not null)
            {
                var fields = csvString.Split(CSV_SEPARATOR, StringSplitOptions.TrimEntries);
                var vehicleId = int.Parse(fields[0]);
                var orderDate = DateTime.Parse(fields[1]);
                var cost = decimal.Parse(fields[2]);
                return new Rent(vehicleId, orderDate, cost);
            }
            throw new ArgumentNullException(nameof(csvString), "Csv string was null!");
        }
        public static VehicleType CreateType(string csvString)
        {
            if (csvString is not null)
            {
                var fields = csvString.Split(CSV_SEPARATOR, StringSplitOptions.TrimEntries);
                var id = int.Parse(fields[0]);
                var vehicleTypeName = fields[1];
                var taxCoeff = decimal.Parse(fields[2]);
                return new VehicleType(id, vehicleTypeName, taxCoeff);
            }
            throw new ArgumentNullException(nameof(csvString), "Csv string was null!");
        }
        public static Vehicle CreateVehicle(string csvString, IEnumerable<Rent> rents, IEnumerable<VehicleType> types)
        {
            if (csvString is not null)
            {
                var fields = csvString.Split(CSV_SEPARATOR, StringSplitOptions.TrimEntries);
                var id = int.Parse(fields[0]);
                var type = types.FirstOrDefault(type => type.Id == int.Parse(fields[1]));
                var modelName = fields[2];
                var registrationNumber = fields[3];
                var weight = int.Parse(fields[4]);
                var manufactureYear = int.Parse(fields[5]);
                var mileage = int.Parse(fields[6]);
                var color = Enum.Parse<Colors>(fields[7]);
                var engineType = fields[8];

                AbstractEngine engine = engineType switch
                {
                    EngineTypeConstants.DIESEL =>
                        new DieselEngine(double.Parse(fields[9]), double.Parse(fields[10]), int.Parse(fields[11])),
                    EngineTypeConstants.GASOLINE =>
                        new GasolineEngine(double.Parse(fields[9]), double.Parse(fields[10]), int.Parse(fields[11])),
                    EngineTypeConstants.ELECTRICAL =>
                        new ElectricalEngine(double.Parse(fields[9]), int.Parse(fields[11])),
                    _ => throw new FormatException("Some engine data doesn't have valid format!"),
                };

                var resultVehicle = new Vehicle
                (
                    id,
                    type,
                    engine,
                    modelName,
                    registrationNumber,
                    weight,
                    manufactureYear,
                    mileage,
                    color
                );
                resultVehicle.Rents = rents.Where(rent => rent.VehicleId == id).ToList();
                return resultVehicle;
            }
            throw new ArgumentNullException(nameof(csvString), "Csv string was null!");

        }
    }
}
