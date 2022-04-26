using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Almighty.Mall.Module.Product.Attributes
{
    public interface IAttributeAppService : IApplicationService
    {
        /// <summary>
        /// 
        /// </summary>
        Task<PagedResultDto<AttributeDto>> GetListPagedAsync(PagedAndSortedResultRequestDto input);

        /// <summary>
        /// 
        /// </summary>
        Task<ListResultDto<AttributeDto>> GetListAsync();

        /// <summary>
        /// 
        /// </summary>
        Task<AttributeDto> GetAsync(Guid id);

        /// <summary>
        /// 
        /// </summary>
        Task<AttributeDto> CreateAsync(CreateAttributeDto input);

        /// <summary>
        /// 
        /// </summary>
        Task<AttributeDto> UpdateAsync(Guid id, UpdateAttributeDto input);

        /// <summary>
        /// 
        /// </summary>
        Task DeleteAsync(Guid id);
    }
}
