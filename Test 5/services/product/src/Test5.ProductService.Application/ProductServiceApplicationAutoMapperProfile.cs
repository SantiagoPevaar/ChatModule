using AutoMapper;
using Test5.ProductService.Products;

namespace Test5.ProductService;

public class ProductServiceApplicationAutoMapperProfile : Profile
{
    public ProductServiceApplicationAutoMapperProfile()
    {
        CreateMap<Product, ProductDto>();
    }
}
