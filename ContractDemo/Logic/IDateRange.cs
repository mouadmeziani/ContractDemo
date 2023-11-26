namespace ContractDemo.Logic;

public interface IDateRange
{
    //Interface Segregation Principle: Clients should not be forced to depend on interfaces they don’t use.
    // that's why I didn't include CutAll
    IEnumerable<DateRange> Cut(DateRange other);
}