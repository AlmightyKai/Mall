using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;

namespace Almighty.Mall.Module.Product
{
    public class AttributeValue : AuditedAggregateRoot<Guid>
    {
        #region [ Constants ]

        #endregion

        #region [ Columns ]
        /// <summary>
        /// Attribute id of this attribute value.
        /// </summary>
        [Column("AttributeId", TypeName = "uniqueidentifier")]
        [Comment("Attribute id of this attribute value.")]
        public virtual Guid? AttributeId { get; set; }

        /// <summary>
        /// Description of this attribute value.
        /// </summary>
        [Column("Value", TypeName = "nvarchar(255)")]
        [Comment("Value of this category.")]
        public virtual string Value { get; set; }
        #endregion

        #region [ Foreign ]
        /// <summary>
        /// <para>Parent <see cref="Attribute"/>.</para>
        /// </summary>
        [ForeignKey(nameof(AttributeId))]
        public virtual Attribute Attribute { get; set; }
        #endregion

        #region [ Constructor ]
        /// <summary>
        /// <para>Initializes a new instance of the <see cref="AttributeValue"/> class.</para> 
        /// <para>Default constructor is needed for ORMs.</para> 
        /// </summary>
        private AttributeValue()
        {
            /* Do nothing. */
        }

        //internal AttributeCategory(Guid id, [NotNull] string code, [NotNull] string name, float price = 0.0f, int stockCount = 0, string imageName = null)
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

        #region [ To String ]
        /// <summary>
        /// Returns a string that represents the current attribute value.
        /// </summary>
        public override string ToString() => $"{base.ToString()}";
        #endregion
    }
}
