using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeTable.Facade.Contracts.Schedule.Services;
using TimeTable.Facade.Contracts.Schedule.ViewModels;

namespace TimeTableHost.Controllers
{
    [Route("Schedule")]
    public class ScheduleController : Controller
    {
        private readonly IScheduleFacadeService _service;

        public ScheduleController(IScheduleFacadeService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ScheduleViewModel model)
        {
            if (model.Id == 0)
                model.Id = await _service.Create(model);
            else
                await _service.Modify(model);

            return View("Index",model);
        }
        
        [HttpDelete("{id:long}")]
        public async Task Delete(long id)
        {
            await _service.Delete(id);
        }
    }
}