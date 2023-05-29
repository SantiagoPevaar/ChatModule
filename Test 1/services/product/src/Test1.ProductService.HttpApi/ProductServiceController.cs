using Test1.ProductService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Test1.ProductService;

public abstract class ProductServiceController : AbpController
{
    protected ProductServiceController()
    {
        LocalizationResource = typeof(ProductServiceResource);
    }
}
