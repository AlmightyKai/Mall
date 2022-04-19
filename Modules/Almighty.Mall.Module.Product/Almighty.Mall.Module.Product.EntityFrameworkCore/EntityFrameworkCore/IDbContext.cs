using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Almighty.Mall.Module.Product.EntityFrameworkCore
{
    [ConnectionStringName(DbProperties.ConnectionStringName)]
    public interface IDbContext : IEfCoreDbContext
    {
        /* 
         * Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}
