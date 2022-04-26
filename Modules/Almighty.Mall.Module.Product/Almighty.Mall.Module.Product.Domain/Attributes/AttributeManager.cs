using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Almighty.Mall.Module.Product.Attributes
{
    /// <summary>
    /// 
    /// </summary>
    public class AttributeManager : DomainService
    {
        #region [ Fields ]
        /// <summary>
        /// 
        /// </summary>
        private readonly IRepository<Attribute, Guid> _repository;
        #endregion

        #region [ Constructor ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        public AttributeManager(IRepository<Attribute, Guid> repository)
        {
            this._repository = repository;
        }
        #endregion

        #region [ Create ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="seller"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public async Task<Attribute> CreateAsync([CanBeNull] Guid?  seller,
                                                 [NotNull]   string name,
                                                 [CanBeNull] string description)
        {
            return await _repository.InsertAsync(new Attribute(seller, name, description));
        }
        #endregion
    }
}
