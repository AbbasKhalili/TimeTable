using System;
using System.Threading.Tasks;
using Framework.Core;

namespace TimeTable.Domain.Schedules
{
    public interface IScheduleService : IDomainService
    {
        Task CanDefine(long calendarId, DateTime time);
    }
}