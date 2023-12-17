using System.ComponentModel.DataAnnotations;

namespace FormsApp.Models;

public class Product
{
    [Display(Name="Ürün Id")]
    public int ProductId { get; set; }
    
    [Display(Name="Ürün İsmi")]   
    [Required]
    public string? Name { get; set; }= string.Empty;

    [Display(Name="Ürün Fiyatı")]
    [Required]
    [Range(0,100000)]
    public decimal Price { get; set; }

    [Display(Name="Ürün Görseli")]
  
    public String Image { get; set; } = string.Empty;

    public bool IsActive { get; set; }

    [Display(Name="Ürün Kategorisi")]
    [Required]
    public int? CategoryId { get; set; }
}
