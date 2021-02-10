using System.Threading.Tasks;
using Framework.Core;
using TimeTable.Facade.Contracts.Calendar.ViewModels;

namespace TimeTable.Facade.Contracts.Calendar.Services
{
    public interface ICalendarFacadeService : IFacadeService
    {
        Task<bool> Create();
        Task Modify(CalendarViewModel model);
        Task Delete(long id);
    }
}
