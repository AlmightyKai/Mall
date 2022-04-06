using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Almighty.Mall.Module.Seller.EntityFrameworkCore;

[ConnectionStringName(SellerDbProperties.ConnectionStringName)]
public interface ISellerDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
