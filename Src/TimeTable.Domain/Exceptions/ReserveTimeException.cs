using Framework.Core.Exceptions;

namespace TimeTable.Domain.Exceptions
{
    public class ReserveTimeException : BusinessException
    {
        public ReserveTimeException() : base(106)
        {
        }
    }
}