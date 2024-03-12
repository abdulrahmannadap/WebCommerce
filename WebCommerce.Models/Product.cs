using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCommerce.Models
{
    public class Product : BaseModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Fill Product Name")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Please Fill Product Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please Fill Product Price")]
        public double ProductPrice { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Please Fill Product Date")]
        public DateTime BuyingDateTime { get; set; }


        [ValidateNever]
        public Category Category { get; set; }
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

    }
}
