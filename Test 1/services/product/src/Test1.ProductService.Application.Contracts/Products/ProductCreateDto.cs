using System.ComponentModel.DataAnnotations;

namespace Test1.ProductService.Products;

public class ProductCreateDto
{
    [Required]
    [StringLength(ProductConsts.NameMaxLength)]
    public string Name { get; set; }

    [Required]
    public float Price { get; set; }
}
