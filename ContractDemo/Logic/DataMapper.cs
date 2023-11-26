using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContractDemo.Model;

namespace ContractDemo.Logic
{
    public class DataMapper : IDataMapper
    {
        public List<Contract> MappingContractsFromString(IEnumerable<string> contractData)
        {
            List<Contract> contracts = new List<Contract>();

            foreach (var line in contractData)
            {

                // Split the line into values using ; (csv format)
                var values = line.Split(';');

                // Extract values from the array
                // assuming that the data is in german date format
                DateTime.TryParseExact(values[0], "dd.MM.yyyy", CultureInfo.GetCultureInfo("de-DE"), DateTimeStyles.None,
                    out DateTime from);
                DateTime.TryParseExact(values[1], "dd.MM.yyyy", CultureInfo.GetCultureInfo("de-DE"), DateTimeStyles.None,
                    out DateTime to);
                decimal price = decimal.Parse(values[2], CultureInfo.GetCultureInfo("de-DE"));
                int priority = int.Parse(values[3]);


                // Create a DateRange object using the provided constructor
                DateRange period = new DateRange(from, to);


                // Create a Contract object using the provided constructor
                Contract contract = new Contract(period, price, priority);

                // Add the contract to the list
                contracts.Add(contract);
            }
            return contracts;
        }
    }
}
