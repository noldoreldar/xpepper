namespace Xpepper.Core.Data.EF
{
    public interface IDbContextSourceProvider<out TContext> : IContextSourceProvider<TContext, DbConfiguration>
        where TContext : DbContextBase 
    {
    }
}
