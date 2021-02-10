using System;

namespace TimeTable.Facade.Contracts.Schedule.DTOs
{
    public class ScheduleDto
    {
        public long Id { get; set; }
        public long CalendarId { get; set; }
        public DateTime Time { get; set; }
        public int Capacity { get; set; }
    }
}
