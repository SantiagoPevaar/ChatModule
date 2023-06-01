using System.ComponentModel.DataAnnotations;

namespace Test3.ProductService.Products;

public class ProductUpdateDto
{
    [Required]
    [StringLength(ProductConsts.NameMaxLength)]
    public string Name { get; set; }

    [Required]
    public float Price { get; set; }
}
