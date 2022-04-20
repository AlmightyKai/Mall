using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;

namespace Almighty.Mall.Module.Product
{
    /// <summary>
    /// Represents a Sku(Stock Keeping Unit) for product.
    /// </summary>
    [Table("Skus")]
    [Comment("Represents a Spu(Stock Keeping Unit) for product.")]
    public class Sku : AuditedAggregateRoot<Guid>
    {
        #region [ Constants ]
        /// <summary>
        /// Maximum length of the <see cref="Name"/> property.
        /// </summary>
        private const int MaxNameLength = 128;
        #endregion

        #region [ Columns ]
        /// <summary>
        /// Spu id of this Sku.
        /// </summary>
        [Column("SpuId", TypeName = "uniqueidentifier")]
        [Comment("Spu id of this Sku.")]
        public virtual Guid? SkuId { get; set; }

        /// <summary>
        /// Name of this Sku.
        /// </summary>
        [Required]
        [Column("Name", TypeName = "nvarchar(256)")]
        [Comment("Name of this Sku.")]
        [StringLength(MaxNameLength)]
        public virtual string Name { get; set; }

        /// <summary>
        /// Image of this Sku.
        /// </summary>
        [Required]
        [Column("Image", TypeName = "nvarchar(256)")]
        [Comment("Image of this Sku.")]
        public virtual string Image { get; set; }







        #endregion







    }
}
