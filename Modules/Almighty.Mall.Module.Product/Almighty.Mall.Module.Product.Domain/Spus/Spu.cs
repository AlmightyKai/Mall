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
    /// Represents a spu(standard product unit) in the product module.
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
        [NotNull]
        [Column($"{nameof(Sequence)}", TypeName = "int")]
        [Comment("The sequence for the spu (e.g. 0, 1, 2, ...).")]
        public virtual int Sequence { get; protected set; }

        /// <summary>
        /// Gets or sets the foreign key of the spu that is linked to a brand. Null, if brand not yet defined.
        /// </summary>
        [CanBeNull]
        [Column($"{nameof(BrandId)}", TypeName = "uniqueidentifier")]
        [Comment("The foreign key of the spu that is linked to a brand. Null, if brand not yet defined.")]
        public virtual Guid? BrandId { get; protected set; }

        /// <summary>
        /// Gets or sets the foreign key of the spu that is linked to a category.
        /// </summary>
        [NotNull]
        [Column($"{nameof(CategoryId)}", TypeName = "uniqueidentifier")]
        [Comment("The foreign key of the spu that is linked to a category.")]
        public virtual Guid CategoryId { get; protected set; }

        /// <summary>
        /// Gets or sets the foreign key of the spu that is linked to a seller.
        /// </summary>
        [NotNull]
        [Column($"{nameof(SellerId)}", TypeName = "uniqueidentifier")]
        [Comment("The foreign key of the spu that is linked to a seller.")]
        public virtual Guid SellerId { get; protected set; }

        /// <summary>
        /// Gets or sets the foreign key of the spu that is linked to a seller category.
        /// </summary>
        [NotNull]
        [Column($"{nameof(SellerCategoryId)}", TypeName = "uniqueidentifier")]
        [Comment("The foreign key of the spu that is linked to a seller category.")]
        public virtual Guid SellerCategoryId { get; protected set; }

        /// <summary>
        /// Gets or sets the name for the spu (e.g. iPhone XS, iPhone 13, ...).
        /// </summary>
        [NotNull]
        [Column($"{nameof(Name)}", TypeName = "nvarchar(256)")]
        [Comment("The name for the spu (e.g. iPhone XS, iPhone 13, ...).")]
        [StringLength(MAX_NAME_LENGTH)]
        public virtual string Name { get; protected set; }

        /// <summary>
        /// Gets or sets the selling point for the spu (e.g. iPhone 13, Your new superpower. Take a great photo without lifting a finger.).
        /// </summary>
        [NotNull]
        [Column($"{nameof(SellingPoint)}", TypeName = "nvarchar(256)")]
        [Comment("The selling point for the spu (e.g. iPhone 13, Your new superpower. Take a great photo without lifting a finger.).")]
        [StringLength(MAX_SELLING_POINT_LENGTH)]
        public virtual string SellingPoint { get; protected set; }

        /// <summary>
        /// Gets or sets the main image url for the spu.
        /// </summary>
        [NotNull]
        [Column($"{nameof(MainImage)}", TypeName = "nvarchar(256)")]
        [Comment("The main image url for the spu.")]
        [StringLength(MAX_MAIN_IMAGE_LENGTH)]
        public virtual string MainImage { get; protected set; }

        /// <summary>
        /// Gets or sets the images for the spu (images is a array json for image urls).
        /// </summary>
        [CanBeNull]
        [Column($"{nameof(Images)}", TypeName = "nvarchar(2048)")]
        [Comment("The images for the spu (images is a array json for image urls).")]
        [StringLength(MAX_IMAGES_LENGTH)]
        public virtual string Images { get; protected set; }

        /// <summary>
        /// Gets or sets the video url for the spu.
        /// </summary>
        [CanBeNull]
        [Column($"{nameof(Video)}", TypeName = "nvarchar(256)")]
        [Comment("The video url for the spu.")]
        [StringLength(MAX_VIDEO_LENGTH)]
        public virtual string Video { get; protected set; }

        /// <summary>
        /// Gets or sets the guidance price for the spu (e.g. 199.99, 998.00, ...). Null, If not needed.
        /// </summary>
        [CanBeNull]
        [Column($"{nameof(GuidancePrice)}", TypeName = "decimal(19,4)")]
        [Comment("The guidance price for the spu (e.g. 199.99, 998.00, ...). Null, If not needed.")]
        public virtual decimal? GuidancePrice { get; protected set; }

        /// <summary>
        /// Gets or sets the price for the spu (e.g. 199.99, 998.00, ...).
        /// </summary>
        [NotNull]
        [Column($"{nameof(Price)}", TypeName = "decimal(19,4)")]
        [Comment("The price for the spu (e.g. 199.99, 998.00, ...).")]
        public virtual decimal Price { get; protected set; }

        /// <summary>
        /// Gets or sets the offer price for the spu (e.g. 199.99, 998.00, ...). Null, If not needed.
        /// </summary>
        [CanBeNull]
        [Column($"{nameof(OfferPrice)}", TypeName = "decimal(19,4)")]
        [Comment("The offer price for the spu (e.g. 199.99, 998.00, ...). Null, If not needed.")]
        public virtual decimal? OfferPrice { get; protected set; }

        /// <summary>
        /// Gets or sets the state for the spu (e.g. 0:Disabled, 1:Enabled, ...).
        /// </summary>
        [NotNull]
        [Column($"{nameof(State)}", TypeName = "tinyint")]
        [Comment("The state for the spu (e.g. 0:Disabled, 1:Enabled, ...).")]
        public virtual State State { get; protected set; }
        #endregion

        #region [ Foreign ]
        /// <summary>
        /// Gets or sets the foreign key of the spu that is linked to a brand. Null, if brand not yet defined.
        /// </summary>
        [ForeignKey(nameof(BrandId))]
        public virtual Brand Brand { get; protected set; }

        /// <summary>
        /// Gets or sets the foreign key of the spu that is linked to a category.
        /// </summary>
        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; protected set; }

        /// <summary>
        /// Gets or sets the foreign key of the spu that is linked to a seller category.
        /// </summary>
        [ForeignKey(nameof(SellerCategoryId))]
        public virtual Category SellerCategory { get; protected set; }

        /// <summary>
        /// Gets or sets the links of the spu that is linked to all spu attribute values.
        /// </summary>
        public virtual ICollection<SpuAttributeValue> SpuAttributeValues { get; protected set; }

        /// <summary>
        /// Gets or sets the links of the spu that is linked to all spu details.
        /// </summary>
        public virtual ICollection<SpuDetail> SpuDetails { get; protected set; }

        /// <summary>
        /// Gets or sets the links of the spu that is linked to all spu extensions.
        /// </summary>
        public virtual ICollection<SpuExtension> SpuExtensions { get; protected set; }

        /// <summary>
        /// Gets or sets the links of the spu that is linked to all spu sku attribute values.
        /// </summary>
        public virtual ICollection<SpuSkuAttributeValue> SpuSkuAttributeValues { get; protected set; }
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
        public Spu([NotNull]   int      sequence,
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
                   [NotNull]   decimal  price,
                   [CanBeNull] decimal? offerPrice,
                   [NotNull]   State    state)
            : this()
        {
            this.SetSequence(sequence);
            this.SetBrandId(brand);
            this.SetCategoryId(category);
            this.SetSellerId(seller);
            this.SetSellerCategoryId(sellerCategory);
            this.SetName(name);
            this.SetSellingPoint(sellingPoint);
            this.SetMainImage(mainImage);
            this.SetImages(images);
            this.SetVideo(video);
            this.SetGuidancePrice(guidancePrice);
            this.SetPrice(price);
            this.SetOfferPrice(offerPrice);
            this.SetState(state);
        }
        #endregion

        #region [ Column Set ]
        /// <summary>
        /// Set <see cref="Sequence"/>.
        /// </summary>
        /// <param name="sequence">The sequence for the spu (e.g. 0, 1, 2, ...).</param>
        public Spu SetSequence([NotNull] int sequence)
        {
            this.Sequence = Check.NotNull(sequence, nameof(sequence));
            return this;
        }

        /// <summary>
        /// Set <see cref="BrandId"/>.
        /// </summary>
        /// <param name="brand">The foreign key of the spu that is linked to a brand. Null, if brand not yet defined.</param>
        public Spu SetBrandId([CanBeNull] Brand brand)
        {
            this.BrandId = brand?.Id;
            return this;
        }

        /// <summary>
        /// Set <see cref="CategoryId"/>.
        /// </summary>
        /// <param name="category">The foreign key of the spu that is linked to a category.</param>
        public Spu SetCategoryId([NotNull] Category category)
        {
            this.CategoryId = Check.NotNull(category, nameof(category)).Id;
            return this;
        }

        /// <summary>
        /// Set <see cref="SellerId"/>.
        /// </summary>
        /// <param name="spu">The foreign key of the spu that is linked to a seller.</param>
        public Spu SetSellerId([NotNull] Guid seller)
        {
            this.SellerId = Check.NotNull(seller, nameof(seller));
            return this;
        }

        /// <summary>
        /// Set <see cref="SellerCategoryId"/>.
        /// </summary>
        /// <param name="sellerCategory">The foreign key of the spu that is linked to a seller category.</param>
        public Spu SetSellerCategoryId([NotNull] Category sellerCategory)
        {
            this.SellerCategoryId = Check.NotNull(sellerCategory, nameof(sellerCategory)).Id;
            return this;
        }

        /// <summary>
        /// Set <see cref="Name"/>.
        /// </summary>
        /// <param name="name">The name for the spu (e.g. iPhone XS, iPhone 13, ...).</param>
        public Spu SetName([NotNull] string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            if (name.Length > Spu.MAX_NAME_LENGTH)
            {
                throw new ArgumentException($"{nameof(Spu)} {nameof(name)} can not be longer than {Spu.MAX_NAME_LENGTH}");
            }

            this.Name = name;
            return this;
        }

        /// <summary>
        /// Set <see cref="SellingPoint"/>.
        /// </summary>
        /// <param name="sellingPoint">The selling point for the spu (e.g. iPhone 13, Your new superpower. Take a great photo without lifting a finger.).</param>
        public Spu SetSellingPoint([NotNull] string sellingPoint)
        {
            Check.NotNullOrWhiteSpace(sellingPoint, nameof(sellingPoint));
            if (sellingPoint.Length > Spu.MAX_SELLING_POINT_LENGTH)
            {
                throw new ArgumentException($"{nameof(Spu)} {nameof(sellingPoint)} can not be longer than {Spu.MAX_SELLING_POINT_LENGTH}");
            }

            this.SellingPoint = sellingPoint;
            return this;
        }

        /// <summary>
        /// Set <see cref="MainImage"/>.
        /// </summary>
        /// <param name="mainImage">The main image url for the spu.</param>
        public Spu SetMainImage([NotNull] string mainImage)
        {
            Check.NotNullOrWhiteSpace(mainImage, nameof(mainImage));
            if (mainImage.Length > Spu.MAX_MAIN_IMAGE_LENGTH)
            {
                throw new ArgumentException($"{nameof(Spu)} {nameof(mainImage)} can not be longer than {Spu.MAX_MAIN_IMAGE_LENGTH}");
            }

            this.MainImage = mainImage;
            return this;
        }

        /// <summary>
        /// Set <see cref="Images"/>.
        /// </summary>
        /// <param name="images">The images for the spu (images is a array json for image urls).</param>
        public Spu SetImages([CanBeNull] string images)
        {
            if (images?.Length > Spu.MAX_IMAGES_LENGTH)
            {
                throw new ArgumentException($"{nameof(Spu)} {nameof(images)} can not be longer than {Spu.MAX_IMAGES_LENGTH}");
            }

            this.Images = images;
            return this;
        }

        /// <summary>
        /// Set <see cref="Video"/>.
        /// </summary>
        /// <param name="video">The video url for the spu.</param>
        public Spu SetVideo([CanBeNull] string video)
        {
            if (video?.Length > Spu.MAX_VIDEO_LENGTH)
            {
                throw new ArgumentException($"{nameof(Spu)} {nameof(video)} can not be longer than {Spu.MAX_VIDEO_LENGTH}");
            }

            this.Video = video;
            return this;
        }

        /// <summary>
        /// Set <see cref="GuidancePrice"/>.
        /// </summary>
        /// <param name="guidancePrice">The guidance price for the spu (e.g. 199.99, 998.00, ...). Null, If not needed.</param>
        public Spu SetGuidancePrice([CanBeNull] decimal? guidancePrice)
        {
            if ((null != guidancePrice) && (guidancePrice < decimal.Zero))
            {
                throw new ArgumentException($"{nameof(Spu)} {nameof(guidancePrice)} can not be less than {decimal.Zero}");
            }

            this.GuidancePrice = guidancePrice;
            return this;
        }

        /// <summary>
        /// Set <see cref="Price"/>.
        /// </summary>
        /// <param name="price">The price for the spu (e.g. 199.99, 998.00, ...).</param>
        public Spu SetPrice([NotNull] decimal price)
        {
            Check.NotNull(price, nameof(price));
            if (price < decimal.Zero)
            {
                throw new ArgumentException($"{nameof(Spu)} {nameof(price)} can not be less than {decimal.Zero}");
            }

            this.Price = price;
            return this;
        }

        /// <summary>
        /// Set <see cref="SpuId"/>.
        /// </summary>
        /// <param name="offerPrice">The offer price for the spu (e.g. 199.99, 998.00, ...). Null, If not needed.</param>
        public Spu SetOfferPrice([CanBeNull] decimal? offerPrice)
        {
            if ((null != offerPrice) && (offerPrice < decimal.Zero))
            {
                throw new ArgumentException($"{nameof(Spu)} {nameof(offerPrice)} can not be less than {decimal.Zero}");
            }

            this.OfferPrice = offerPrice;
            return this;
        }

        /// <summary>
        /// Set <see cref="State"/>.
        /// </summary>
        /// <param name="state">The foreign key of a spu that is linked to the spu attribute value.</param>
        public Spu SetState([NotNull] State state)
        {
            this.State = Check.NotNull(state, nameof(state));
            return this;
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
