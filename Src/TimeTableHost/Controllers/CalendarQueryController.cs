using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeTable.Facade.Contracts.Calendar.DTOs;
using TimeTable.Facade.Contracts.Calendar.Services;

namespace TimeTableHost.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    [Route("api/Calendar")]
    public class CalendarQueryController : ControllerBase
    {
        private readonly ICalendarFacadeQuery _query;

        public CalendarQueryController(ICalendarFacadeQuery query)
        {
            _query = query;
        }

        [HttpGet("{id:long}")]
        public async Task<CalendarDto> Get(long id)
        {
            return await _query.GetById(id);
        }

        [HttpGet]
        public async Task<List<CalendarDto>> Get()
        {
            return await _query.GetAll();
        }
    }
}