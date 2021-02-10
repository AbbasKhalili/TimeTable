using System;
using TimeTable.Domain.Calendars;

namespace TimeTable.Tests.Tools.CalendarTools
{
    public class CalendarBuilder
    {
        private DateTime Date { get; set; }
        private bool IsHoliday { get; set; }
        private DateTime FromWorkTime { get; set; }
        private DateTime ToWorkTime { get; set; }

        public CalendarBuilder()
        {
            Date = CalendarConst.Date;
            IsHoliday = CalendarConst.IsHoliday;
            FromWorkTime = CalendarConst.FromWorkTime;
            ToWorkTime = CalendarConst.ToWorkTime;
        }

        public Calendar Build()
        {
            return new Calendar(Date, IsHoliday, FromWorkTime, ToWorkTime);
        }
        public CalendarBuilder WithHoliday(bool isHoliday)
        {
            IsHoliday = isHoliday;
            return this;
        }
        public CalendarBuilder WithFromTime(DateTime from)
        {
            FromWorkTime = from;
            return this;
        }
        public CalendarBuilder WithToTime(DateTime to)
        {
            ToWorkTime = to;
            return this;
        }
    }
}