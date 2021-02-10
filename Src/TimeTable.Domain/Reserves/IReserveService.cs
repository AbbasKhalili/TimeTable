using System.Threading.Tasks;
using Framework.Core;

namespace TimeTable.Domain.Reserves
{
    public interface IReserveService : IDomainService
    {
        Task CanReserve(long scheduleId);
    }
}