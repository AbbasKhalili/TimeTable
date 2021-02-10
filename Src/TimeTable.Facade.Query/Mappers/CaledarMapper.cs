using System.Collections.Generic;
using System.Linq;
using TimeTable.Domain.Calendars;
using TimeTable.Facade.Contracts.Calendar.DTOs;

namespace TimeTable.Facade.Query.Mappers
{
    internal class CaledarMapper
    {
        public static CalendarDto Map(Calendar model)
        {
            if (model == null) return null;
            return new CalendarDto
            {
                Date = model.Date,
                IsHoliday = model.IsHoliday,
                Id = model.Id,
                ToWorkTime = model.ToWorkTime,
                FromWorkTime = model.FromWorkTime
            };
        }

        public static List<CalendarDto> Map(List<Calendar> list)
        {
            return list?.Select(Map).ToList();
        }
    }
}
