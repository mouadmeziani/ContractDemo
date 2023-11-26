using ContractDemo.Logic;
using ContractDemo.Model;
using Autofac;
using ContractDemo.Repositories;

var path = args[0];

var contracts = new List<Contract>();
var container = ContainerConfig.ConfigureContainer(path);

using (var scope = container.BeginLifetimeScope())
{
    var dataRepository = container.Resolve<IRepository>();

    try
    {
        var inputLines = dataRepository.GetAll().Skip(1);
        contracts = DataMapper.MappingContractsFromString(inputLines);
        (dataRepository as FileDataRepository)?.OverrideOrWriteToFile(contracts);
        ((List<Contract>)ContractManager.Flatten(contracts)).ForEach(Console.WriteLine);
    }
    catch (FileNotFoundException exception)
    {
        Console.Error.WriteLine(exception.Message);
    }
}