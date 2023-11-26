using ContractDemo.Logic;
using ContractDemo.Model;
using System.Globalization;
using ContractDemo;

string path = args[0];

//Importing the Csv and Put in it in the contractList
//please use autfac di later
// skip 1 because the first line is considered as a header(no data only data defintion)

// Parse each line and create Contract objects
IDataRepository dataRepository = new FileDataRepository();
IDataMapper dataMapper = new DataMapper();
IContractManager contractManager = new ContractManager();

var inputLines = dataRepository.LoadData(path).Skip(1);
List<Contract> contracts = dataMapper.MappingContractsFromString(inputLines);
((List<Contract>)contractManager.Flatten(contracts)).ForEach(Console.WriteLine);

