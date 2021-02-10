using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeTable.Facade.Contracts.Reserve.Services;
using TimeTable.Facade.Contracts.Reserve.ViewModels;

namespace TimeTableHost.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    [Route("api/Reserve")]
    public class ReserveController : ControllerBase
    {
        private readonly IReserveFacadeService _service;

        public ReserveController(IReserveFacadeService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<long> Post(ReserveViewModel model)
        {
            return await _service.Create(model);
        }
        
        [HttpDelete("{id:long}")]
        public async Task Delete(long id)
        {
            await _service.Delete(id);
        }
    }
}