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
    /// Represents a spu attribute value in the product module.
    /// </summary>
    [Table("SpuAttributeValues")]
    [Comment("Represents a spu attribute value in the product module.")]
    public class SpuAttributeValue : AuditedAggregateRoot<Guid>
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
        /// Gets or sets the foreign key of a spu that is linked to the spu attribute value.
        /// </summary>
        [NotNull]
        [Column($"{nameof(SpuId)}", TypeName = "uniqueidentifier")]
        [Comment("The foreign key of a spu that is linked to the spu attribute value.")]
        public virtual Guid SpuId { get; protected set; }

        /// <summary>
        /// Gets or sets the foreign key of an attribute that is linked to the spu attribute value.
        /// </summary>
        [NotNull]
        [Column($"{nameof(AttributeId)}", TypeName = "uniqueidentifier")]
        [Comment("The foreign key of an attribute that is linked to the spu attribute value.")]
        public virtual Guid AttributeId { get; protected set; }

        /// <summary>
        /// Gets or sets the attribute name for the spu attribute value.
        /// </summary>
        [CanBeNull]
        [Column($"{nameof(AttributeName)}", TypeName = "nvarchar(256)")]
        [Comment("The attribute name for the spu attribute value.")]
        [StringLength(MAX_ATTRIBUTE_NAME_LENGTH)]
        public virtual string AttributeName { get; protected set; }

        /// <summary>
        /// Gets or sets the foreign key of an attribute value that is linked to the spu attribute value.
        /// </summary>
        [CanBeNull]
        [Column($"{nameof(AttributeValueId)}", TypeName = "uniqueidentifier")]
        [Comment("The foreign key of an attribute value that is linked to the spu attribute value.")]
        public virtual Guid? AttributeValueId { get; protected set; }

        /// <summary>
        /// Gets or sets the attribute value name for the spu attribute value.
        /// </summary>
        [CanBeNull]
        [Column($"{nameof(AttributeValueName)}", TypeName = "nvarchar(256)")]
        [Comment("The attribute value name for the spu attribute value.")]
        [StringLength(MAX_ATTRIBUTE_VALUE_NAME_LENGTH)]
        public virtual string AttributeValueName { get; protected set; }

        /// <summary>
        /// Gets or sets the description for the spu attribute value.
        /// </summary>
        [CanBeNull]
        [Column($"{nameof(Description)}", TypeName = "nvarchar(256)")]
        [Comment("The description for the spu attribute value.")]
        [StringLength(MAX_DESCRIPTION_LENGTH)]
        public virtual string Description { get; protected set; }
        #endregion

        #region [ Foreign ]
        /// <summary>
        /// The foreign key of a spu that is linked to the spu attribute value.
        /// </summary>
        [ForeignKey(nameof(SpuId))]
        public virtual Spu Spu { get; set; }

        /// <summary>
        /// The foreign key of an attribute that is linked to the spu attribute value.
        /// </summary>
        [ForeignKey(nameof(AttributeId))]
        public virtual Attribute Attribute { get; set; }

        /// <summary>
        /// The foreign key of an attribute that is linked to the spu attribute value.
        /// </summary>
        [ForeignKey(nameof(AttributeId))]
        public virtual AttributeValue AttributeValue { get; set; }
        #endregion

        #region [ Constructor ]
        /// <summary>
        /// <para>Initializes a new instance of the <see cref="SpuAttributeValue"/> class.</para>
        /// <para>Default constructor is needed for ORMs.</para>
        /// </summary>
        protected SpuAttributeValue()
        {
            /* Do nothing. */
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpuAttributeValue"/> class.
        /// </summary>
        /// <param name="spu">The foreign key of a spu that is linked to the spu attribute value.</param>
        /// <param name="attribute">The foreign key of an attribute that is linked to the spu attribute value.</param>
        /// <param name="attributeName">The attribute name for the spu attribute value.</param>
        /// <param name="attributeValue">The foreign key of an attribute value that is linked to the spu attribute value.</param>
        /// <param name="attributeValueName">The attribute value name for the spu attribute value.</param>
        /// <param name="description">The description for the spu attribute value.</param>
        public SpuAttributeValue([NotNull]   Spu            spu,
                                 [NotNull]   Attribute      attribute,
                                 [CanBeNull] string         attributeName,
                                 [CanBeNull] AttributeValue attributeValue,
                                 [CanBeNull] string         attributeValueName,
                                 [CanBeNull] string         description)
        {
            this.SetSpuId(spu);
            this.SetAttributeId(attribute);
        }
        #endregion

        #region [ Column Set ]
        /// <summary>
        /// Set <see cref="SpuId"/>
        /// </summary>
        /// <param name="spu">The foreign key of a spu that is linked to the spu attribute value.</param>
        public SpuAttributeValue SetSpuId([NotNull] Spu spu)
        {
            this.SpuId = Check.NotNull(spu, nameof(spu)).Id;
            return this;
        }

        /// <summary>
        /// Set <see cref="AttributeId"/>
        /// </summary>
        /// <param name="attribute">The foreign key of an attribute that is linked to the spu attribute value.</param>
        public SpuAttributeValue SetAttributeId([NotNull] Attribute attribute)
        {
            this.AttributeId = Check.NotNull(attribute, nameof(attribute)).Id;
            return this;
        }
        #endregion

        #region [ To String ]

        #endregion
    }
}
