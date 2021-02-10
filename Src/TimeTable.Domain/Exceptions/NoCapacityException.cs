using Framework.Core.Exceptions;

namespace TimeTable.Domain.Exceptions
{
    public class NoCapacityException : BusinessException
    {
        public NoCapacityException() : base(101)
        {
        }
    }
}
