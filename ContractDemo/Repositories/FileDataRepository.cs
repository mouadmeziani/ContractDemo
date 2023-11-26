using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractDemo.Repositories
{
    public class FileDataRepository : IDataRepository
    {
        //IEnumerable<String> with ReadAllLines or String with ReadAllText?
        public IEnumerable<string> LoadData(string filePath)
        {
            if (File.Exists(filePath))
            {
                var data = File.ReadAllLines(filePath);
                return data;
            }

            // Handle exceptions (e.g., file not found, access denied)
            throw new FileNotFoundException($"Error loading data from file: {filePath}");

            //Later add also the case with Unauthorized access 
        }
    }
}
