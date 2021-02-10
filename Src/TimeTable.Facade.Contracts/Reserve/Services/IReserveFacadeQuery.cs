using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.Core;
using TimeTable.Facade.Contracts.Reserve.DTOs;

namespace TimeTable.Facade.Contracts.Reserve.Services
{
    public interface IReserveFacadeQuery : IFacadeService
    {
        Task<ReserveDto> GetById(long id);
        Task<List<ReserveDto>> GetAll();
    }
}