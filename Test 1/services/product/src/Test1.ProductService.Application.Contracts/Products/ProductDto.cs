using System;
using Volo.Abp.Application.Dtos;

namespace Test1.ProductService.Products;

public class ProductDto : FullAuditedEntityDto<Guid>
{
    public string Name { get; set; }

    public float Price { get; set; }
}
