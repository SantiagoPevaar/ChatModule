using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Test5.ProductService.Products;

public interface IProductAppService : ICrudAppService<ProductDto, Guid, GetProductsInput, ProductCreateDto, ProductUpdateDto>
{

}
