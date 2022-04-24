using Almighty.Mall.Module.Product.Brands;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Almighty.Mall.Module.Product.Categories
{
    /// <summary>
    /// Represents the link between a category and a brand in the product module.
    /// </summary>
    [Table("CategoriyBrands")]
    [Comment("Represents the link between a category and a brand in the product module.")]
    public class CategoryBrand : AuditedAggregateRoot<Guid>
    {
        #region [ Columns ]
        /// <summary>
        /// Gets or sets the foreign key of the category that is linked to a brand.
        /// </summary>
        [NotNull]
        [Column($"{nameof(CategoryId)}", TypeName = "uniqueidentifier")]
        [Comment("The category that is linked to a brand.")]
        public virtual Guid? CategoryId { get; protected set; }

        /// <summary>
        /// Gets or sets the foreign key of the brand that is linked to the category.
        /// </summary>
        [NotNull]
        [Column($"{nameof(BrandId)}", TypeName = "uniqueidentifier")]
        [Comment("The brand that is linked to the category.")]
        public virtual Guid? BrandId { get; protected set; }
        #endregion

        #region [ Foreign ]
        /// <summary>
        /// Gets or sets the foreign key of the category that is linked to a brand.
        /// </summary>
        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; protected set; }

        /// <summary>
        /// Gets or sets the foreign key of the brand that is linked to the category.
        /// </summary>
        [ForeignKey(nameof(BrandId))]
        public virtual Brand Brand { get; protected set; }
        #endregion

        #region [ Constructor ]
        /// <summary>
        /// <para>Initializes a new instance of the <see cref="CategoryBrand"/> class.</para>
        /// <para>Default constructor is needed for ORMs.</para>
        /// </summary>
        protected CategoryBrand()
        {
            /* Do nothing. */
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Category"/> class.
        /// </summary>
        /// <param name="category">The category that is linked to a brand.</param>
        /// <param name="brand">The brand that is linked to the category.</param>
        public CategoryBrand([NotNull] Category category,
                             [NotNull] Brand    brand)
            : this()
        {
            this.SetCategoryId(category);
            this.SetBrandId(brand);
        }
        #endregion

        #region [ Column Set ]
        /// <summary>
        /// Set <see cref="CategoryId"/>.
        /// </summary>
        /// <param name="category">The category that is linked to a brand.</param>
        public CategoryBrand SetCategoryId([NotNull] Category category)
        {
            this.CategoryId = Check.NotNull(category, nameof(category)).Id;
            return this;
        }

        /// <summary>
        /// Set <see cref="BrandId"/>.
        /// </summary>
        /// <param name="brand">The brand that is linked to the category.</param>
        public CategoryBrand SetBrandId([NotNull] Brand brand)
        {
            this.BrandId = Check.NotNull(brand, nameof(brand)).Id;
            return this;
        }
        #endregion

        #region [ To String ]
        /// <summary>
        /// Returns a string that represents the current category brand.
        /// </summary>
        public override string ToString()
        {
            return $"{nameof(this.Category)}:{((null != this.Category) ? this.Category.Name : this.CategoryId)}" +
                   $" - " +
                   $"{nameof(this.Brand)}:{((null != this.Brand) ? this.Brand.Name : this.BrandId)}";
        }
        #endregion
    }
}
