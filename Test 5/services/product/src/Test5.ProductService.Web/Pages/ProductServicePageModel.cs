using Test5.ProductService.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Test5.ProductService.Web.Pages;

/* Inherit your PageModel classes from this class. */
public abstract class ProductServicePageModel : AbpPageModel
{
    protected ProductServicePageModel()
    {
        LocalizationResourceType = typeof(ProductServiceResource);
        ObjectMapperContext = typeof(ProductServiceWebModule);
    }
}
