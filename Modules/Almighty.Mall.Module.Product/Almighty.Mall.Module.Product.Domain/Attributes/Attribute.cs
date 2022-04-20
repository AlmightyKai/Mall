using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;

namespace Almighty.Mall.Module.Product
{
    /// <summary>
    /// Represents a attribute for product.
    /// </summary>
    [Table("Attributes")]
    [Comment("Represents a attribute for product.")]
    public class Attribute : AuditedAggregateRoot<Guid>
    {
        #region [ Constants ]
        /// <summary>
        /// Maximum length of the <see cref="DisplayName"/> property.
        /// </summary>
        private const int MaxDisplayNameLength = 128;
        #endregion

        #region [ Columns ]
        /// <summary>
        /// Seller id of this attribute.
        /// </summary>
        [Column("SellerId", TypeName = "uniqueidentifier")]
        [Comment("Seller id of this attribute.")]
        public virtual Guid? SellerId { get; set; }

        /// <summary>
        /// Display name of this attribute.
        /// </summary>
        [Required]
        [Column("DisplayName", TypeName = "nvarchar(255)")]
        [Comment("Display name of this attribute.")]
        [StringLength(MaxDisplayNameLength)]
        public virtual string DisplayName { get; set; }

        /// <summary>
        /// Description of this attribute.
        /// </summary>
        [Required]
        [Column("Description", TypeName = "nvarchar(255)")]
        [Comment("Description of this attribute.")]
        [StringLength(MaxDisplayNameLength)]
        public virtual string Description { get; set; }
        #endregion

        #region [ Foreign ]

        #endregion

        #region [ Constructor ]
        /// <summary>
        /// <para>Initializes a new instance of the <see cref="Attribute"/> class.</para> 
        /// <para>Default constructor is needed for ORMs.</para> 
        /// </summary>
        private Attribute()
        {
            /* Do nothing. */
        }

        //internal Product(Guid id, [NotNull] string code, [NotNull] string name, float price = 0.0f, int stockCount = 0, string imageName = null)
        //{
        //    Check.NotNullOrWhiteSpace(code, nameof(code));

        //    if (code.Length >= ProductConsts.MaxCodeLength)
        //    {
        //        throw new ArgumentException($"Product code can not be longer than {ProductConsts.MaxCodeLength}");
        //    }

        //    Id = id;
        //    Code = code;
        //    SetName(Check.NotNullOrWhiteSpace(name, nameof(name)));
        //    SetPrice(price);
        //    SetImageName(imageName);
        //    SetStockCountInternal(stockCount, triggerEvent: false);
        //}
        #endregion

        #region [ To String ]
        /// <summary>
        /// Returns a string that represents the current attribute.
        /// </summary>
        /// <returns>
        /// A string that represents the current attribute.
        /// </returns>
        public override string ToString() => $"{this.DisplayName}";
        #endregion
    }
}
