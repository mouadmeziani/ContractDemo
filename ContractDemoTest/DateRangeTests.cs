
using ContractDemo.Logic;
using FluentAssertions;
using Xunit;

namespace ContractDemoTest
{

    public static class DateRangeTests
    {
        public class Overlaps
        {
            [Fact]
            public void ReturnsFalseWhenRangesDontOverlap1() =>
                Range("2019-01-01", "2019-01-15")
                .Overlaps(Range("2019-01-20", "2019-01-31"))
                .Should().BeFalse();

            [Fact]
            public void ReturnsFalseWhenRangesDontOverlap2() =>
                Range("2019-01-20", "2019-01-31")
                .Overlaps(Range("2019-01-01", "2019-01-15"))
                .Should().BeFalse();

            [Fact]
            public void ReturnsTrueWhenRangesOverlap1() =>
                Range("2019-01-01", "2019-01-20")
                .Overlaps(Range("2019-01-15", "2019-01-31"))
                .Should().BeTrue();

            [Fact]
            public void ReturnsTrueWhenRangesOverlap2() =>
                Range("2019-01-15", "2019-01-31")
                .Overlaps(Range("2019-01-01", "2019-01-20"))
                .Should().BeTrue();

            [Fact]
            public void ReturnsTrueWhenRangesOverlap3() =>
                Range("2019-01-01", "2019-01-31")
                .Overlaps(Range("2019-01-10", "2019-01-20"))
                .Should().BeTrue();

            [Fact]
            public void ReturnsTrueWhenRangesOverlap4() =>
                Range("2019-01-10", "2019-01-20")
                .Overlaps(Range("2019-01-01", "2019-01-31"))
                .Should().BeTrue();
        }

        private static DateRange Range(string from, string to) => new(DateTime.Parse(from), DateTime.Parse(to));
    }
}