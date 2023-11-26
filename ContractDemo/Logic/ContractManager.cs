using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContractDemo.Model;

namespace ContractDemo.Logic
{
    public class ContractManager 
    {
        public static IEnumerable<Contract> Flatten(List<Contract> contracts)
        {
            List<Contract> result = new List<Contract>();
            for (var i = 0; i < contracts.Count; i++)
            {
                var current = contracts[i];
                var successors = contracts[(i + 1)..];
                var subDateRanges = current.Period.CutAll(successors.Select(c => c.Period));

                result.AddRange(subDateRanges.Select(dr => new Contract(dr, current.Price, current.Priority)));
            }
            return result;
        }

    }
}
