using Almighty.Mall.Module.Product.Categories;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Almighty.Mall.Module.Product.Attributes
{
    /// <summary>
    /// Represents the link between an attribute and a category in the product module.
    /// </summary>
    [Table("AttributeCategories")]
    [Comment("Represents the link between an attribute and a category in the product module.")]
    public class AttributeCategory : AuditedAggregateRoot<Guid>
    {
        #region [ Columns ]
        /// <summary>
        /// Gets or sets the foreign key of the attribute that is linked to a category.
        /// </summary>
        [NotNull]
        [Column($"{nameof(AttributeId)}", TypeName = "uniqueidentifier")]
        [Comment("The foreign key of the attribute that is linked to a category.")]
        public virtual Guid? AttributeId { get; protected set; }

        /// <summary>
        /// Gets or sets the foreign key of the category that is linked to the attribute.
        /// </summary>
        [NotNull]
        [Column($"{nameof(CategoryId)}", TypeName = "uniqueidentifier")]
        [Comment("The foreign key of the category that is linked to the attribute.")]
        public virtual Guid? CategoryId { get; protected set; }
        #endregion

        #region [ Foreign ]
        /// <summary>
        /// Gets or sets the foreign key of the attribute that is linked to a category.
        /// </summary>
        [ForeignKey(nameof(AttributeId))]
        public virtual Attribute Attribute { get; protected set; }

        /// <summary>
        /// Gets or sets the foreign key of the category that is linked to the attribute.
        /// </summary>
        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; protected set; }
        #endregion

        #region [ Constructor ]
        /// <summary>
        /// <para>Initializes a new instance of the <see cref="AttributeCategory"/> class.</para>
        /// <para>Default constructor is needed for ORMs.</para>
        /// </summary>
        protected AttributeCategory()
        {
            /* Do nothing. */
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeCategory"/> class.
        /// </summary>
        /// <param name="attribute">The foreign key of the attribute that is linked to a category.</param>
        /// <param name="category">The foreign key of the category that is linked to the attribute.</param>
        public AttributeCategory([NotNull] Attribute attribute,
                                 [NotNull] Category  category)
            : this()
        {
            this.SetAttributeId(attribute);
            this.SetCategoryId(category);
        }
        #endregion

        #region [ Column Set ]
        /// <summary>
        /// Set <see cref="AttributeId"/>.
        /// </summary>
        /// <param name="attribute">The foreign key of the attribute that is linked to a category.</param>
        public AttributeCategory SetAttributeId([NotNull] Attribute attribute)
        {
            this.AttributeId = Check.NotNull(attribute, nameof(attribute)).Id;
            return this;
        }

        /// <summary>
        /// Set <see cref="CategoryId"/>.
        /// </summary>
        /// <param name="category">The foreign key of the category that is linked to the attribute.</param>
        public AttributeCategory SetCategoryId([NotNull] Category category)
        {
            this.CategoryId = Check.NotNull(category, nameof(category)).Id;
            return this;
        }
        #endregion

        #region [ To String ]
        /// <summary>
        /// Returns a string that represents the current attribute category.
        /// </summary>
        public override string ToString()
        {
            return $"{nameof(this.Attribute)}:{((null != this.Attribute) ? this.Attribute.Name : this.AttributeId)}" +
                   $" - " +
                   $"{nameof(this.Category)}:{((null != this.Category) ? this.Category.Name : this.CategoryId)}";
        }
        #endregion
    }
}
