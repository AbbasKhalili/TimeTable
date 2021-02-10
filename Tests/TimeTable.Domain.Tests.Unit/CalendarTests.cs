using FluentAssertions;
using TimeTable.Tests.Tools.CalendarTools;
using Xunit;

namespace TimeTable.Domain.Tests.Unit
{
    public class CalendarTests : DomainUnitTestBase<CalendarBuilder>
    {
        [Fact]
        public void Constructor_should_create_calendar_properly()
        {
            var calendar = Builder.Build();

            calendar.IsHoliday.Should().Be(CalendarConst.IsHoliday);
            calendar.Date.Should().Be(CalendarConst.Date);
            calendar.FromWorkTime.Should().Be(CalendarConst.FromWorkTime);
            calendar.ToWorkTime.Should().Be(CalendarConst.ToWorkTime);
        }

        [Fact]
        public void Modify_should_change_the_calendar_properly()
        {
            var calendar = Builder.Build();

            calendar.Modify(CalendarConst.IsHoliday, CalendarModifyConst.FromWorkTime, CalendarModifyConst.ToWorkTime);

            calendar.IsHoliday.Should().Be(CalendarConst.IsHoliday);
            calendar.Date.Should().Be(CalendarConst.Date);
            calendar.FromWorkTime.Should().Be(CalendarModifyConst.FromWorkTime);
            calendar.ToWorkTime.Should().Be(CalendarModifyConst.ToWorkTime);
        }

        [Fact]
        public void When_Calendar_is_holiday_FromTime_ToTime_Should_be_null()
        {
            var calendar = Builder.WithHoliday(CalendarModifyConst.IsHoliday).Build();

            calendar.IsHoliday.Should().Be(CalendarModifyConst.IsHoliday);
            calendar.Date.Should().Be(CalendarConst.Date);
            calendar.FromWorkTime.Should().Be(default);
            calendar.ToWorkTime.Should().Be(default);
        }
    }
}
