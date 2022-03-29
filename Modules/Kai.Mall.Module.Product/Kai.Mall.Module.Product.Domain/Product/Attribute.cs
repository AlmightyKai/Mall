using System;
using System.Collections.Generic;
using System.Text;

namespace Kai.Mall.Module.Product
{
    public class Attribute
    {
        #region [ Columns ]

        #endregion

        #region [ Foreign ]

        #endregion

        #region [ Constructor ]
        /// <summary>
        /// <para>Initializes a new instance of the <see cref="Attribute"/> class.</para> 
        /// <para>Default constructor is needed for ORMs.</para> 
        /// </summary>
        private Attribute()
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

        #region [ To String ]
        /// <summary>
        /// Returns a string that represents the current attribute.
        /// </summary>
        /// <returns>
        /// A string that represents the current attribute.
        /// </returns>
        public override string ToString()
        {
            return base.ToString();
        }
        #endregion
    }
}
