using Test3.ProductService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Test3.ProductService;

public abstract class ProductServiceController : AbpController
{
    protected ProductServiceController()
    {
        LocalizationResource = typeof(ProductServiceResource);
    }
}
