using System.Globalization;
using ContractDemo.Logic;


namespace ContractDemo.Model;
public record Contract(DateRange Period, decimal Price, int Priority)
{
    public override string ToString()
    {
        return Period + ";" + Price + ";" + Priority;
    }
}