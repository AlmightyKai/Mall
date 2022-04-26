using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Almighty.Mall.Module.Product.Spus
{
    /// <summary>
    /// Represents a sku(Stock Keeping Unit) in the product module.
    /// </summary>
    [Table("Skus")]
    [Comment("Represents a sku(Stock Keeping Unit) in the product module.")]
    public class Sku : AuditedAggregateRoot<Guid>
    {
        #region [ Constants ]
        /// <summary>
        /// Maximum length of the <see cref="Name"/> property.
        /// </summary>
        private const int MAX_NAME_LENGTH = 128;

        /// <summary>
        /// Maximum length of the <see cref="Image"/> property.
        /// </summary>
        private const int MAX_IMAGE_LENGTH = 256;
        #endregion

        #region [ Columns ]
        /// <summary>
        /// Gets or sets the foreign key of the sku that is linked to a spu.
        /// </summary>
        [NotNull]
        [Column($"{nameof(SpuId)}", TypeName = "uniqueidentifier")]
        [Comment("The foreign key of the sku that is linked to a spu.")]
        public virtual Guid SpuId { get; protected set; }

        /// <summary>
        /// Gets or sets the name for the sku (e.g. iPhone XS Max, iPhone 13 Plus, ...).
        /// </summary>
        [NotNull]
        [Column($"{nameof(Name)}", TypeName = "nvarchar(256)")]
        [Comment("The name for the sku (e.g. iPhone XS Max, iPhone 13 Plus, ...).")]
        [StringLength(MAX_NAME_LENGTH)]
        public virtual string Name { get; protected set; }

        /// <summary>
        /// Gets or sets the image url for the sku.
        /// </summary>
        [NotNull]
        [Column($"{nameof(Image)}", TypeName = "nvarchar(256)")]
        [Comment("The image url for the sku.")]
        [StringLength(MAX_IMAGE_LENGTH)]
        public virtual string Image { get; protected set; }


        public virtual string UniversalProductionCode { get; protected set; }







        /// <summary>
        /// Gets or sets the guidance price for the sku (e.g. 199.99, 998.00, ...). Null, If not needed.
        /// </summary>
        [CanBeNull]
        [Column($"{nameof(GuidancePrice)}", TypeName = "decimal(19,4)")]
        [Comment("The guidance price for the sku (e.g. 199.99, 998.00, ...). Null, If not needed.")]
        public virtual decimal? GuidancePrice { get; protected set; }

        /// <summary>
        /// Gets or sets the price for the sku (e.g. 199.99, 998.00, ...).
        /// </summary>
        [NotNull]
        [Column($"{nameof(Price)}", TypeName = "decimal(19,4)")]
        [Comment("The price for the sku (e.g. 199.99, 998.00, ...).")]
        public virtual decimal Price { get; protected set; }

        /// <summary>
        /// Gets or sets the offer price for the sku (e.g. 199.99, 998.00, ...). Null, If not needed.
        /// </summary>
        [CanBeNull]
        [Column($"{nameof(OfferPrice)}", TypeName = "decimal(19,4)")]
        [Comment("The offer price for the sku (e.g. 199.99, 998.00, ...). Null, If not needed.")]
        public virtual decimal? OfferPrice { get; protected set; }

        /// <summary>
        /// Gets or sets the state for the sku (e.g. 0:Disabled, 1:Enabled, ...).
        /// </summary>
        [NotNull]
        [Column($"{nameof(State)}", TypeName = "tinyint")]
        [Comment("The state for the sku (e.g. 0:Disabled, 1:Enabled, ...).")]
        public virtual State State { get; protected set; }
        #endregion

        #region [ Foreign ]


        #endregion





    }
}
