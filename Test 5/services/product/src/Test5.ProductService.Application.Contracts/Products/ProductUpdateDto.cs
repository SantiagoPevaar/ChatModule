using System.ComponentModel.DataAnnotations;

namespace Test5.ProductService.Products;

public class ProductUpdateDto
{
    [Required]
    [StringLength(ProductConsts.NameMaxLength)]
    public string Name { get; set; }

    [Required]
    public float Price { get; set; }
}
