using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Almighty.Mall.Module.Product.ShoppingCarts
{
    /// <summary>
    /// Represents a shopping cart in the product module.
    /// </summary>
    [Table("ShoppingCarts")]
    [Comment("Represents a shopping cart in the product module.")]
    public class ShoppingCart : AuditedAggregateRoot<Guid>
    {
        #region [ Constants ]

        #endregion
        
        #region [ Columns ]

        #endregion

        #region [ Constructor ]

        #endregion

        #region [ To String ]
        /// <summary>
        /// Returns a string that represents the shopping cart.
        /// </summary>
        public override string ToString()
        {
            return $"";
        }
        #endregion
    }
}
