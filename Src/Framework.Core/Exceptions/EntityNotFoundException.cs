namespace Framework.Core.Exceptions
{
    public class EntityNotFoundException : BusinessException
    {
        public EntityNotFoundException() : base(1, "یافت نشد!")
        {
        }
        public EntityNotFoundException(long id) : base(1, $"با شماره شناسه : {id} موردی یافت نشد!")
        {
        }
        public EntityNotFoundException(string message) : base(1, message)
        {
        }
    }
}