using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Almighty.Mall.Module.Product.Categories
{
    /// <summary>
    /// Represents a category in the product module.
    /// </summary>
    [Table("Categories")]
    [Comment("Represents a category in the product module.")]
    public class Category : AuditedAggregateRoot<Guid>
    {
        #region [ Constants ]
        /// <summary>
        /// Maximum length of the <see cref="Name"/> property.
        /// </summary>
        private const int MaxNameLength = 128;

        /// <summary>
        /// Maximum depth of an category hierarchy.
        /// </summary>
        private const int MaxDepth = 16;

        /// <summary>
        /// Length of a code unit between dots.
        /// </summary>
        private const int CodeUnitLength = 5;

        /// <summary>
        /// Maximum length of the <see cref="Code"/> property.
        /// </summary>
        private const int MaxCodeLength = MaxDepth * (CodeUnitLength + 1) - 1;
        #endregion

        #region [ Columns ]
        /// <summary>
        /// Gets or sets the foreign key of the category that is linked to a seller. Null, if this category in platform.
        /// </summary>
        [Column($"{nameof(SellerId)}", TypeName = "uniqueidentifier")]
        [Comment("The foreign key of the category that is linked to a seller. Null, if this category in platform.")]
        public virtual Guid? SellerId { get; set; }

        /// <summary>
        /// Gets or sets the parent of the category. Null, if this category is root.
        /// </summary>
        [Column($"{nameof(ParentId)}", TypeName = "uniqueidentifier")]
        [Comment("The parent of the category. Null, if this category is root.")]
        public virtual Guid? ParentId { get; set; }

        /// <summary>
        /// Gets or sets the hierarchical code for the category (e.g. 00001.00042.00005). It's changeable if category hierarch is changed.
        /// </summary>
        [Required]
        [Column($"{nameof(Code)}", TypeName = "nvarchar(256)")]
        [Comment("The hierarchical code for the category (e.g. 00001.00042.00005). It's changeable if category hierarch is changed.")]
        [StringLength(MaxCodeLength)]
        public virtual string Code { get; set; }

        /// <summary>
        /// Gets or sets the name for the category (e.g. Phone, PC, ...).
        /// </summary>
        [Required]
        [Column($"{nameof(Name)}", TypeName = "nvarchar(256)")]
        [Comment("The name for the category (e.g. Phone, PC, ...).")]
        [StringLength(MaxNameLength)]
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the icon for the category (e.g. https://www-file.huawei.com/-/media/corporate/images/home/logo/huawei_logo.png).
        /// </summary>
        [Required]
        [Column($"{nameof(Icon)}", TypeName = "nvarchar(256)")]
        [Comment("The icon for the category (e.g. https://www-file.huawei.com/-/media/corporate/images/home/logo/huawei_logo.png).")]
        public virtual string Icon { get; set; }

        /// <summary>
        /// Gets or sets the image for the category (e.g. https://www-file.huawei.com/-/media/corporate/images/home/logo/huawei_logo.png).
        /// </summary>
        [Column($"{nameof(Image)}", TypeName = "nvarchar(256)")]
        [Comment("The image for the category (e.g. https://www-file.huawei.com/-/media/corporate/images/home/logo/huawei_logo.png).")]
        public virtual string Image { get; set; }

        /// <summary>
        /// Gets or sets the commission rate for the category (e.g. 0.01:1%, 0.1:10%, ...).
        /// </summary>
        [Required]
        [Column($"{nameof(CommissionRate)}", TypeName = "decimal(10, 2)")]
        [Comment("The commission rate for the category (e.g. 0.01:1%, 0.1:10%, ...).")]
        public virtual decimal CommissionRate { get; set; }

        /// <summary>
        /// Gets or sets the description for the category.
        /// </summary>
        [Required]
        [Column($"{nameof(Description)}", TypeName = "nvarchar(256)")]
        [Comment("The description for the category.")]
        public virtual string Description { get; set; }

        /// <summary>
        /// Gets or sets the state for the category (e.g. 0:Disabled, 1:Enabled, ...).
        /// </summary>
        [Required]
        [Column($"{nameof(State)}", TypeName = "tinyint")]
        [Comment("The state for the category (e.g. 0:Disabled, 1:Enabled, ...).")]
        public virtual State State { get; set; }
        #endregion

        #region [ Foreign ]
        /// <summary>
        /// Gets or sets the parent of the category. Null, if this category is root.
        /// </summary>
        [ForeignKey(nameof(ParentId))]
        public virtual Category Parent { get; set; }

        /// <summary>
        /// Gets or sets the children of the category.
        /// </summary>
        public virtual ICollection<Category> Children { get; set; }

        /// <summary>
        /// Gets or sets the links of the category that is linked to all brands.
        /// </summary>
        public virtual ICollection<CategoryBrand> CategoryBrands { get; set; }
        #endregion

        #region [ Constructor ]
        /// <summary>
        /// <para>Initializes a new instance of the <see cref="Category"/> class.</para>
        /// <para>Default constructor is needed for ORMs.</para>
        /// </summary>
        protected Category()
        {
            /* Do nothing. */
        }

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="Category"/> class.</para>
        /// </summary>
        /// <param name="seller">The foreign key of the category that is linked to a seller. Null, if this category in platform.</param>
        /// <param name="parent">The parent of the category. Null, if this category is root.</param>
        /// <param name="code">The hierarchical code for the category (e.g. 00001.00042.00005). It's changeable if category hierarch is changed.</param>
        /// <param name="name">The name for the category (e.g. Phone, PC, ...).</param>
        /// <param name="icon">The icon for the category (e.g. https://www-file.huawei.com/-/media/corporate/images/home/logo/huawei_logo.png).</param>
        /// <param name="image">The image for the category (e.g. https://www-file.huawei.com/-/media/corporate/images/home/logo/huawei_logo.png).</param>
        /// <param name="commissionRate">The commission rate for the category (e.g. 0.01:1%, 0.1:10%, ...).</param>
        /// <param name="description">The description for the category.</param>
        /// <param name="state">The state for the category (e.g. 0:Disabled, 1:Enabled, ...).</param>
        public Category(          Guid?    seller,
                                  Category parent,
                        [NotNull] string   code,
                        [NotNull] string   name,
                        [NotNull] string   icon,
                                  string   image,
                        [NotNull] decimal  commissionRate,
                        [NotNull] string   description,
                        [NotNull] State    state)
            : this()
        {
            Check.NotNullOrWhiteSpace(code,        nameof(code));
            Check.NotNullOrWhiteSpace(name,        nameof(name));
            Check.NotNullOrWhiteSpace(icon,        nameof(icon));
            Check.NotNull(commissionRate,          nameof(commissionRate));
            Check.NotNullOrWhiteSpace(description, nameof(description));
            Check.NotNull(state,                   nameof(state));

            if (code.Length >= Category.MaxCodeLength)
            {
                throw new ArgumentException($"{nameof(Category)} {nameof(code)} can not be longer than {Category.MaxCodeLength}");
            }
            if (code.Length >= Category.MaxNameLength)
            {
                throw new ArgumentException($"{nameof(Category)} {nameof(name)} can not be longer than {Category.MaxNameLength}");
            }

            this.SellerId       = seller;
            this.ParentId       = parent?.Id;
            this.Code           = code;
            this.Name           = name;
            this.Icon           = icon;
            this.Image          = image;
            this.CommissionRate = commissionRate;
            this.Description    = description;
            this.State          = state;
        }
        #endregion

        #region [ Code ]
        /// <summary>
        /// <para>Creates code for given numbers.</para>
        /// <para>Example: if numbers are 4,2 then returns "00004.00002";</para>
        /// </summary>
        /// <param name="numbers">Numbers</param>
        public static string CreateCode(params int[] numbers)
        {
            if (numbers.IsNullOrEmpty())
            {
                return null;
            }

            return numbers.Select(number => number.ToString(new string('0', Category.CodeUnitLength))).JoinAsString(".");
        }

        /// <summary>
        /// <para>Appends a child code to a parent code. </para>
        /// <para>Example: if parentCode = "00001", childCode = "00042" then returns "00001.00042".</para>
        /// </summary>
        /// <param name="parentCode">Parent code. Can be null or empty if parent is a root.</param>
        /// <param name="childCode">Child code.</param>
        public static string AppendCode(string parentCode, string childCode)
        {
            if (childCode.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(childCode), $"{nameof(childCode)} can not be null or empty.");
            }

            if (parentCode.IsNullOrEmpty())
            {
                return childCode;
            }

            return parentCode + "." + childCode;
        }

        /// <summary>
        /// <para>Gets relative code to the parent.</para>
        /// <para>Example: if code = "00019.00055.00001" and parentCode = "00019" then returns "00055.00001".</para>
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="parentCode">The parent code.</param>
        public static string GetRelativeCode(string code, string parentCode)
        {
            if (code.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(code), $"{nameof(code)} can not be null or empty.");
            }

            if (parentCode.IsNullOrEmpty())
            {
                return code;
            }

            if (code.Length == parentCode.Length)
            {
                return null;
            }

            return code.Substring(parentCode.Length + 1);
        }

        /// <summary>
        /// <para>Calculates next code for given code.</para>
        /// <para>Example: if code = "00019.00055.00001" returns "00019.00055.00002".</para>
        /// </summary>
        /// <param name="code">The code.</param>
        public static string CalculateNextCode(string code)
        {
            if (code.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(code), $"{nameof(code)} can not be null or empty.");
            }

            string parentCode   = Category.GetParentCode(code);
            string lastUnitCode = Category.GetLastUnitCode(code);

            return Category.AppendCode(parentCode, Category.CreateCode(Convert.ToInt32(lastUnitCode) + 1));
        }

        /// <summary>
        /// <para>Gets the last unit code.</para>
        /// <para>Example: if code = "00019.00055.00001" returns "00001".</para>
        /// </summary>
        /// <param name="code">The code.</param>
        public static string GetLastUnitCode(string code)
        {
            if (code.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(code), $"{nameof(code)} can not be null or empty.");
            }

            string[] splittedCode = code.Split('.');

            return splittedCode[splittedCode.Length - 1];
        }

        /// <summary>
        /// <para>Gets parent code.</para>
        /// <para>Example: if code = "00019.00055.00001" returns "00019.00055".</para>
        /// </summary>
        /// <param name="code">The code.</param>
        public static string GetParentCode(string code)
        {
            if (code.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(code), $"{nameof(code)} can not be null or empty.");
            }

            string[] splittedCode = code.Split('.');

            if (splittedCode.Length == 1)
            {
                return null;
            }

            return splittedCode.Take(splittedCode.Length - 1).JoinAsString(".");
        }
        #endregion

        #region [ To String ]
        /// <summary>
        /// Returns a string that represents the current category.
        /// </summary>
        public override string ToString()
        {
            return $"{nameof(this.Code)}:{this.Code}" +
                   $" - " +
                   $"{nameof(this.Name)}:{this.Name}";
        }
        #endregion
    }
}
