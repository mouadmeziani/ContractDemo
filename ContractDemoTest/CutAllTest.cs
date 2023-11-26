
using ContractDemo.Logic;
using FluentAssertions;
using Xunit;

namespace ContractDemoTest
{
    public class CutAll
    {
        private static DateRange Range(string from, string to) => new(DateTime.Parse(from), DateTime.Parse(to));

        [Fact]
        public void CutsLeftSideByAllFromRightSide() =>
            Range("2019-02-01", "2019-02-28")
                .CutAll(new[] {
                    Range("2019-01-01", "2019-02-03"), 
                    Range("2019-02-10", "2019-02-15"),
                    Range("2019-02-25", "2019-03-31")
                })
        .Should().SatisfyRespectively
        (
            dr1 => dr1.Should().Be(Range("2019-02-04", "2019-02-09")),
            dr2 => dr2.Should().Be(Range("2019-02-16", "2019-02-24"))
        );

        [Fact]
        public void ReturnsLeftSideWhenRightSideIsEmpty() =>
            Range("2019-02-01", "2019-02-28")
                .CutAll(new DateRange[] { })
        .Should().ContainSingle().Which.Should().Be(Range("2019-02-01", "2019-02-28"));



    }

}
