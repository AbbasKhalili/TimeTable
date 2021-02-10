using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.Core;
using Framework.Core.Exceptions;
using TimeTable.Domain.Calendars;
using TimeTable.Facade.Contracts.Calendar.Services;
using TimeTable.Facade.Contracts.Calendar.ViewModels;

namespace TimeTable.Facade.Service
{
    public class CalendarFacadeService : ICalendarFacadeService
    {
        private readonly ICalendarRepository _repository;
        private readonly ISystemClock _clock;

        public CalendarFacadeService(ICalendarRepository repository, ISystemClock clock)
        {
            _repository = repository;
            _clock = clock;
        }

        public async Task<bool> Create()
        {
            var now = _clock.ReturnNow();
            var exists = await _repository.GetByDate(now.Date);
            if (exists != null) return false;

            var list = new List<Calendar>();
            for (var i = 1; i < 366; i++)
            {
                var day = now.AddDays(i);
                list.Add(new Calendar(day, day.DayOfWeek == DayOfWeek.Friday, default, default));
            }

            await _repository.Create(list);
            return true;
        }

        public async Task Modify(CalendarViewModel model)
        {
            var calendar = await _repository.GetBy(model.Id);
            calendar.Modify(model.IsHoliday, model.FromWorkTime, model.ToWorkTime);

            Guard<EntityNotFoundException>.AgainstNull(calendar);

            await _repository.Update(calendar);
        }

        public async Task Delete(long id)
        {
            var calendar = await _repository.GetBy(id);

            if (calendar == null) return;

            await _repository.Delete(calendar);
        }
    }
}
