using AutoPark.Controllers.Base;
using AutoPark.Data.Services;
using AutoPark.Views.OutputService.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark.Controllers
{
    public class DictionaryController : IController
    {
        private readonly string _filePath;
        private readonly IOutputService _outputService;
        private readonly Dictionary<string, int> _orders;
        private void PrintOrders()
        {
            if (_orders.Count > 0)
            {
                foreach (var order in _orders)
                {
                    _outputService.ShowStringWithLineBreak($"{order.Key} : {order.Value}");
                }
            }
        }
        public DictionaryController(string filePath, IOutputService outputService)
        {
            _filePath = filePath;
            _outputService = outputService;
            _orders = new Dictionary<string, int>();
        }

        public void RunController()
        {
            var parsedStrings = CsvDeseriallizerService.GetCsvStringsFromFile(_filePath);
            var listOfOrders = new List<string>();
            foreach (var csvString in parsedStrings)
            {
                listOfOrders.AddRange(CsvDeseriallizerService.DeserializeOrders(csvString));
            }
            foreach (var order in listOfOrders)
            {
                if (_orders.ContainsKey(order))
                {
                    _orders[order]++; 
                }
                else
                {
                    _orders.Add(order, 1);
                }
            }
            PrintOrders();
        }
    }
}
