using System.Collections.Generic;
using System.Linq;
using TimeTable.Domain.Reserves;
using TimeTable.Facade.Contracts.Reserve.DTOs;

namespace TimeTable.Facade.Query.Mappers
{
    internal class ReserveMapper
    {
        public static ReserveDto Map(Reserve model)
        {
            if (model == null) return null;
            return new ReserveDto
            {
                Id = model.Id,
                ScheduleId = model.ScheduleId,
                Name = model.Name
            };
        }

        public static List<ReserveDto> Map(List<Reserve> list)
        {
            return list?.Select(Map).ToList();
        }
    }
}