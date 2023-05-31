using Test_2.ProductService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Test_2.ProductService;

public abstract class ProductServiceController : AbpController
{
    protected ProductServiceController()
    {
        LocalizationResource = typeof(ProductServiceResource);
    }
}
