using Framework.Core.Exceptions;

namespace TimeTable.Domain.Exceptions
{
    public class DefineScheduleInHolidayException : BusinessException
    {
        public DefineScheduleInHolidayException() : base(104)
        {
        }
    }
}