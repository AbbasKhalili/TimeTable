using System.Threading.Tasks;
using Framework.Core.Exceptions;
using TimeTable.Domain.Schedules;
using TimeTable.Facade.Contracts.Schedule.Services;
using TimeTable.Facade.Contracts.Schedule.ViewModels;

namespace TimeTable.Facade.Service
{
    public class ScheduleFacadeService : IScheduleFacadeService
    {
        private readonly IScheduleRepository _repository;
        private readonly IScheduleService _scheduleService;

        public ScheduleFacadeService(IScheduleRepository repository, IScheduleService scheduleService)
        {
            _repository = repository;
            _scheduleService = scheduleService;
        }

        public async Task<long> Create(ScheduleViewModel model)
        {
            var schedule = await Schedule.CreateSchedule(model.CalendarId, model.Time, model.Capacity, _scheduleService);
            await _repository.Create(schedule);
            return schedule.Id;
        }

        public async Task Modify(ScheduleViewModel model)
        {
            var schedule = await _repository.GetBy(model.Id);
            
            Guard<EntityNotFoundException>.AgainstNull(schedule);

            schedule.Modify(model.Capacity);
            await _repository.Update(schedule);
        }

        public async Task Delete(long id)
        {
            var schedule = await _repository.GetBy(id);

            if (schedule == null) return;

            await _repository.Delete(schedule);
        }
    }
}