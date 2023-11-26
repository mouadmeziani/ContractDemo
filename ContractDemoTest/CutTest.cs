
using ContractDemo.Logic;
using FluentAssertions;
using Xunit;

namespace ContractDemoTest
{

    public class CutTest
    {
        private static DateRange Range(string from, string to) => new(DateTime.Parse(from), DateTime.Parse(to));

        [Fact]
        public void ReturnsLeftSideWhenRightSideDoesNotOverlap() =>
            Range("2019-01-01", "2019-01-10")
                .Cut(Range("2019-01-20", "2019-01-31"))
                .Should().ContainSingle().Which.Should().Be(Range("2019-01-01", "2019-01-10"));

        [Fact]
        public void AbsorbsLeftSideWhenRightSideOverlapsCompletely() =>
            Range("2019-01-10", "2019-01-20")
                .Cut(Range("2019-01-01", "2019-01-31"))
                .Should().BeEmpty();

        [Fact]
        public void MovesStartOfLeftSideWhenRightSideOverlapsBeginning() =>
            Range("2019-01-10", "2019-01-20")
                .Cut(Range("2019-01-01", "2019-01-15"))
                .Should().ContainSingle().Which.Should().Be(Range("2019-01-16", "2019-01-20"));

        [Fact]
        public void MovesEndOfLeftSideWhenRightSideOverlapsEnd() =>
            Range("2019-01-10", "2019-01-20")
                .Cut(Range("2019-01-15", "2019-01-25"))
                .Should().ContainSingle().Which.Should().Be(Range("2019-01-10", "2019-01-14"));

        [Fact]
        public void SplitsLeftSideWhenRightSideIsInside() =>
            Range("2019-01-01", "2019-01-31")
                .Cut(Range("2019-01-15", "2019-01-25"))
                .Should().SatisfyRespectively(
                    dr1 => dr1.Should().Be(Range("2019-01-01", "2019-01-14")),
                    dr2 => dr2.Should().Be(Range("2019-01-26", "2019-01-31")));
    }
}
