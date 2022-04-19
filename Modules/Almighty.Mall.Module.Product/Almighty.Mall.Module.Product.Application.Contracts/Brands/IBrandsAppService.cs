using Volo.Abp.Application.Services;

namespace Almighty.Mall.Module.Product.Brands
{
    public interface IBrandsAppService : IApplicationService
    {
        Task<BrandDto> GetAsync();

        Task<BrandDto> GetAllAsync();
        
        Task<BrandDto> CreateAsync();

        Task<BrandDto> UpdateAsync();

        Task<BrandDto> DeleteAsync();

        Task<BrandDto> MoveAsync();
    }
}
