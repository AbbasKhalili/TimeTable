using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.Domain;

namespace TimeTable.Domain.Calendars
{
    public interface ICalendarRepository : IRepository<Calendar,long>
    {
        Task Create(List<Calendar> list);
        Task<Calendar> GetByDate(DateTime date);
        Task<List<Calendar>> GetAll();
    }
}