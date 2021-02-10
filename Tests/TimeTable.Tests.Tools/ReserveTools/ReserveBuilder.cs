using System.Threading.Tasks;
using NSubstitute;
using TimeTable.Domain.Reserves;

namespace TimeTable.Tests.Tools.ReserveTools
{
    public class ReserveBuilder
    {
        private long ScheduleId { get; set; }
        private string Name { get; set; }

        private IReserveService ReserveService { get; set; }

        public ReserveBuilder()
        {
            ScheduleId = ReserveConst.ScheduleId;
            Name = ReserveConst.Name;

            ReserveService = Substitute.For<IReserveService>();
        }

        public async Task<Reserve> Build()
        {
            return await Reserve.DoReserve(ScheduleId, Name, ReserveService);
        }
        public ReserveBuilder WithService(IReserveService service)
        {
            ReserveService = service;
            return this;
        }
    }
}