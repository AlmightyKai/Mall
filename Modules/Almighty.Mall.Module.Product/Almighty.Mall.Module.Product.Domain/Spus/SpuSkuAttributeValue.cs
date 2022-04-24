using Almighty.Mall.Module.Product.Attributes;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Attribute = Almighty.Mall.Module.Product.Attributes.Attribute;

namespace Almighty.Mall.Module.Product.Spus
{
    /// <summary>
    /// Represents a spu sku attribute value in the product module.
    /// </summary>
    [Table("SpuSkuAttributeValues")]
    [Comment("Represents a Spu(Standard Product Unit) in the product module.")]
    public class SpuSkuAttributeValue : FullAuditedAggregateRoot<Guid>
    {
        #region [ Constants ]
        /// <summary>
        /// Maximum length of the <see cref="AttributeName"/> property.
        /// </summary>
        protected const int MAX_ATTRIBUTE_NAME_LENGTH = 128;

        /// <summary>
        /// Maximum length of the <see cref="AttributeValueName"/> property.
        /// </summary>
        protected const int MAX_ATTRIBUTE_VALUE_NAME_LENGTH = 128;

        /// <summary>
        /// Maximum length of the <see cref="Description"/> property.
        /// </summary>
        protected const int MAX_DESCRIPTION_LENGTH = 256;
        #endregion

        #region [ Columns ]
        /// <summary>
        /// Gets or sets the foreign key of a spu that is linked to the spu sku attribute value.
        /// </summary>
        [NotNull]
        [Column($"{nameof(SpuId)}", TypeName = "uniqueidentifier")]
        [Comment("The foreign key of a spu that is linked to the spu sku attribute value.")]
        public virtual Guid SpuId { get; protected set; }

        /// <summary>
        /// Gets or sets the foreign key of a sku that is linked to the spu sku attribute value.
        /// </summary>
        [NotNull]
        [Column($"{nameof(SkuId)}", TypeName = "uniqueidentifier")]
        [Comment("The foreign key of a sku that is linked to the spu sku attribute value.")]
        public virtual Guid SkuId { get; protected set; }

        /// <summary>
        /// Gets or sets the foreign key of an attribute that is linked to the spu sku attribute value.
        /// </summary>
        [NotNull]
        [Column($"{nameof(AttributeId)}", TypeName = "uniqueidentifier")]
        [Comment("The foreign key of an attribute that is linked to the spu sku attribute value.")]
        public virtual Guid AttributeId { get; protected set; }

        /// <summary>
        /// Gets or sets the attribute name for the spu sku attribute value.
        /// </summary>
        [CanBeNull]
        [Column($"{nameof(AttributeName)}", TypeName = "nvarchar(256)")]
        [Comment("The attribute name for the spu sku attribute value.")]
        [StringLength(MAX_ATTRIBUTE_NAME_LENGTH)]
        public virtual string AttributeName { get; protected set; }

        /// <summary>
        /// Gets or sets the foreign key of an attribute value that is linked to the spu sku attribute value.
        /// </summary>
        [CanBeNull]
        [Column($"{nameof(AttributeValueId)}", TypeName = "uniqueidentifier")]
        [Comment("The foreign key of an attribute value that is linked to the spu sku attribute value.")]
        public virtual Guid? AttributeValueId { get; protected set; }

        /// <summary>
        /// Gets or sets the attribute value name for the spu sku attribute value.
        /// </summary>
        [CanBeNull]
        [Column($"{nameof(AttributeValueName)}", TypeName = "nvarchar(256)")]
        [Comment("The attribute value name for the spu sku attribute value.")]
        [StringLength(MAX_ATTRIBUTE_VALUE_NAME_LENGTH)]
        public virtual string AttributeValueName { get; protected set; }

        /// <summary>
        /// Gets or sets the description for the spu sku attribute value.
        /// </summary>
        [CanBeNull]
        [Column($"{nameof(Description)}", TypeName = "nvarchar(256)")]
        [Comment("The description for the spu sku attribute value.")]
        [StringLength(MAX_DESCRIPTION_LENGTH)]
        public virtual string Description { get; protected set; }
        #endregion

        #region [ Foreign ]
        /// <summary>
        /// The foreign key of a spu that is linked to the spu sku attribute value.
        /// </summary>
        [ForeignKey(nameof(SpuId))]
        public virtual Spu Spu { get; protected set; }

        /// <summary>
        /// The foreign key of a sku that is linked to the spu sku attribute value.
        /// </summary>
        [ForeignKey(nameof(SkuId))]
        public virtual Sku Sku { get; protected set; }

        /// <summary>
        /// The foreign key of an attribute that is linked to the spu sku attribute value.
        /// </summary>
        [ForeignKey(nameof(AttributeId))]
        public virtual Attribute Attribute { get; protected set; }

        /// <summary>
        /// The foreign key of an attribute that is linked to the spu sku attribute value.
        /// </summary>
        [ForeignKey(nameof(AttributeValueId))]
        public virtual AttributeValue AttributeValue { get; protected set; }
        #endregion

        #region [ Constructor ]
        /// <summary>
        /// <para>Initializes a new instance of the <see cref="SpuSkuAttributeValue"/> class.</para>
        /// <para>Default constructor is needed for ORMs.</para>
        /// </summary>
        protected SpuSkuAttributeValue()
        {
            /* Do nothing. */
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpuSkuAttributeValue"/> class.
        /// </summary>
        /// <param name="spu">The foreign key of a spu that is linked to the spu sku attribute value.</param>
        /// <param name="sku">The foreign key of a sku that is linked to the spu sku attribute value.</param>
        /// <param name="attribute">The foreign key of an attribute that is linked to the spu sku attribute value.</param>
        /// <param name="attributeName">The attribute name for the spu sku attribute value.</param>
        /// <param name="attributeValue">The foreign key of an attribute value that is linked to the spu sku attribute value.</param>
        /// <param name="attributeValueName">The attribute value name for the spu sku attribute value.</param>
        /// <param name="description">The description for the spu sku attribute value.</param>
        public SpuSkuAttributeValue([NotNull] Spu spu,
                                    [NotNull] Sku sku,
                                    [NotNull] Attribute attribute,
                                    [CanBeNull] string attributeName,
                                    [CanBeNull] AttributeValue attributeValue,
                                    [CanBeNull] string attributeValueName,
                                    [CanBeNull] string description)
        {
            this.SetSpuId(spu);
            this.SetSkuId(sku);
            this.SetAttributeId(attribute);
            this.SetAttributeName(attributeName);
            this.SetAttributeValueId(attributeValue);
            this.SetAttributeValueName(attributeValueName);
            this.SetDescription(description);
        }
        #endregion

        #region [ Column Set ]
        /// <summary>
        /// Set <see cref="SpuId"/>.
        /// </summary>
        /// <param name="spu">The foreign key of a spu that is linked to the spu sku attribute value.</param>
        public SpuSkuAttributeValue SetSpuId([NotNull] Spu spu)
        {
            this.SpuId = Check.NotNull(spu, nameof(spu)).Id;
            return this;
        }

        /// <summary>
        /// Set <see cref="SkuId"/>.
        /// </summary>
        /// <param name="spu">The foreign key of a spu that is linked to the spu sku attribute value.</param>
        public SpuSkuAttributeValue SetSkuId([NotNull] Sku sku)
        {
            this.SkuId = Check.NotNull(sku, nameof(sku)).Id;
            return this;
        }

        /// <summary>
        /// Set <see cref="AttributeId"/>.
        /// </summary>
        /// <param name="attribute">The foreign key of an attribute that is linked to the spu sku attribute value.</param>
        public SpuSkuAttributeValue SetAttributeId([NotNull] Attribute attribute)
        {
            this.AttributeId = Check.NotNull(attribute, nameof(attribute)).Id;
            return this;
        }

        /// <summary>
        /// Set <see cref="AttributeName"/>.
        /// </summary>
        /// <param name="attributeName">The attribute name for the spu sku attribute value.</param>
        public SpuSkuAttributeValue SetAttributeName([CanBeNull] string attributeName)
        {
            if (attributeName?.Length > SpuSkuAttributeValue.MAX_ATTRIBUTE_NAME_LENGTH)
            {
                throw new ArgumentException($"{nameof(SpuSkuAttributeValue)} {nameof(attributeName)} can not be longer than {SpuSkuAttributeValue.MAX_ATTRIBUTE_NAME_LENGTH}");
            }

            this.AttributeName = attributeName;
            return this;
        }

        /// <summary>
        /// Set <see cref="AttributeValueId"/>.
        /// </summary>
        /// <param name="attributeValue">The foreign key of an attribute value that is linked to the spu sku attribute value.</param>
        public SpuSkuAttributeValue SetAttributeValueId([CanBeNull] AttributeValue attributeValue)
        {
            this.AttributeValueId = attributeValue?.Id;
            return this;
        }

        /// <summary>
        /// Set <see cref="AttributeValueName"/>.
        /// </summary>
        /// <param name="attributeValueName">The attribute value name for the spu sku attribute value.</param>
        public SpuSkuAttributeValue SetAttributeValueName([CanBeNull] string attributeValueName)
        {
            if (attributeValueName?.Length > SpuSkuAttributeValue.MAX_ATTRIBUTE_VALUE_NAME_LENGTH)
            {
                throw new ArgumentException($"{nameof(SpuSkuAttributeValue)} {nameof(attributeValueName)} can not be longer than {SpuSkuAttributeValue.MAX_ATTRIBUTE_VALUE_NAME_LENGTH}");
            }

            this.AttributeValueName = attributeValueName;
            return this;
        }

        /// <summary>
        /// Set <see cref="Description"/>.
        /// </summary>
        /// <param name="description">The description for the spu sku attribute value.</param>
        public SpuSkuAttributeValue SetDescription([CanBeNull] string description)
        {
            if (description?.Length > SpuSkuAttributeValue.MAX_DESCRIPTION_LENGTH)
            {
                throw new ArgumentException($"{nameof(SpuSkuAttributeValue)} {nameof(description)} can not be longer than {SpuSkuAttributeValue.MAX_DESCRIPTION_LENGTH}");
            }

            this.Description = description;
            return this;
        }
        #endregion

        #region [ To String ]
        /// <summary>
        /// Returns a string that represents the current spu attribute value.
        /// </summary>
        public override string ToString()
        {
            return $"{nameof(this.Spu)}:{((null != this.Spu) ? this.Spu.Name : this.SpuId)}" +
                   $" - " +
                   $"{nameof(this.Sku)}:{((null != this.Sku) ? this.Sku.Name : this.SkuId)}" +
                   $" - " +
                   $"{nameof(this.Attribute)}:{((null != this.Attribute) ? this.Attribute.Name : this.AttributeId)}" +
                   $" - " +
                   $"{nameof(this.AttributeValue)}:{((null != this.AttributeValue) ? this.AttributeValue.Value : this.AttributeValueId)}";
        }
        #endregion
    }
}
