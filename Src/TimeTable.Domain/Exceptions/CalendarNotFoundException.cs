using Framework.Core.Exceptions;

namespace TimeTable.Domain.Exceptions
{
    public class CalendarNotFoundException : BusinessException
    {
        public CalendarNotFoundException() : base(103)
        {
        }
    }
}