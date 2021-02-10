using System.Threading;
using System.Threading.Tasks;
using TimeTable.Domain.Reserves;
using TimeTable.Facade.Contracts.Reserve.Services;
using TimeTable.Facade.Contracts.Reserve.ViewModels;

namespace TimeTable.Facade.Service
{
    public class ReserveFacadeService : IReserveFacadeService
    {
        private readonly IReserveService _reserveService;
        private readonly IReserveRepository _repository;
        private static readonly SemaphoreSlim SemaphoreSlim = new SemaphoreSlim(1, 1);

        public ReserveFacadeService(IReserveRepository repository, IReserveService reserveService)
        {
            _repository = repository;
            _reserveService = reserveService;
        }

        public async Task<long> Create(ReserveViewModel model)
        {
            Reserve reserve;
            await SemaphoreSlim.WaitAsync();
            try
            {
                reserve = await Reserve.DoReserve(model.ScheduleId, model.Name,_reserveService);
                await _repository.Create(reserve);
            }
            finally
            {
                SemaphoreSlim.Release();
            }
            return reserve.Id;
        }
        
        public async Task Delete(long id)
        {
            var reserve = await _repository.GetBy(id);

            if (reserve == null) return;

            await _repository.Delete(reserve);
        }
    }
}