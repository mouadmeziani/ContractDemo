using Autofac;
using ContractDemo.Logic;
using ContractDemo.Model;
using ContractDemo.Repositories;

public class ContainerConfig
{
    public static IContainer ConfigureContainer(string path)
    {
        var builder = new ContainerBuilder();
    
        builder.RegisterType<FileDataRepository>().As<IRepository>()
            .WithParameter("fileLocation", path);
        builder.RegisterType<DataMapper>().As<IDataMapper>();
        builder.RegisterType<ContractManager>().As<IContractManager>();
    
        return builder.Build();
    }
}