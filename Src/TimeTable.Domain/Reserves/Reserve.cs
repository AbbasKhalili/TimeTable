using System.Threading.Tasks;
using Framework.Domain;
using TimeTable.Domain.Schedules;

namespace TimeTable.Domain.Reserves
{
    public class Reserve : EntityBase<long>
    {
        public long ScheduleId { get; private set; }
        public string Name { get; private set; }


        public Schedule Schedule { get; private set; }


        protected Reserve() { }

        private Reserve(long scheduleId, string name)
        {
            ScheduleId = scheduleId;
            Name = name;
        }
        public static async Task<Reserve> DoReserve(long scheduleId, string name, IReserveService reserveService)
        {
            await reserveService.CanReserve(scheduleId);
            return new Reserve(scheduleId, name);
        }
    }
}