using System;

namespace TimeTable.Facade.Contracts.Calendar.DTOs
{
    public class CalendarDto
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public bool IsHoliday { get; set; }
        public DateTime FromWorkTime { get; set; }
        public DateTime ToWorkTime { get; set; }
    }
}
