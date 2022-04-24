using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Almighty.Mall.Module.Product.Spus
{
    /// <summary>
    /// Represents a spu extension in the product module.
    /// </summary>
    [Table("SpuExtensions")]
    [Comment("Represents a spu extension in the product module.")]
    public class SpuExtension : FullAuditedAggregateRoot<Guid>
    {
        #region [ Columns ]
        /// <summary>
        /// Gets or sets the foreign key of a spu that is linked to the spu extension.
        /// </summary>
        [NotNull]
        [Column($"{nameof(SpuId)}", TypeName = "uniqueidentifier")]
        [Comment("The foreign key of a spu that is linked to the spu extension.")]
        public virtual Guid SpuId { get; protected set; }

        /// <summary>
        /// Gets or sets the sales for the spu extension.
        /// </summary>
        [NotNull]
        [Column($"{nameof(Sales)}", TypeName = "int")]
        [Comment("The sales for the spu extension.")]
        public virtual int Sales { get; protected set; }

        /// <summary>
        /// Gets or sets the actual stock for the spu extension.
        /// </summary>
        [NotNull]
        [Column($"{nameof(ActualStock)}", TypeName = "int")]
        [Comment("The actual stock for the spu extension.")]
        public virtual int ActualStock { get; protected set; }

        /// <summary>
        /// Gets or sets the locked stock for the spu extension.
        /// </summary>
        [NotNull]
        [Column($"{nameof(LockedStock)}", TypeName = "int")]
        [Comment("The locked stock for the spu extension.")]
        public virtual int LockedStock { get; protected set; }

        /// <summary>
        /// Gets or sets the stock for the spu extension.
        /// </summary>
        [NotNull]
        [Column($"{nameof(Stock)}", TypeName = "int")]
        [Comment("The stock for the spu extension.")]
        public virtual int Stock { get; protected set; }
        #endregion

        #region [ Foreign ]
        /// <summary>
        /// The foreign key of a spu that is linked to the spu extension.
        /// </summary>
        [ForeignKey(nameof(SpuId))]
        public virtual Spu Spu { get; protected set; }
        #endregion

        #region [ Constructor ]
        /// <summary>
        /// <para>Initializes a new instance of the <see cref="SpuExtension"/> class.</para>
        /// <para>Default constructor is needed for ORMs.</para>
        /// </summary>
        protected SpuExtension()
        {
            /* Do nothing. */
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpuExtension"/> class.
        /// </summary>
        /// <param name="spu">The foreign key of a spu that is linked to the spu extension.</param>
        /// <param name="sales">The sales for the spu extension.</param>
        /// <param name="actualStock">The actual stock for the spu extension.</param>
        /// <param name="lockedStock">The locked stock for the spu extension.</param>
        /// <param name="stock">The stock for the spu extension.</param>
        public SpuExtension([NotNull] Spu spu,
                            [NotNull] int sales,
                            [NotNull] int actualStock,
                            [NotNull] int lockedStock,
                            [NotNull] int stock)
        {
            this.SetSpuId(spu);
            this.SetSales(sales);
            this.SetActualStock(actualStock);
            this.SetLockedStock(lockedStock);
            this.SetStock(stock);
        }
        #endregion

        #region [ Column Set ]
        /// <summary>
        /// Set <see cref="SpuId"/>.
        /// </summary>
        /// <param name="spu">The foreign key of a spu that is linked to the spu extension.</param>
        public SpuExtension SetSpuId([NotNull] Spu spu)
        {
            this.SpuId = Check.NotNull(spu, nameof(spu)).Id;
            return this;
        }

        /// <summary>
        /// Set <see cref="Sales"/>.
        /// </summary>
        /// <param name="attribute">The sales for the spu extension.</param>
        public SpuExtension SetSales([NotNull] int sales)
        {
            Check.NotNull(sales, nameof(sales));
            if (sales < 0)
            {
                throw new ArgumentException($"{nameof(SpuExtension)} {nameof(sales)} can not be less than 0");
            }

            this.Sales = sales;
            return this;
        }

        /// <summary>
        /// Set <see cref="ActualStock"/>.
        /// </summary>
        /// <param name="actualStock">The actual stock for the spu extension.</param>
        public SpuExtension SetActualStock([NotNull] int actualStock)
        {
            if (actualStock < 0)
            {
                throw new ArgumentException($"{nameof(SpuExtension)} {nameof(actualStock)} can not be less than 0");
            }

            this.ActualStock = actualStock;
            return this;
        }

        /// <summary>
        /// Set <see cref="LockedStock"/>.
        /// </summary>
        /// <param name="lockedStock">The locked stock for the spu extension.</param>
        public SpuExtension SetLockedStock([NotNull] int lockedStock)
        {
            if (lockedStock < 0)
            {
                throw new ArgumentException($"{nameof(SpuExtension)} {nameof(lockedStock)} can not be less than 0");
            }

            this.LockedStock = lockedStock;
            return this;
        }

        /// <summary>
        /// Set <see cref="Stock"/>.
        /// </summary>
        /// <param name="Stock">The stock for the spu extension.</param>
        public SpuExtension SetStock([NotNull] int stock)
        {
            if (stock < 0)
            {
                throw new ArgumentException($"{nameof(SpuExtension)} {nameof(stock)} can not be less than 0");
            }

            this.Stock = stock;
            return this;
        }
        #endregion

        #region [ To String ]
        /// <summary>
        /// Returns a string that represents the current spu extension.
        /// </summary>
        public override string ToString()
        {
            return $"{nameof(this.Spu)}:{((null != this.Spu) ? this.Spu.Name : this.SpuId)}" +
                   $" - " +
                   $"{nameof(this.Stock)}:{this.Stock}";
        }
        #endregion
    }
}
