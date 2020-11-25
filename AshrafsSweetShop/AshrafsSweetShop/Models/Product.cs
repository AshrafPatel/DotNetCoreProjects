using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AshrafsSweetShop.Models
{
  public class Product
  {
    public int ProductID { get; set; }

    [Required(ErrorMessage = "Please enter Product Name")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Please enter Product Price")]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Please select Category")]
    public int CategoryId { get; set; }
    
    public Category Category { get; set; }

    public decimal DiscountPercentage => .20M;
    public decimal DiscountAmount => Price * DiscountPercentage;
    public decimal DiscountPrice => Price - DiscountAmount;

    [Required(ErrorMessage = "Please enter Product Code")]
    public string Code { get; set; }

    public string Slug => Name?.Replace(' ', '-');
  }
}
