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
        [Required]
        [Column($"{nameof(AttributeId)}", TypeName = "uniqueidentifier")]
        [Comment("The foreign key of the attribute that is linked to a category.")]
        public virtual Guid? AttributeId { get; set; }

        /// <summary>
        /// Gets or sets the foreign key of the category that is linked to the attribute.
        /// </summary>
        [Required]
        [Column($"{nameof(CategoryId)}", TypeName = "uniqueidentifier")]
        [Comment("The foreign key of the category that is linked to the attribute.")]
        public virtual Guid? CategoryId { get; set; }
        #endregion

        #region [ Foreign ]
        /// <summary>
        /// Gets or sets the foreign key of the attribute that is linked to a category.
        /// </summary>
        [ForeignKey(nameof(AttributeId))]
        public virtual Attribute Attribute { get; set; }

        /// <summary>
        /// Gets or sets the foreign key of the category that is linked to the attribute.
        /// </summary>
        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }
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
            Check.NotNull(attribute, nameof(attribute));
            Check.NotNull(category,  nameof(category));

            this.AttributeId = attribute.Id;
            this.CategoryId  = category.Id;
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
