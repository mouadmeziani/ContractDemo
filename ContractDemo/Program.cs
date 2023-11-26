using ContractDemo.Logic;
using ContractDemo.Model;
using Autofac;
using ContractDemo.Repositories;

string path = args[0];

var contracts = new List<Contract>();
var container = ContainerConfig.ConfigureContainer(path);

using (var scope = container.BeginLifetimeScope())
{
    IRepository dataRepository = container.Resolve<IRepository>();
    IDataMapper dataMapper = container.Resolve<IDataMapper>();
    IContractManager contractManager = container.Resolve<IContractManager>();
    try
    {
        var inputLines = dataRepository.GetAll().Skip(1);
        contracts = dataMapper.MappingContractsFromString(inputLines);
        (dataRepository as FileDataRepository).OverrideOrWriteToFile(contracts);
        ((List<Contract>)contractManager.Flatten(contracts)).ForEach(Console.WriteLine);
    }
    catch (FileNotFoundException exception)
    {
        Console.Error.WriteLine(exception.Message);
    }
}