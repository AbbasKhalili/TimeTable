using System;

namespace TimeTable.Facade.Contracts.Schedule.ViewModels
{
    public class ScheduleViewModel
    {
        public long Id { get; set; }
        public long CalendarId { get; set; }
        public DateTime Time { get; set; }
        public int Capacity { get; set; }
    }
}
