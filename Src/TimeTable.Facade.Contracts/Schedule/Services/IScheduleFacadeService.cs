using System.Threading.Tasks;
using Framework.Core;
using TimeTable.Facade.Contracts.Schedule.ViewModels;

namespace TimeTable.Facade.Contracts.Schedule.Services
{
    public interface IScheduleFacadeService : IFacadeService
    {
        Task<long> Create(ScheduleViewModel model);
        Task Modify(ScheduleViewModel model);
        Task Delete(long id);
    }
}
