using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeTable.Facade.Contracts.Schedule.DTOs;
using TimeTable.Facade.Contracts.Schedule.Services;

namespace TimeTableHost.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    [Route("api/Schedule")]
    public class ScheduleQueryController : ControllerBase
    {
        private readonly IScheduleFacadeQuery _query;

        public ScheduleQueryController(IScheduleFacadeQuery query)
        {
            _query = query;
        }

        [HttpGet("{id:long}")]
        public async Task<ScheduleDto> Get(long id)
        {
            return await _query.GetById(id);
        }

        [HttpGet]
        public async Task<List<ScheduleDto>> Get()
        {
            return await _query.GetAll();
        }
    }
}