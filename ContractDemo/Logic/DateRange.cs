namespace ContractDemo.Logic;

public record DateRange(DateTime From, DateTime To) : IDateRange 
{
    public override string ToString()
    {
        return From.ToString("dd.MM.yyyy") + ";" + To.ToString("dd.MM.yyyy");
    }
    public bool Overlaps(DateRange other) => From <= other.To && other.From <= To;

    public IEnumerable<DateRange> Cut(DateRange other)
    {

        if (!Overlaps(other))
        {
            yield return this;
        }
        /*
        * when
        *
        *       ----------------------> current     or             ------------------------->  current
        *   ----------->                other                      ----------->  other
        * then
        *               +1---------->  current                                 +1------------>            current 
        *   ----------->                                           ------------>  other 
        */
        else if (From >= other.From && To > other.To)
        {
            yield return this with { From = other.To.AddDays(1) };
        }
        /*
         * when
         *
         * ----------------------> current     or        ------------------------->  current
         *            -----------> other                                     ----------->  other
         * then
         * --------->-1           current                ----------------->-1           current 
         *            -----------> other                                     -----------> other 
         */
        else if (From < other.From && To <= other.To)
        {
            yield return this with { To = other.From.AddDays(-1) };
        }
        /*
        * when
        *
        * ----------------------> current
        *       -----------> other       
        * then
        * ----->-1            +1----->           current
        *         ----------->                other 
        */
        else if (From < other.From && To > other.To)
        {
            yield return this with { To = other.From.AddDays(-1) };
            yield return this with { From = other.To.AddDays(1) };
        }
    }

    public IEnumerable<DateRange> CutAll(IEnumerable<DateRange> others) => others
    .Aggregate(
        Enumerable.Repeat(this, 1),
        (cuts, other) => cuts.SelectMany(s => s.Cut(other)));

    //almost all operations have the time complexity of O(1) except the CutAll method in which we are using Aggregate

    /*
     * I am basing my Algorithm runtime on the Ram model time complexity 
     *
     * Aggregate: O(n+m) 
     *  Reason:
     *      n is the number of Elements of the Set IEnumerable<DateRange> others
     *      m is the resulting sequence of SelectMany
     */
}