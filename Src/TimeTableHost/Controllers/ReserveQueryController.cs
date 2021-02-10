using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeTable.Facade.Contracts.Reserve.DTOs;
using TimeTable.Facade.Contracts.Reserve.Services;

namespace TimeTableHost.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    [Route("api/Reserve")]
    public class ReserveQueryController : ControllerBase
    {
        private readonly IReserveFacadeQuery _query;

        public ReserveQueryController(IReserveFacadeQuery query)
        {
            _query = query;
        }

        [HttpGet("{id:long}")]
        public async Task<ReserveDto> Get(long id)
        {
            return await _query.GetById(id);
        }

        [HttpGet]
        public async Task<List<ReserveDto>> Get()
        {
            return await _query.GetAll();
        }
    }
}