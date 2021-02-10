using System;
using System.Threading.Tasks;
using NSubstitute;
using TimeTable.Domain.Schedules;

namespace TimeTable.Tests.Tools.ScheduleTools
{
    public class ScheduleBuilder
    {
        private long CalendarId { get; set; }
        private DateTime Time { get; set; }
        private int Capacity { get; set; }

        private IScheduleService ScheduleService { get; set; }

        public ScheduleBuilder()
        {
            CalendarId = ScheduleConst.CalendarId;
            Time = ScheduleConst.Time;
            Capacity = ScheduleConst.Capacity;

            ScheduleService = Substitute.For<IScheduleService>();
        }

        public async Task<Schedule> Build()
        {
            return await Schedule.CreateSchedule(CalendarId,Time,Capacity,ScheduleService);
        }
        public ScheduleBuilder WithTime(DateTime time)
        {
            Time = time;
            return this;
        }
        public ScheduleBuilder WithService(IScheduleService service)
        {
            ScheduleService = service;
            return this;
        }
    }
}