using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Almighty.Mall.Module.Product.Attributes
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize(Permissions.Permissions.Attributes.Default)]
    public class AttributeAppService : ApplicationService, IAttributeAppService
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
        public AttributeAppService(IRepository<Attribute, Guid> repository)
        {
            this._repository = repository;
        }
        #endregion

        #region [ Get ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        public async Task<PagedResultDto<AttributeDto>> GetListPagedAsync(PagedAndSortedResultRequestDto input)
        {
            await this.NormalizeMaxResultCountAsync(input);

            List<Attribute>    attributes = await this._repository.GetPagedListAsync(input.SkipCount, input.MaxResultCount, input.Sorting);
            long               totalCount = await _repository.GetCountAsync();
            List<AttributeDto> dtos       = ObjectMapper.Map<List<Attribute>, List<AttributeDto>>(attributes);

            return new PagedResultDto<AttributeDto>(totalCount, dtos);
        }

        /// <summary>
        /// 
        /// </summary>
        public Task<ListResultDto<AttributeDto>> GetListAsync()
        {
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public Task<AttributeDto> GetAsync(Guid id)
        {
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        private async Task NormalizeMaxResultCountAsync(PagedAndSortedResultRequestDto input)
        {
            var maxPageSize = (await this.SettingProvider.GetOrNullAsync(Settings.Settings.Attributes.MaxPageSize))?.To<int>();
            if (maxPageSize.HasValue && (input.MaxResultCount > maxPageSize.Value))
            {
                input.MaxResultCount = maxPageSize.Value;
            }
        }
        #endregion

        #region [ Create ]
        /// <summary>
        /// 
        /// </summary>
        public Task<AttributeDto> CreateAsync(CreateAttributeDto input)
        {
            return null;
        }
        #endregion

        #region [ Update ]
        /// <summary>
        /// 
        /// </summary>
        public Task<AttributeDto> UpdateAsync(Guid id, UpdateAttributeDto input)
        {
            return null;
        }
        #endregion

        #region [ Delete ]
        /// <summary>
        /// 
        /// </summary>
        public Task DeleteAsync(Guid id)
        {
            return null;
        }
        #endregion
    }
}
