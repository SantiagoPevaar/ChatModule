using Test5.ProductService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Test5.ProductService;

public abstract class ProductServiceController : AbpController
{
    protected ProductServiceController()
    {
        LocalizationResource = typeof(ProductServiceResource);
    }
}
