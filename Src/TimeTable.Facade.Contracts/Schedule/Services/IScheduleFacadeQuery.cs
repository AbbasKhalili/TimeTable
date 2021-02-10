using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.Core;
using TimeTable.Facade.Contracts.Schedule.DTOs;

namespace TimeTable.Facade.Contracts.Schedule.Services
{
    public interface IScheduleFacadeQuery : IFacadeService
    {
        Task<ScheduleDto> GetById(long id);
        Task<List<ScheduleDto>> GetAll();
    }
}