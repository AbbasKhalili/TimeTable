using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.Domain;

namespace TimeTable.Domain.Schedules
{
    public interface IScheduleRepository : IRepository<Schedule, long>
    {
        Task<List<Schedule>> GetAll();
    }
}