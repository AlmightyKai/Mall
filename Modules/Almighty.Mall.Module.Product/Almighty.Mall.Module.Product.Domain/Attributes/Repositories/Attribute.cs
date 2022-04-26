using Almighty.Mall.Module.Product.Spus;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Almighty.Mall.Module.Product.Attributes
{
    /// <summary>
    /// Represents an attribute in the product module.
    /// </summary>
    [Table("Attributes")]
    [Comment("Represents an attribute in the product module.")]
    public class Attribute : AuditedAggregateRoot<Guid>
    {
        #region [ Constants ]
        /// <summary>
        /// Maximum length of the <see cref="Name"/> property.
        /// </summary>
        private const int MAX_NAME_LENGTH = 128;

        /// <summary>
        /// Maximum length of the <see cref="Description"/> property.
        /// </summary>
        private const int MAX_DESCRIPTION_LENGTH = 256;
        #endregion

        #region [ Columns ]
        /// <summary>
        /// Gets or sets the foreign key of the attribute that is linked to a seller. Null, if this category in platform.
        /// </summary>
        [CanBeNull]
        [Column($"{nameof(SellerId)}", TypeName = "uniqueidentifier")]
        [Comment("The foreign key of the attribute that is linked to a seller. Null, if this category in platform.")]
        public virtual Guid? SellerId { get; protected set; }

        /// <summary>
        /// Gets or sets the name for the attribute (e.g. Color, Resolution, ...).
        /// </summary>
        [NotNull]
        [Column($"{nameof(Name)}", TypeName = "nvarchar(256)")]
        [Comment("The name for the attribute (e.g. Color, Resolution, ...).")]
        [StringLength(MAX_NAME_LENGTH)]
        public virtual string Name { get; protected set; }

        /// <summary>
        /// Gets or sets the description for the attribute.
        /// </summary>
        [CanBeNull]
        [Column($"{nameof(Description)}", TypeName = "nvarchar(256)")]
        [Comment("The description for the attribute.")]
        [StringLength(MAX_DESCRIPTION_LENGTH)]
        public virtual string Description { get; protected set; }
        #endregion

        #region [ Foreign ]
        /// <summary>
        /// Gets or sets the links of the attribute that is linked to all attribute categories.
        /// </summary>
        public virtual ICollection<AttributeCategory> AttributeCategories { get; protected set; }

        /// <summary>
        /// Gets or sets the links of the attribute that is linked to all attribute values.
        /// </summary>
        public virtual ICollection<AttributeValue> AttributeValues { get; protected set; }

        /// <summary>
        /// Gets or sets the links of the attribute that is linked to all spu attribute values.
        /// </summary>
        public virtual ICollection<SpuAttributeValue> SpuAttributeValues { get; protected set; }

        /// <summary>
        /// Gets or sets the links of the attribute that is linked to all spu sku attribute values.
        /// </summary>
        public virtual ICollection<SpuSkuAttributeValue> SpuSkuAttributeValues { get; protected set; }
        #endregion

        #region [ Constructor ]
        /// <summary>
        /// <para>Initializes a new instance of the <see cref="Attribute"/> class.</para>
        /// <para>Default constructor is needed for ORMs.</para>
        /// </summary>
        protected Attribute()
        {
            /* Do nothing. */
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Attribute"/> class.
        /// </summary>
        /// <param name="seller">The foreign key of the attribute that is linked to a seller. Null, if this category in platform.</param>
        /// <param name="name">The name for the attribute (e.g. Color, Resolution, ...).</param>
        /// <param name="description">The description for the attribute.</param>
        /// <exception cref="ArgumentException"></exception>
        public Attribute([CanBeNull] Guid?  seller,
                         [NotNull]   string name,
                         [CanBeNull] string description)
            : this()
        {
            this.SetSpuId(seller);
            this.SetName(name);
            this.SetDescription(description);
        }
        #endregion

        #region [ Column Set ]
        /// <summary>
        /// Set <see cref="SellerId"/>.
        /// </summary>
        /// <param name="seller">The foreign key of the attribute that is linked to a seller. Null, if this category in platform.</param>
        public Attribute SetSpuId(Guid? seller)
        {
            this.SellerId = seller;
            return this;
        }

        /// <summary>
        /// Set <see cref="Name"/>.
        /// </summary>
        /// <param name="name">The name for the attribute (e.g. Color, Resolution, ...).</param>
        public Attribute SetName([NotNull] string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            if (name.Length > Attribute.MAX_NAME_LENGTH)
            {
                throw new ArgumentException($"{nameof(Attribute)} {nameof(name)} can not be longer than {Attribute.MAX_NAME_LENGTH}");
            }

            this.Name = name;
            return this;
        }

        /// <summary>
        /// Set <see cref="Description"/>.
        /// </summary>
        /// <param name="description">The description for the attribute.</param>
        public Attribute SetDescription([CanBeNull] string description)
        {
            if (description?.Length > Attribute.MAX_DESCRIPTION_LENGTH)
            {
                throw new ArgumentException($"{nameof(Attribute)} {nameof(description)} can not be longer than {Attribute.MAX_DESCRIPTION_LENGTH}");
            }

            this.Description = description;
            return this;
        }
        #endregion

        #region [ To String ]
        /// <summary>
        /// Returns a string that represents the current attribute.
        /// </summary>
        public override string ToString()
        {
            return $"{nameof(this.Name)}:{this.Name}" +
                   $" - " +
                   $"{nameof(this.Description)}:{this.Description}";
        }
        #endregion
    }
}
