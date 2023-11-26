using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContractDemo.Model;

namespace ContractDemo.Repositories
{
    public class FileDataRepository : IRepository
    {
        public string fileLocation { get; }
        
        public FileDataRepository()
        {
            
        }
        public FileDataRepository(string fileLocation)
        {
            this.fileLocation = fileLocation;
        }
        public IEnumerable<string> GetFileData()
        {
            if (File.Exists(fileLocation))
            {
                var data = File.ReadAllLines(fileLocation);
                return data;
            }

            // Handle exceptions (e.g., file not found, access denied)
            throw new FileNotFoundException($"Error loading data from file: {fileLocation}");
        }
        //IEnumerable<String> with ReadAllLines or String with ReadAllText?
        public IEnumerable<string> GetAll()
        {
            return GetFileData();
        }

        public void OverrideOrWriteToFile(List<Contract> linesToWrite)
        {
            string newFileLocation = 
                $"{Path.GetDirectoryName(fileLocation)}\\" +
                $"{Path.GetFileNameWithoutExtension($"{fileLocation}")}" +
                $"_Output{Path.GetExtension(fileLocation)}";

            FileMode fileMode = File.Exists(newFileLocation) ? FileMode.Create : FileMode.CreateNew;
            var fileStream = new FileStream(newFileLocation, fileMode);
            using (var writer = new StreamWriter(fileStream))
            {
                linesToWrite.ForEach(writer.WriteLine);
            }
        }
    }
}
