using Framework.Core.Exceptions;

namespace TimeTable.Domain.Exceptions
{
    public class DefineScheduleOutOfWorkTimeException : BusinessException
    {
        public DefineScheduleOutOfWorkTimeException() : base(105)
        {
        }
    }
}