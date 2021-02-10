using System.Threading.Tasks;
using Framework.Core;
using TimeTable.Facade.Contracts.Reserve.ViewModels;

namespace TimeTable.Facade.Contracts.Reserve.Services
{
    public interface IReserveFacadeService : IFacadeService
    {
        Task<long> Create(ReserveViewModel model);
        Task Delete(long id);
    }
}
