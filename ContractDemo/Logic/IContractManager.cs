using ContractDemo.Model;

namespace ContractDemo.Logic;

public interface IContractManager
{
    public IEnumerable<Contract> Flatten(List<Contract> contracts);
}