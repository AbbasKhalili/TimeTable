namespace TimeTable.Domain.Tests.Unit
{
    public abstract class DomainUnitTestBase<TBuilder> where TBuilder : class, new()
    {
        protected TBuilder Builder;

        protected DomainUnitTestBase()
        {
            Builder = new TBuilder();
        }
    }
}