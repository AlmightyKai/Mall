using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;

namespace Almighty.Mall.Module.Product
{
    /// <summary>
    /// Represents a Spu(Standard Product Unit) for product.
    /// </summary>
    [Table("Spus")]
    [Comment("Represents a Spu(Standard Product Unit) for product.")]
    public class Spu : FullAuditedAggregateRoot<Guid>
    {
        #region [ Constants ]
        /// <summary>
        /// Maximum length of the <see cref="Name"/> property.
        /// </summary>
        private const int MaxNameLength = 128;
        #endregion

        #region [ Columns ]
        /// <summary>
        /// Seller id of this Spu.
        /// </summary>
        [Column("BrandId", TypeName = "uniqueidentifier")]
        [Comment("Brand id of this Spu.")]
        public virtual Guid? BrandId { get; set; }

        /// <summary>
        /// Category id of this Spu.
        /// </summary>
        [Column("CategoryId", TypeName = "uniqueidentifier")]
        [Comment("Category id of this Spu.")]
        public virtual Guid? CategoryId { get; set; }

        /// <summary>
        /// Seller id of this Spu.
        /// </summary>
        [Column("SellerId", TypeName = "uniqueidentifier")]
        [Comment("Seller id of this Spu.")]
        public virtual Guid? SellerId { get; set; }

        /// <summary>
        /// Seller category id of this Spu.
        /// </summary>
        [Column("SellerCategoryId", TypeName = "uniqueidentifier")]
        [Comment("Seller category id of this Spu.")]
        public virtual Guid? SellerCategoryId { get; set; }

        /// <summary>
        /// Name of this Spu.
        /// </summary>
        [Required]
        [Column("Name", TypeName = "nvarchar(256)")]
        [Comment("Name of this Spu.")]
        [StringLength(MaxNameLength)]
        public virtual string Name { get; set; }

        /// <summary>
        /// Selling point of this Spu.
        /// </summary>
        [Required]
        [Column("SellingPoint", TypeName = "nvarchar(256)")]
        [Comment("Selling point of this Spu.")]
        public virtual string SellingPoint { get; set; }

        /// <summary>
        /// Main image of this Spu.
        /// </summary>
        [Required]
        [Column("MainImage", TypeName = "nvarchar(256)")]
        [Comment("Main image of this Spu.")]
        public virtual string MainImage { get; set; }

        /// <summary>
        /// Images of this Spu.
        /// </summary>
        [Required]
        [Column("Images", TypeName = "nvarchar(2048)")]
        [Comment("Images of this Spu.")]
        public virtual string Images { get; set; }

        /// <summary>
        /// Video of this Spu.
        /// </summary>
        [Required]
        [Column("Video", TypeName = "nvarchar(256)")]
        [Comment("Video of this Spu.")]
        public virtual string Video { get; set; }

        /// <summary>
        /// Price of this Spu.
        /// </summary>
        [Required]
        [Column("Price", TypeName = "decimal(19,4)")]
        [Comment("Price of this Spu.")]
        public virtual decimal Price { get; set; }



        #endregion




    }
}
