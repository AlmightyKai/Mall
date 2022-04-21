using Almighty.Mall.Module.Product.Categories;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Almighty.Mall.Module.Product.Brands
{
    /// <summary>
    /// Represents a brand in the product module.
    /// </summary>
    [Table("Brands")]
    [Comment("Represents a brand in the product module.")]
    public class Brand : FullAuditedAggregateRoot<Guid>
    {
        #region [ Constants ]
        /// <summary>
        /// Maximum length of the <see cref="Name"/> property.
        /// </summary>
        private const int MaxNameLength = 128;
        #endregion

        #region [ Columns ]
        /// <summary>
        /// Gets or sets the sequence for the brand (e.g. 0, 1, 2, ...).
        /// </summary>
        [Required]
        [Column($"{nameof(Sequence)}", TypeName = "int")]
        [Comment("The sequence for the brand (e.g. 0, 1, 2, ...).")]
        public virtual int Sequence { get; set; }

        /// <summary>
        /// Gets or sets the name for the brand (e.g. Apple, Samsung, ...).
        /// </summary>
        [Required]
        [Column($"{nameof(Name)}", TypeName = "nvarchar(256)")]
        [Comment("The name for the brand (e.g. Apple, Samsung, ...).")]
        [StringLength(MaxNameLength)]
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the logo for the brand (e.g. https://www-file.huawei.com/-/media/corporate/images/home/logo/huawei_logo.png).
        /// </summary>
        [Required]
        [Column($"{nameof(Logo)}", TypeName = "nvarchar(256)")]
        [Comment("The logo for the brand (e.g. https://www-file.huawei.com/-/media/corporate/images/home/logo/huawei_logo.png).")]
        public virtual string Logo { get; set; }

        /// <summary>
        /// Gets or sets the image for the brand (e.g. https://www-file.huawei.com/-/media/corporate/images/home/logo/huawei_logo.png).
        /// </summary>
        [Column($"{nameof(Image)}", TypeName = "nvarchar(256)")]
        [Comment("The image for the brand (e.g. https://www-file.huawei.com/-/media/corporate/images/home/logo/huawei_logo.png).")]
        public virtual string Image { get; set; }

        /// <summary>
        /// Gets or sets the big image for the brand (e.g. https://www-file.huawei.com/-/media/corporate/images/home/logo/huawei_logo.png).
        /// </summary>
        [Column($"{nameof(BigImage)}", TypeName = "nvarchar(256)")]
        [Comment("The big image for the brand (e.g. https://www-file.huawei.com/-/media/corporate/images/home/logo/huawei_logo.png).")]
        public virtual string BigImage { get; set; }

        /// <summary>
        /// Gets or sets the first word for the brand (e.g. A:Apple, S:Samsung, ...).
        /// </summary>
        [Required]
        [Column($"{nameof(FirstWord)}", TypeName = "nvarchar(1)")]
        [Comment("The first word for the brand (e.g. A:Apple, S:Samsung, ...).")]
        public virtual string FirstWord { get; set; }

        /// <summary>
        /// Gets or sets the brief for the brand (e.g. Apple Inc. is a multinational company that makes personal computers ...).
        /// </summary>
        [Required]
        [Column($"{nameof(Brief)}", TypeName = "nvarchar(256)")]
        [Comment("The brief for the brand (e.g. Apple Inc. is a multinational company that makes personal computers ...).")]
        public virtual string Brief { get; set; }

        /// <summary>
        /// Gets or sets the story for the brand.
        /// </summary>
        [Column($"{nameof(Story)}", TypeName = "ntext")]
        [Comment("The story for the brand.")]
        public virtual string Story { get; set; }

        /// <summary>
        /// Gets or sets the state for the brand (e.g. 0:Disabled, 1:Enabled, ...).
        /// </summary>
        [Required]
        [Column($"{nameof(State)}", TypeName = "tinyint")]
        [Comment("The state for the brand (e.g. 0:Disabled, 1:Enabled, ...).")]
        public virtual State State { get; set; }
        #endregion

        #region [ Foreign ]
        /// <summary>
        /// Gets or sets the links of the brand that is linked to all categories.
        /// </summary>
        public virtual ICollection<CategoryBrand> CategoryBrands { get; set; }
        #endregion

        #region [ Constructor ]
        /// <summary>
        /// <para>Initializes a new instance of the <see cref="Brand"/> class.</para>
        /// <para>Default constructor is needed for ORMs.</para>
        /// </summary>
        protected Brand()
        {
            /* Do nothing. */
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Brand"/> class.
        /// </summary>
        /// <param name="sequence">The sequence for the brand (e.g. 0, 1, 2, ...).</param>
        /// <param name="name">The name for the brand (e.g. Apple, Samsung, ...).</param>
        /// <param name="logo">The logo for the brand (e.g. https://www-file.huawei.com/-/media/corporate/images/home/logo/huawei_logo.png).</param>
        /// <param name="image">The image for the brand (e.g. https://www-file.huawei.com/-/media/corporate/images/home/logo/huawei_logo.png).</param>
        /// <param name="bigImage">The big image for the brand (e.g. https://www-file.huawei.com/-/media/corporate/images/home/logo/huawei_logo.png).</param>
        /// <param name="firstWord">The first word for the brand (e.g. A:Apple, S:Samsung, ...).</param>
        /// <param name="brief">The brief for the brand (e.g. Apple Inc. is a multinational company that makes personal computers ...).</param>
        /// <param name="story">The story for the brand.</param>
        /// <param name="state">The state for the brand (e.g. 0:Disabled, 1:Enabled, ...).</param>
        public Brand(          int    sequence,
                     [NotNull] string name,
                     [NotNull] string logo,
                               string image,
                               string bigImage,
                     [NotNull] string firstWord,
                     [NotNull] string brief,
                               string story,
                     [NotNull] State  state)
            : this()
        {
            Check.NotNullOrWhiteSpace(name,      nameof(name));
            Check.NotNullOrWhiteSpace(logo,      nameof(logo));
            Check.NotNullOrWhiteSpace(firstWord, nameof(firstWord));
            Check.NotNullOrWhiteSpace(brief,     nameof(brief));
            Check.NotNull(state,                 nameof(state));

            this.Sequence  = sequence;
            this.Name      = name;
            this.Logo      = logo;
            this.Image     = image;
            this.BigImage  = bigImage;
            this.FirstWord = firstWord;
            this.Brief     = brief;
            this.Story     = story;
            this.State     = state;
        }
        #endregion

        #region [ To String ]
        /// <summary>
        /// Returns a string that represents the current brand.
        /// </summary>
        public override string ToString()
        {
            return $"{nameof(this.Name)}:{this.Name}" +
                   $" - " +
                   $"{nameof(this.Brief)}:{this.Brief}";
        }
        #endregion
    }
}
