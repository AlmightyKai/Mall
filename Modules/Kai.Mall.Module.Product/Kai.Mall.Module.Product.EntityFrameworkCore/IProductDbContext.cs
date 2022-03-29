using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Kai.Mall.Module.Product.EntityFrameworkCore
{
    [ConnectionStringName(DbProperties.ConnectionStringName)]
    public interface IProductDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}
