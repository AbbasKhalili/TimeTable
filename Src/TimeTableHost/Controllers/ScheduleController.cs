using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeTable.Facade.Contracts.Schedule.Services;
using TimeTable.Facade.Contracts.Schedule.ViewModels;

namespace TimeTableHost.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    [Route("api/Schedule")]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleFacadeService _service;

        public ScheduleController(IScheduleFacadeService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<long> Post(ScheduleViewModel model)
        {
            return await _service.Create(model);
        }

        [HttpPut("{id:long}")]
        public async Task Put(long id, ScheduleViewModel model)
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