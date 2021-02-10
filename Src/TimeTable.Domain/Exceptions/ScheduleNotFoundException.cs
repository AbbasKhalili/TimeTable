using Framework.Core.Exceptions;

namespace TimeTable.Domain.Exceptions
{
    public class ScheduleNotFoundException : BusinessException
    {
        public ScheduleNotFoundException() : base(102)
        {
        }
    }
}