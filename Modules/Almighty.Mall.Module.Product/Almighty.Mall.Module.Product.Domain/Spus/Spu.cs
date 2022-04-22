using Almighty.Mall.Module.Product.Brands;
using Almighty.Mall.Module.Product.Categories;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Almighty.Mall.Module.Product.Spus
{
    /// <summary>
    /// Represents a Spu(Standard Product Unit) in the product module.
    /// </summary>
    [Table("Spus")]
    [Comment("Represents a Spu(Standard Product Unit) in the product module.")]
    public class Spu : FullAuditedAggregateRoot<Guid>
    {
        #region [ Constants ]
        /// <summary>
        /// Maximum length of the <see cref="Name"/> property.
        /// </summary>
        private const int MAX_NAME_LENGTH = 128;

        /// <summary>
        /// Maximum length of the <see cref="SellingPoint"/> property.
        /// </summary>
        private const int MAX_SELLING_POINT_LENGTH = 256;

        /// <summary>
        /// Maximum length of the <see cref="MainImage"/> property.
        /// </summary>
        private const int MAX_MAIN_IMAGE_LENGTH = 256;

        /// <summary>
        /// Maximum length of the <see cref="Images"/> property.
        /// </summary>
        private const int MAX_IMAGES_LENGTH = 2048;

        /// <summary>
        /// Maximum length of the <see cref="Video"/> property.
        /// </summary>
        private const int MAX_VIDEO_LENGTH = 256;
        #endregion

        #region [ Columns ]
        /// <summary>
        /// Gets or sets the sequence for the spu (e.g. 0, 1, 2, ...).
        /// </summary>
        [Required]
        [Column($"{nameof(Sequence)}", TypeName = "int")]
        [Comment("The sequence for the spu (e.g. 0, 1, 2, ...).")]
        public virtual int Sequence { get; set; }

        /// <summary>
        /// Gets or sets the foreign key of the spu that is linked to a brand. Null, if brand not yet defined.
        /// </summary>
        [Column($"{nameof(BrandId)}", TypeName = "uniqueidentifier")]
        [Comment("The foreign key of the spu that is linked to a brand. Null, if brand not yet defined.")]
        public virtual Guid? BrandId { get; set; }

        /// <summary>
        /// Gets or sets the foreign key of the spu that is linked to a category.
        /// </summary>
        [Required]
        [Column($"{nameof(CategoryId)}", TypeName = "uniqueidentifier")]
        [Comment("The foreign key of the spu that is linked to a category.")]
        public virtual Guid CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the foreign key of the spu that is linked to a seller.
        /// </summary>
        [Required]
        [Column($"{nameof(SellerId)}", TypeName = "uniqueidentifier")]
        [Comment("The foreign key of the spu that is linked to a seller.")]
        public virtual Guid SellerId { get; set; }

        /// <summary>
        /// Gets or sets the foreign key of the spu that is linked to a seller category.
        /// </summary>
        [Required]
        [Column($"{nameof(SellerCategoryId)}", TypeName = "uniqueidentifier")]
        [Comment("The foreign key of the spu that is linked to a seller category.")]
        public virtual Guid SellerCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the name for the spu (e.g. iPhone XS, iPhone 13, ...).
        /// </summary>
        [Required]
        [Column($"{nameof(Name)}", TypeName = "nvarchar(256)")]
        [Comment("The name for the spu (e.g. iPhone XS, iPhone 13, ...).")]
        [StringLength(MAX_NAME_LENGTH)]
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the selling point for the spu (e.g. iPhone 13, Your new superpower. Take a great photo without lifting a finger.).
        /// </summary>
        [Required]
        [Column($"{nameof(SellingPoint)}", TypeName = "nvarchar(256)")]
        [Comment("The selling point for the spu (e.g. iPhone 13, Your new superpower. Take a great photo without lifting a finger.).")]
        [StringLength(MAX_SELLING_POINT_LENGTH)]
        public virtual string SellingPoint { get; set; }

        /// <summary>
        /// Gets or sets the main image url for the spu.
        /// </summary>
        [Required]
        [Column($"{nameof(MainImage)}", TypeName = "nvarchar(256)")]
        [Comment("The main image url for the spu.")]
        [StringLength(MAX_MAIN_IMAGE_LENGTH)]
        public virtual string MainImage { get; set; }

        /// <summary>
        /// Gets or sets the images for the spu (images is a array json for image urls).
        /// </summary>
        [Column($"{nameof(Images)}", TypeName = "nvarchar(2048)")]
        [Comment("The images for the spu (images is a array json for image urls).")]
        [StringLength(MAX_IMAGES_LENGTH)]
        public virtual string Images { get; set; }

        /// <summary>
        /// Gets or sets the video url for the spu.
        /// </summary>
        [Column($"{nameof(Video)}", TypeName = "nvarchar(256)")]
        [Comment("The video url for the spu.")]
        [StringLength(MAX_VIDEO_LENGTH)]
        public virtual string Video { get; set; }

        /// <summary>
        /// Gets or sets the guidance price for the spu (e.g. 199.99, 998.00, ...). Null, If not needed.
        /// </summary>
        [Column($"{nameof(GuidancePrice)}", TypeName = "decimal(19,4)")]
        [Comment("The guidance price for the spu (e.g. 199.99, 998.00, ...). Null, If not needed.")]
        public virtual decimal? GuidancePrice { get; set; }

        /// <summary>
        /// Gets or sets the price for the spu (e.g. 199.99, 998.00, ...).
        /// </summary>
        [Required]
        [Column($"{nameof(Price)}", TypeName = "decimal(19,4)")]
        [Comment("The price for the spu (e.g. 199.99, 998.00, ...).")]
        public virtual decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the offer price for the spu (e.g. 199.99, 998.00, ...). Null, If not needed.
        /// </summary>
        [Column($"{nameof(OfferPrice)}", TypeName = "decimal(19,4)")]
        [Comment("The offer price for the spu (e.g. 199.99, 998.00, ...). Null, If not needed.")]
        public virtual decimal? OfferPrice { get; set; }

        /// <summary>
        /// Gets or sets the state for the spu (e.g. 0:Disabled, 1:Enabled, ...).
        /// </summary>
        [Required]
        [Column($"{nameof(State)}", TypeName = "tinyint")]
        [Comment("The state for the spu (e.g. 0:Disabled, 1:Enabled, ...).")]
        public virtual State State { get; set; }
        #endregion

        #region [ Foreign ]
        /// <summary>
        /// Gets or sets the foreign key of the spu that is linked to a brand. Null, if brand not yet defined.
        /// </summary>
        [ForeignKey(nameof(BrandId))]
        public virtual Brand Brand { get; set; }

        /// <summary>
        /// Gets or sets the foreign key of the spu that is linked to a category.
        /// </summary>
        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }

        /// <summary>
        /// Gets or sets the foreign key of the spu that is linked to a seller category.
        /// </summary>
        [ForeignKey(nameof(SellerCategoryId))]
        public virtual Category SellerCategory { get; set; }

        /// <summary>
        /// Gets or sets the links of the spu that is linked to a spu detail.
        /// </summary>
        public virtual ICollection<SpuDetail> SpuDetails { get; set; }
        #endregion

        #region [ Constructor ]
        /// <summary>
        /// <para>Initializes a new instance of the <see cref="Spu"/> class.</para>
        /// <para>Default constructor is needed for ORMs.</para>
        /// </summary>
        protected Spu()
        {
            /* Do nothing. */
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Spu"/> class.
        /// </summary>
        /// <param name="sequence">The sequence for the spu (e.g. 0, 1, 2, ...).</param>
        /// <param name="brand">The foreign key of the spu that is linked to a brand. Null, if brand not yet defined.</param>
        /// <param name="category">The foreign key of the spu that is linked to a category.</param>
        /// <param name="seller">The foreign key of the spu that is linked to a seller.</param>
        /// <param name="sellerCategory">The foreign key of the spu that is linked to a seller category.</param>
        /// <param name="name">The name for the spu (e.g. iPhone XS, iPhone 13, ...).</param>
        /// <param name="sellingPoint">The selling point for the spu (e.g. iPhone 13, Your new superpower. Take a great photo without lifting a finger.).</param>
        /// <param name="mainImage">The main image url for the spu.</param>
        /// <param name="images">The images for the spu (images is a array json for image urls).</param>
        /// <param name="video">The video url for the spu.</param>
        /// <param name="guidancePrice">The guidance price for the spu (e.g. 199.99, 998.00, ...). Null, If not needed.</param>
        /// <param name="price">The price for the spu (e.g. 199.99, 998.00, ...).</param>
        /// <param name="offerPrice">The offer price for the spu (e.g. 199.99, 998.00, ...). Null, If not needed.</param>
        /// <param name="state">The state for the spu (e.g. 0:Disabled, 1:Enabled, ...).</param>
        public Spu(            int      sequence,
                   [CanBeNull] Brand    brand,
                   [NotNull]   Category category,
                   [NotNull]   Guid     seller,
                   [NotNull]   Category sellerCategory,
                   [NotNull]   string   name,
                   [NotNull]   string   sellingPoint,
                   [NotNull]   string   mainImage,
                   [CanBeNull] string   images,
                   [CanBeNull] string   video,
                   [CanBeNull] decimal? guidancePrice,
                               decimal  price,
                   [CanBeNull] decimal? offerPrice,
                   [NotNull]   State    state)
            : this()
        {
            Check.NotNull(category,                 nameof(category));
            Check.NotNull(seller,                   nameof(seller));
            Check.NotNull(sellerCategory,           nameof(sellerCategory));
            Check.NotNullOrWhiteSpace(name,         nameof(name));
            Check.NotNullOrWhiteSpace(sellingPoint, nameof(sellingPoint));
            Check.NotNullOrWhiteSpace(mainImage,    nameof(mainImage));
            Check.NotNull(state,                    nameof(state));

            if (name.Length > Spu.MAX_NAME_LENGTH)
            {
                throw new ArgumentException($"{nameof(Spu)} {nameof(name)} can not be longer than {Spu.MAX_NAME_LENGTH}");
            }
            if (sellingPoint.Length > Spu.MAX_SELLING_POINT_LENGTH)
            {
                throw new ArgumentException($"{nameof(Spu)} {nameof(sellingPoint)} can not be longer than {Spu.MAX_SELLING_POINT_LENGTH}");
            }
            if (mainImage.Length > Spu.MAX_MAIN_IMAGE_LENGTH)
            {
                throw new ArgumentException($"{nameof(Spu)} {nameof(mainImage)} can not be longer than {Spu.MAX_MAIN_IMAGE_LENGTH}");
            }
            if (images.Length > Spu.MAX_IMAGES_LENGTH)
            {
                throw new ArgumentException($"{nameof(Spu)} {nameof(images)} can not be longer than {Spu.MAX_IMAGES_LENGTH}");
            }
            if (video.Length > Spu.MAX_VIDEO_LENGTH)
            {
                throw new ArgumentException($"{nameof(Spu)} {nameof(video)} can not be longer than {Spu.MAX_VIDEO_LENGTH}");
            }
            if ((null != guidancePrice) && (guidancePrice < decimal.Zero))
            {
                throw new ArgumentException($"{nameof(Spu)} {nameof(guidancePrice)} can not be less than {decimal.Zero}");
            }
            if (price < decimal.Zero)
            {
                throw new ArgumentException($"{nameof(Spu)} {nameof(price)} can not be less than {decimal.Zero}");
            }
            if ((null != offerPrice) && (offerPrice < decimal.Zero))
            {
                throw new ArgumentException($"{nameof(Spu)} {nameof(offerPrice)} can not be less than {decimal.Zero}");
            }

            this.Sequence         = sequence;
            this.BrandId          = brand.Id;
            this.CategoryId       = category.Id;
            this.SellerId         = seller;
            this.SellerCategoryId = sellerCategory.Id;
            this.Name             = name;
            this.SellingPoint     = sellingPoint;
            this.MainImage        = mainImage;
            this.Images           = images;
            this.Video            = video;
            this.GuidancePrice    = guidancePrice;
            this.Price            = price;
            this.OfferPrice       = offerPrice;
            this.State            = state;
        }
        #endregion

        #region [ To String ]
        /// <summary>
        /// Returns a string that represents the spu.
        /// </summary>
        public override string ToString()
        {
            return $"{nameof(this.Name)}:{this.Name}" +
                   $" - " +
                   $"{nameof(this.Price)}:{this.Price}";
        }
        #endregion
    }
}
