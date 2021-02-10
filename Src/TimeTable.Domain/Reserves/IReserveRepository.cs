using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.Domain;

namespace TimeTable.Domain.Reserves
{
    public interface IReserveRepository : IRepository<Reserve, long>
    {
        Task<List<Reserve>> GetAll();
        Task<List<Reserve>> GetByTime(DateTime scheduleTime, long scheduleId);
    }
}