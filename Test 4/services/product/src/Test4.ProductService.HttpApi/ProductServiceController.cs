using Test4.ProductService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Test4.ProductService;

public abstract class ProductServiceController : AbpController
{
    protected ProductServiceController()
    {
        LocalizationResource = typeof(ProductServiceResource);
    }
}
