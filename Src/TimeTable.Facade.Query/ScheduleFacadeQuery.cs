using System.Collections.Generic;
using System.Threading.Tasks;
using TimeTable.Domain.Schedules;
using TimeTable.Facade.Contracts.Schedule.DTOs;
using TimeTable.Facade.Contracts.Schedule.Services;
using TimeTable.Facade.Query.Mappers;

namespace TimeTable.Facade.Query
{
    public class ScheduleFacadeQuery : IScheduleFacadeQuery
    {
        private readonly IScheduleRepository _repository;

        public ScheduleFacadeQuery(IScheduleRepository repository)
        {
            _repository = repository;
        }

        public async Task<ScheduleDto> GetById(long id)
        {
            var model = await _repository.GetBy(id);
            return ScheduleMapper.Map(model);
        }

        public async Task<List<ScheduleDto>> GetAll()
        {
            var list = await _repository.GetAll();
            return ScheduleMapper.Map(list);
        }
    }
}