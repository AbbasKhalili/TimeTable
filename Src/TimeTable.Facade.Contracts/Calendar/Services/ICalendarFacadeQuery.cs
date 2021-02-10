using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.Core;
using TimeTable.Facade.Contracts.Calendar.DTOs;

namespace TimeTable.Facade.Contracts.Calendar.Services
{
    public interface ICalendarFacadeQuery : IFacadeService
    {
        Task<CalendarDto> GetById(long id);
        Task<List<CalendarDto>> GetAll();
    }
}