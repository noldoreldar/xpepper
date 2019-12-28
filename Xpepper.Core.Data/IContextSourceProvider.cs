namespace Xpepper.Core.Data
{

    public interface IContextSourceProvider<out TContext, in TConfiguration>
    where TContext : class
    where TConfiguration : IDataConfiguration
    {
        TContext GetContext(TConfiguration configuration);
    }
}
