using Volo.Abp.Application.Dtos;

namespace Almighty.Mall.Module.Product.Attributes
{
    public class AttributeDto : AuditedEntityDto<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid? SellerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
    }
}
