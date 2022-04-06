using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Almighty.Mall.Module.Seller.EntityFrameworkCore;

[ConnectionStringName(SellerDbProperties.ConnectionStringName)]
public class SellerDbContext : AbpDbContext<SellerDbContext>, ISellerDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public SellerDbContext(DbContextOptions<SellerDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureSeller();
    }
}
