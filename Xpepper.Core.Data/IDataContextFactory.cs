namespace Xpepper.Core.Data
{
    public interface IDataContextFactory<out TContext, out TDataContextConfiguration>
    where TContext : class
    where TDataContextConfiguration : IDataContextConfiguration
    {
        TDataContextConfiguration DataContextConfiguration { get; }

        TContext GetContext();
    }
}
