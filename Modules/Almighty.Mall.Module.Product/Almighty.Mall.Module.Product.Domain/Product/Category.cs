using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;

namespace Almighty.Mall.Module.Product
{
    /// <summary>
    /// Represents a category for product.
    /// </summary>
    [Table("Categories")]
    [Comment("Represents a category for product.")]
    public class Category : FullAuditedAggregateRoot<Guid>
    {
        #region [ Constants ]
        /// <summary>
        /// Maximum length of the <see cref="DisplayName"/> property.
        /// </summary>
        private const int MaxDisplayNameLength = 128;

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
        /// <para>Parent <see cref="Category"/> Id.</para>
        /// <para>Null, if this category is root.</para>
        /// </summary>
        [Column("ParentId", TypeName = "uniqueidentifier")]
        [Comment("Parent category id. Null, if this category is root.")]
        public virtual Guid? ParentId { get; set; }

        /// <summary>
        /// <para>Hierarchical Code of this organization unit.</para>
        /// <para>Example: "00001.00042.00005".</para>
        /// <para>It's changeable if category hierarch is changed.</para>
        /// </summary>
        [Required]
        [Column("Code", TypeName = "nvarchar")]
        [Comment("Hierarchical Code of this organization unit. Example: \"00001.00042.00005\". It's changeable if category hierarch is changed.")]
        [StringLength(MaxCodeLength)]
        public virtual string Code { get; set; }

        /// <summary>
        /// Display name of this category.
        /// </summary>
        [Required]
        [Column("DisplayName", TypeName = "nvarchar")]
        [Comment("Display name of this category.")]
        [StringLength(MaxDisplayNameLength)]
        public virtual string DisplayName { get; set; }

        /// <summary>
        /// Display icon of this category.
        /// </summary>
        [Column("DisplayIcon", TypeName = "nvarchar(255)")]
        [Comment("Display icon of this category.")]
        public virtual string DisplayIcon { get; set; }

        /// <summary>
        /// Display image of this category.
        /// </summary>
        [Column("DisplayImage", TypeName = "nvarchar(255)")]
        [Comment("Display image of this category.")]
        public virtual string DisplayImage { get; set; }

        /// <summary>
        /// Commission rate of this category.
        /// </summary>
        [Column("CommissionRate", TypeName = "decimal(10, 2)")]
        [Comment("Commission rate of this category.")]
        public virtual decimal CommissionRate { get; set; }

        /// <summary>
        /// A flag indicating if the category is disabled.
        /// </summary>
        [Column("IsDisabled", TypeName = "bit")]
        [Comment("A flag indicating if the category is disabled.")]
        public virtual bool IsDisabled { get; set; }
        #endregion

        #region [ Foreign ]
        /// <summary>
        /// <para>Parent <see cref="Category"/>.</para>
        /// <para>Null, if this category is root.</para>
        /// </summary>
        [ForeignKey(nameof(ParentId))]
        public virtual Category Parent { get; set; }

        /// <summary>
        /// Children of this category.
        /// </summary>
        public virtual ICollection<Category> Children { get; set; }
        #endregion

        #region [ Constructor ]
        /// <summary>
        /// <para>Initializes a new instance of the <see cref="Attribute"/> class.</para> 
        /// <para>Default constructor is needed for ORMs.</para> 
        /// </summary>
        private Category()
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
                throw new ArgumentNullException(nameof(childCode), "childCode can not be null or empty.");
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
                throw new ArgumentNullException(nameof(code), "code can not be null or empty.");
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
                throw new ArgumentNullException(nameof(code), "code can not be null or empty.");
            }

            var parentCode = Category.GetParentCode(code);
            var lastUnitCode = Category.GetLastUnitCode(code);

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
                throw new ArgumentNullException(nameof(code), "code can not be null or empty.");
            }

            var splittedCode = code.Split('.');
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
                throw new ArgumentNullException(nameof(code), "code can not be null or empty.");
            }

            var splittedCode = code.Split('.');
            if (splittedCode.Length == 1)
            {
                return null;
            }

            return splittedCode.Take(splittedCode.Length - 1).JoinAsString(".");
        }
        #endregion

        #region [ To String ]
        /// <summary>
        /// Returns a string that represents the current attribute.
        /// </summary>
        public override string ToString() => $"{this.Code} --> {this.DisplayName}";
        #endregion
    }
}
