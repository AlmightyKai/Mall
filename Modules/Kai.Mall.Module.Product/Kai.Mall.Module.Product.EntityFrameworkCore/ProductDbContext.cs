using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Kai.Mall.Module.Product.EntityFrameworkCore
{
    [ConnectionStringName(DbProperties.ConnectionStringName)]
    public class ProductDbContext : AbpDbContext<ProductDbContext>, IProductDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureProduct();
        }
    }
}
