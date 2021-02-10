using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.Domain;
using TimeTable.Domain.Calendars;
using TimeTable.Domain.Reserves;

namespace TimeTable.Domain.Schedules
{
    public class Schedule : EntityBase<long>
    {
        public long CalendarId { get; private set; }
        public DateTime Time { get; private set; }
        public int Capacity { get; private set; }


        public Calendar Calendar { get; private set; }
        public List<Reserve> Reserves { get; private set; }

        protected Schedule() { }

        private Schedule(long calendarId, DateTime time, int capacity)
        {
            CalendarId = calendarId;
            Time = time;
            SetProperties(capacity);
        }
        public static async Task<Schedule> CreateSchedule(long calendarId, DateTime time, int capacity, IScheduleService scheduleService)
        {
            await scheduleService.CanDefine(calendarId, time);
            return new Schedule(calendarId, time, capacity);
        }
        
        public void Modify(int capacity)
        {
            SetProperties(capacity);
        }

        private void SetProperties(int capacity)
        {
            Capacity = capacity;
        }
    }
}