using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Almighty.Mall.Module.Product.Brands
{
    /// <summary>
    /// Represents a brand for product.
    /// </summary>
    [Table("Brands")]
    [Comment("Represents a brand for product.")]
    public class Brand : FullAuditedAggregateRoot<Guid>
    {
        #region [ Constants ]
        /// <summary>
        /// Maximum length of the <see cref="DisplayName"/> property.
        /// </summary>
        private const int MaxDisplayNameLength = 128;
        #endregion

        #region [ Columns ]
        /// <summary>
        /// Display name of this brand.
        /// </summary>
        [Required]
        [Column("DisplayName", TypeName = "nvarchar")]
        [Comment("Display name of this category.")]
        [StringLength(MaxDisplayNameLength)]
        public virtual string DisplayName { get; set; }

        // Logo

        // Image

        // BigImage



        // Sort

        // Story

        // 

        // IsDisabled
        #endregion

        #region [ Foreign ]

        #endregion

        #region [ Constructor ]

        #endregion

        #region [ To String ]
        /// <summary>
        /// Returns a string that represents the current attribute.
        /// </summary>
        public override string ToString() => $"{this.Id} --> {this.DisplayName}";
        #endregion
    }
}
