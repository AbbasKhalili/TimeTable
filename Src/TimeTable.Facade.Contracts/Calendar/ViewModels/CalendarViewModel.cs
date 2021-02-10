using System;

namespace TimeTable.Facade.Contracts.Calendar.ViewModels
{
    public class CalendarViewModel
    {
        public long Id { get; set; }
        public bool IsHoliday { get; set; }
        public DateTime FromWorkTime { get; set; }
        public DateTime ToWorkTime { get; set; }
    }
}
