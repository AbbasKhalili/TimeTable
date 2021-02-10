using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeTable.Facade.Contracts.Calendar.Services;
using TimeTable.Facade.Contracts.Calendar.ViewModels;

namespace TimeTableHost.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    [Route("api/Calendar")]
    public class CalendarController : ControllerBase
    {
        private readonly ICalendarFacadeService _service;

        public CalendarController(ICalendarFacadeService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<bool> Post()
        {
            return await _service.Create();
        }

        [HttpPut("{id:long}")]
        public async Task Put(long id, CalendarViewModel model)
        {
            model.Id = id;
            await _service.Modify(model);
        }

        [HttpDelete("{id:long}")]
        public async Task Delete(long id)
        {
            await _service.Delete(id);
        }
    }
}