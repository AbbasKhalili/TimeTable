using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeTable.Domain.Calendars;
using TimeTable.Facade.Contracts.Calendar.DTOs;
using TimeTable.Facade.Contracts.Calendar.Services;
using TimeTable.Facade.Query.Mappers;

namespace TimeTable.Facade.Query
{
    public class CalendarFacadeQuery : ICalendarFacadeQuery
    {
        private readonly ICalendarRepository _repository;

        public CalendarFacadeQuery(ICalendarRepository repository)
        {
            _repository = repository;
        }

        public async Task<CalendarDto> GetById(long id)
        {
            var model = await _repository.GetBy(id);
            return CaledarMapper.Map(model);
        }

        public async Task<List<CalendarDto>> GetAll()
        {
            var list = await _repository.GetAll();
            return CaledarMapper.Map(list);
        }
    }
}
