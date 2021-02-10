using System.Collections.Generic;
using System.Threading.Tasks;
using TimeTable.Domain.Reserves;
using TimeTable.Facade.Contracts.Reserve.DTOs;
using TimeTable.Facade.Contracts.Reserve.Services;
using TimeTable.Facade.Query.Mappers;

namespace TimeTable.Facade.Query
{
    public class ReserveFacadeQuery : IReserveFacadeQuery
    {
        private readonly IReserveRepository _repository;

        public ReserveFacadeQuery(IReserveRepository repository)
        {
            _repository = repository;
        }

        public async Task<ReserveDto> GetById(long id)
        {
            var model = await _repository.GetBy(id);
            return ReserveMapper.Map(model);
        }

        public async Task<List<ReserveDto>> GetAll()
        {
            var list = await _repository.GetAll();
            return ReserveMapper.Map(list);
        }
    }
}