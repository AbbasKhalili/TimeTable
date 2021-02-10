using System.Collections.Generic;
using System.Linq;
using TimeTable.Domain.Schedules;
using TimeTable.Facade.Contracts.Schedule.DTOs;

namespace TimeTable.Facade.Query.Mappers
{
    internal class ScheduleMapper
    {
        public static ScheduleDto Map(Schedule model)
        {
            if (model == null) return null;
            return new ScheduleDto
            {
                Id = model.Id,
                CalendarId = model.CalendarId,
                Time = model.Time,
                Capacity = model.Capacity
            };
        }

        public static List<ScheduleDto> Map(List<Schedule> list)
        {
            return list?.Select(Map).ToList();
        }
    }
}