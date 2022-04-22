using Almighty.Mall.Module.Product.Categories;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        private const int MAX_NAME_LENGTH = 128;

        /// <summary>
        /// Maximum length of the <see cref="Logo"/> property.
        /// </summary>
        private const int MAX_LOGO_LENGTH = 256;

        /// <summary>
        /// Maximum length of the <see cref="Image"/> property.
        /// </summary>
        private const int MAX_IMAGE_LENGTH = 256;

        /// <summary>
        /// Maximum length of the <see cref="BigImage"/> property.
        /// </summary>
        private const int MAX_BIG_IMAGE_LENGTH = 256;

        /// <summary>
        /// Maximum length of the <see cref="FirstWord"/> property.
        /// </summary>
        private const int MAX_FIRST_WORD_LENGTH = 1;

        /// <summary>
        /// Maximum length of the <see cref="Brief"/> property.
        /// </summary>
        private const int MAX_BRIEF_LENGTH = 256;
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
        [StringLength(MAX_NAME_LENGTH)]
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the logo url for the brand.
        /// </summary>
        [Required]
        [Column($"{nameof(Logo)}", TypeName = "nvarchar(256)")]
        [Comment("The logo url for the brand.")]
        [StringLength(MAX_LOGO_LENGTH)]
        public virtual string Logo { get; set; }

        /// <summary>
        /// Gets or sets the image url for the brand.
        /// </summary>
        [Column($"{nameof(Image)}", TypeName = "nvarchar(256)")]
        [Comment("The image url for the brand.")]
        [StringLength(MAX_IMAGE_LENGTH)]
        public virtual string Image { get; set; }

        /// <summary>
        /// Gets or sets the big image url for the brand.
        /// </summary>
        [Column($"{nameof(BigImage)}", TypeName = "nvarchar(256)")]
        [Comment("The big image url for the brand.")]
        [StringLength(MAX_BIG_IMAGE_LENGTH)]
        public virtual string BigImage { get; set; }

        /// <summary>
        /// Gets or sets the first word for the brand (e.g. A:Apple, S:Samsung, ...).
        /// </summary>
        [Required]
        [Column($"{nameof(FirstWord)}", TypeName = "nvarchar(1)")]
        [Comment("The first word for the brand (e.g. A:Apple, S:Samsung, ...).")]
        [StringLength(MAX_FIRST_WORD_LENGTH)]
        public virtual string FirstWord { get; set; }

        /// <summary>
        /// Gets or sets the brief for the brand (e.g. Apple Inc. is a multinational company that makes personal computers ...).
        /// </summary>
        [Required]
        [Column($"{nameof(Brief)}", TypeName = "nvarchar(256)")]
        [Comment("The brief for the brand (e.g. Apple Inc. is a multinational company that makes personal computers ...).")]
        [StringLength(MAX_BRIEF_LENGTH)]
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
        /// <param name="logo">The logo url for the brand.</param>
        /// <param name="image">The image url for the brand.</param>
        /// <param name="bigImage">The big image url for the brand.</param>
        /// <param name="firstWord">The first word for the brand (e.g. A:Apple, S:Samsung, ...).</param>
        /// <param name="brief">The brief for the brand (e.g. Apple Inc. is a multinational company that makes personal computers ...).</param>
        /// <param name="story">The story for the brand.</param>
        /// <param name="state">The state for the brand (e.g. 0:Disabled, 1:Enabled, ...).</param>
        public Brand(            int    sequence,
                     [NotNull]   string name,
                     [NotNull]   string logo,
                     [CanBeNull] string image,
                     [CanBeNull] string bigImage,
                     [NotNull]   string firstWord,
                     [NotNull]   string brief,
                     [CanBeNull] string story,
                     [NotNull]   State  state)
            : this()
        {
            Check.NotNullOrWhiteSpace(name,      nameof(name));
            Check.NotNullOrWhiteSpace(logo,      nameof(logo));
            Check.NotNullOrWhiteSpace(firstWord, nameof(firstWord));
            Check.NotNullOrWhiteSpace(brief,     nameof(brief));
            Check.NotNull(state,                 nameof(state));

            if (name.Length > Brand.MAX_NAME_LENGTH)
            {
                throw new ArgumentException($"{nameof(Brand)} {nameof(name)} can not be longer than {Brand.MAX_NAME_LENGTH}");
            }
            if (logo.Length > Brand.MAX_LOGO_LENGTH)
            {
                throw new ArgumentException($"{nameof(Brand)} {nameof(logo)} can not be longer than {Brand.MAX_LOGO_LENGTH}");
            }
            if (image?.Length > Brand.MAX_IMAGE_LENGTH)
            {
                throw new ArgumentException($"{nameof(Brand)} {nameof(image)} can not be longer than {Brand.MAX_IMAGE_LENGTH}");
            }
            if (bigImage?.Length > Brand.MAX_BIG_IMAGE_LENGTH)
            {
                throw new ArgumentException($"{nameof(Brand)} {nameof(bigImage)} can not be longer than {Brand.MAX_BIG_IMAGE_LENGTH}");
            }
            if (firstWord.Length > Brand.MAX_FIRST_WORD_LENGTH)
            {
                throw new ArgumentException($"{nameof(Brand)} {nameof(firstWord)} can not be longer than {Brand.MAX_FIRST_WORD_LENGTH}");
            }
            if (brief.Length > Brand.MAX_BRIEF_LENGTH)
            {
                throw new ArgumentException($"{nameof(Brand)} {nameof(brief)} can not be longer than {Brand.MAX_BRIEF_LENGTH}");
            }

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
