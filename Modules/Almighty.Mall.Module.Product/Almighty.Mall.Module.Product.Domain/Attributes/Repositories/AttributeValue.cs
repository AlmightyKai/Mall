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
    /// Represents an attribute value in the product module.
    /// </summary>
    [Table("AttributeValues")]
    [Comment("Represents an attribute value in the product module.")]
    public class AttributeValue : AuditedAggregateRoot<Guid>
    {
        #region [ Constants ]
        /// <summary>
        /// Maximum length of the <see cref="Value"/> property.
        /// </summary>
        private const int MAX_VALUE_LENGTH = 256;
        #endregion

        #region [ Columns ]
        /// <summary>
        /// Gets or sets the foreign key of an attribute that is linked to the value.
        /// </summary>
        [NotNull]
        [Column($"{nameof(AttributeId)}", TypeName = "uniqueidentifier")]
        [Comment("The foreign key of an attribute that is linked to the value.")]
        public virtual Guid AttributeId { get; protected set; }

        /// <summary>
        /// Gets or sets the value for the attribute value (e.g. White, Blue, ...).
        /// </summary>
        [CanBeNull]
        [Column($"{nameof(Value)}", TypeName = "nvarchar(256)")]
        [Comment("The value for the attribute value (e.g. White, Blue, ...).")]
        [StringLength(MAX_VALUE_LENGTH)]
        public virtual string Value { get; protected set; }
        #endregion

        #region [ Foreign ]
        /// <summary>
        /// Gets or sets the foreign key of an attribute that is linked to the attribute value.
        /// </summary>
        [ForeignKey(nameof(AttributeId))]
        public virtual Attribute Attribute { get; protected set; }

        /// <summary>
        /// Gets or sets the links of the attribute value that is linked to all spu attribute values.
        /// </summary>
        public virtual ICollection<SpuAttributeValue> SpuAttributeValues { get; protected set; }

        /// <summary>
        /// Gets or sets the links of the attribute value that is linked to all spu sku attribute values.
        /// </summary>
        public virtual ICollection<SpuSkuAttributeValue> SpuSkuAttributeValues { get; protected set; }
        #endregion

        #region [ Constructor ]
        /// <summary>
        /// <para>Initializes a new instance of the <see cref="AttributeValue"/> class.</para>
        /// <para>Default constructor is needed for ORMs.</para>
        /// </summary>
        protected AttributeValue()
        {
            /* Do nothing. */
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeValue"/> class.
        /// </summary>
        /// <param name="attribute">The foreign key of an attribute that is linked to the value.</param>
        /// <param name="value">The value for the attribute value (e.g. White, Blue, ...).</param>
        public AttributeValue([NotNull]   Attribute attribute,
                              [CanBeNull] string    value)
            : this()
        {
            this.SetAttributeId(attribute);
            this.SetValue(value);
        }
        #endregion

        #region [ Column Set ]
        /// <summary>
        /// Set <see cref="AttributeId"/>.
        /// </summary>
        /// <param name="attribute">The foreign key of an attribute that is linked to the value.</param>
        public AttributeValue SetAttributeId([NotNull] Attribute attribute)
        {
            this.AttributeId = Check.NotNull(attribute, nameof(attribute)).Id;
            return this;
        }

        /// <summary>
        /// Set <see cref="Value"/>.
        /// </summary>
        /// <param name="value">The foreign key of a spu that is linked to the spu attribute value.</param>
        public AttributeValue SetValue([CanBeNull] string value)
        {
            if (value?.Length > AttributeValue.MAX_VALUE_LENGTH)
            {
                throw new ArgumentException($"{nameof(AttributeValue)} {nameof(value)} can not be longer than {AttributeValue.MAX_VALUE_LENGTH}");
            }

            this.Value = value;
            return this;
        }
        #endregion

        #region [ To String ]
        /// <summary>
        /// Returns a string that represents the current attribute value.
        /// </summary>
        public override string ToString()
        {
            return $"{nameof(this.Attribute)}:{((null != this.Attribute) ? this.Attribute.Name : this.AttributeId)}" +
                   $" - " +
                   $"{nameof(this.Value)}:{this.Value}";
        }
        #endregion
    }
}
