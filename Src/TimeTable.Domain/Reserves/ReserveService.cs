using System;
using System.Threading.Tasks;
using Framework.Core.Exceptions;
using TimeTable.Domain.Exceptions;
using TimeTable.Domain.Schedules;

namespace TimeTable.Domain.Reserves
{
    public class ReserveService : IReserveService
    {
        private readonly IReserveRepository _reserveRepository;
        private readonly IScheduleRepository _scheduleRepository;
        public ReserveService(IReserveRepository reserveRepository, IScheduleRepository scheduleRepository)
        {
            _reserveRepository = reserveRepository;
            _scheduleRepository = scheduleRepository;
        }

        public async Task CanReserve(long scheduleId)
        {
            var schedule = await _scheduleRepository.GetBy(scheduleId);
            
            Guard<ScheduleNotFoundException>.AgainstNull(schedule);

            var reservedList = await _reserveRepository.GetByTime(schedule.Time, scheduleId);

            if (reservedList.Count >= schedule.Capacity)
                throw new NoCapacityException();

            var now = DateTime.Now.AddHours(2);
            if (new DateTime(1, 1, 1, now.Hour, now.Minute, now.Second) > schedule.Time)
                throw new ReserveTimeException();
        }
    }
}