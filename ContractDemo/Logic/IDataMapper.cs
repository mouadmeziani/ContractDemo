using ContractDemo.Model;

namespace ContractDemo.Logic;

public interface IDataMapper
{
    public List<Contract> MappingContractsFromString(IEnumerable<string> contractData);
}