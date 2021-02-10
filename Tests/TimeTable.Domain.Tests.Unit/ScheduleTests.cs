using System;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using TimeTable.Domain.Calendars;
using TimeTable.Domain.Exceptions;
using TimeTable.Domain.Schedules;
using TimeTable.Tests.Tools.CalendarTools;
using TimeTable.Tests.Tools.ScheduleTools;
using Xunit;

namespace TimeTable.Domain.Tests.Unit
{
    public class ScheduleTests : DomainUnitTestBase<ScheduleBuilder>
    {
        private readonly CalendarBuilder _calendarBuilder;

        public ScheduleTests()
        {
            _calendarBuilder = new CalendarBuilder();
        }

        [Fact]
        public async Task CreateSchedule_should_create_schedule_properly()
        {
            var schedule = await Builder.Build();

            schedule.CalendarId.Should().Be(ScheduleConst.CalendarId);
            schedule.Time.Should().Be(ScheduleConst.Time);
            schedule.Capacity.Should().Be(ScheduleConst.Capacity);
        }

        [Fact]
        public void CreateSchedule_should_throw_when_calendar_notFound()
        {
            var calendarRepository = Substitute.For<ICalendarRepository>();
            var service = new ScheduleService(calendarRepository);
            
            Func<Task> schedule = async () => await Builder.WithService(service).Build();

            schedule.Should().Throw<CalendarNotFoundException>();
        }

        [Fact]
        public void CreateSchedule_should_throw_when_define_schedule_in_Holiday()
        {
            var calendarRepository = Substitute.For<ICalendarRepository>();
            calendarRepository.GetBy(1).Returns(_calendarBuilder.WithHoliday(CalendarModifyConst.IsHoliday).Build());
            var service = new ScheduleService(calendarRepository);

            Func<Task> schedule = async () => await Builder.WithService(service).Build();

            schedule.Should().Throw<DefineScheduleInHolidayException>();
        }

        [Fact]
        public void CreateSchedule_should_throw_when_define_schedule_out_of_work_time()
        {
            var calendarRepository = Substitute.For<ICalendarRepository>();
            calendarRepository.GetBy(1).Returns(_calendarBuilder.Build());
            var service = new ScheduleService(calendarRepository);

            Func<Task> schedule = async () =>
                await Builder.WithService(service).WithTime(new DateTime(1, 1, 1, 22, 0, 0)).Build();

            schedule.Should().Throw<DefineScheduleOutOfWorkTimeException>();
        }

        [Fact]
        public async Task Modify_should_change_the_schedule_properly()
        {
            var schedule = await Builder.Build();

            schedule.Modify(ScheduleModifyConst.Capacity);

            schedule.CalendarId.Should().Be(ScheduleConst.CalendarId);
            schedule.Time.Should().Be(ScheduleConst.Time);
            schedule.Capacity.Should().Be(ScheduleModifyConst.Capacity);
        }
    }
}