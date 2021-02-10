using System;
using System.Collections.Generic;
using Framework.Domain;
using TimeTable.Domain.Schedules;

namespace TimeTable.Domain.Calendars
{
    public class Calendar : EntityBase<long>
    {
        public DateTime Date { get; private set; }
        public bool IsHoliday { get; private set; }
        public DateTime FromWorkTime { get; private set; }
        public DateTime ToWorkTime { get; private set; }


        public List<Schedule> Schedules { get; private set; }

        protected Calendar() { }
        public Calendar(DateTime date, bool isHoliday, DateTime fromWorkTime, DateTime toWorkTime)
        {
            Date = date;
            SetProperties(isHoliday, fromWorkTime, toWorkTime);
        }

        public void Modify(bool isHoliday, DateTime fromWorkTime, DateTime toWorkTime)
        {
            SetProperties(isHoliday, fromWorkTime, toWorkTime);
        }

        private void SetProperties(bool isHoliday, DateTime fromWorkTime, DateTime toWorkTime)
        {
            IsHoliday = isHoliday;
            FromWorkTime = fromWorkTime;
            ToWorkTime = toWorkTime;
            
            if (!IsHoliday) return;
            
            FromWorkTime = default;
            ToWorkTime = default;
        }
    }
}
