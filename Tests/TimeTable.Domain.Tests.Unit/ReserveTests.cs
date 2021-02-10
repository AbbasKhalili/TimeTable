using System;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using TimeTable.Domain.Calendars;
using TimeTable.Domain.Exceptions;
using TimeTable.Domain.Reserves;
using TimeTable.Domain.Schedules;
using TimeTable.Tests.Tools.ReserveTools;
using Xunit;

namespace TimeTable.Domain.Tests.Unit
{
    public class ReserveTests : DomainUnitTestBase<ReserveBuilder>
    {
        [Fact]
        public async Task DoReserve_should_create_Reserve_properly()
        {
            var reserve = await Builder.Build();

            reserve.ScheduleId.Should().Be(ReserveConst.ScheduleId);
            reserve.Name.Should().Be(ReserveConst.Name);
        }

        [Fact]
        public void CreateSchedule_should_throw_when_calendar_notFound()
        {
            var reserveRepository = Substitute.For<IReserveRepository>();
            var scheduleRepository = Substitute.For<IScheduleRepository>();
            var service = new ReserveService(reserveRepository, scheduleRepository);

            Func<Task> schedule = async () => await Builder.WithService(service).Build();

            schedule.Should().Throw<ScheduleNotFoundException>();
        }
    }
}