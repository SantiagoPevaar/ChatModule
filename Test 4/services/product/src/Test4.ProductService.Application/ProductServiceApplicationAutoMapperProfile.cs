using AutoMapper;
using Test4.ProductService.Products;

namespace Test4.ProductService;

public class ProductServiceApplicationAutoMapperProfile : Profile
{
    public ProductServiceApplicationAutoMapperProfile()
    {
        CreateMap<Product, ProductDto>();
    }
}
