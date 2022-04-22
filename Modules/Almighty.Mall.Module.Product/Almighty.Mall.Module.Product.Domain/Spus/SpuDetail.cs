using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Almighty.Mall.Module.Product.Spus
{
    /// <summary>
    /// Represents a spu details in the product module.
    /// </summary>
    [Table("SpuDetails")]
    [Comment("Represents a spu details in the product module.")]
    public class SpuDetail : AuditedAggregateRoot
    {
        #region [ Columns ]
        /// <summary>
        /// Gets or sets the foreign key of a spu that is linked to the spu detail.
        /// </summary>
        [Key]
        [Required]
        [Column($"{nameof(SpuId)}", TypeName = "uniqueidentifier")]
        [Comment("The foreign key of a spu that is linked to the spu detail.")]
        public virtual Guid SpuId { get; set; }

        /// <summary>
        /// Gets or sets the detail for the spu detail.
        /// </summary>
        [Column($"{nameof(Detail)}", TypeName = "ntext")]
        [Comment("The detail for the spu detail.")]
        public virtual string Detail { get; set; }
        #endregion

        #region [ Foreign ]
        /// <summary>
        /// Gets or sets the foreign key of a spu that is linked to the spu detail.
        /// </summary>
        [ForeignKey(nameof(SpuId))]
        public virtual Spu Spu { get; set; }
        #endregion

        #region [ Constructor ]
        /// <summary>
        /// <para>Initializes a new instance of the <see cref="SpuDetail"/> class.</para>
        /// <para>Default constructor is needed for ORMs.</para>
        /// </summary>
        protected SpuDetail()
        {
            /* Do nothing. */
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpuDetail"/> class.
        /// </summary>
        /// <param name="spu">The foreign key of a spu that is linked to the spu detail.</param>
        /// <param name="detail">The detail for the spu detail.</param>
        public SpuDetail([NotNull]   Spu    spu,
                         [CanBeNull] string detail)
        {
            Check.NotNull(spu, nameof(spu));

            this.SpuId  = spu.Id;
            this.Detail = detail;
        }
        #endregion

        #region [ Get Keys ]
        /// <summary>
        /// 
        /// </summary>
        public override object[] GetKeys()
        {
            return new object[] { SpuId };
        }
        #endregion

        #region [ To String ]
        /// <summary>
        /// Returns a string that represents the current attribute value.
        /// </summary>
        public override string ToString()
        {
            return $"{nameof(this.Spu)}:{((null != this.Spu) ? this.Spu.Name : this.SpuId)}" +
                   $" - " +
                   $"{nameof(this.Detail)}:{this.Detail}";
        }
        #endregion
    }
}
