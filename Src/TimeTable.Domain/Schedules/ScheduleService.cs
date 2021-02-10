using System;
using System.Threading.Tasks;
using Framework.Core.Exceptions;
using TimeTable.Domain.Calendars;
using TimeTable.Domain.Exceptions;

namespace TimeTable.Domain.Schedules
{
    public class ScheduleService : IScheduleService
    {
        private readonly ICalendarRepository _calendarRepository;

        public ScheduleService(ICalendarRepository calendarRepository)
        {
            _calendarRepository = calendarRepository;
        }

        public async Task CanDefine(long calendarId, DateTime time)
        {
            var calendar = await _calendarRepository.GetBy(calendarId);
            Guard<CalendarNotFoundException>.AgainstNull(calendar);

            Guard<DefineScheduleInHolidayException>.IsTrue(calendar.IsHoliday);

            if (calendar.FromWorkTime> time || calendar.ToWorkTime< time)
                throw new DefineScheduleOutOfWorkTimeException();
        }
    }
}