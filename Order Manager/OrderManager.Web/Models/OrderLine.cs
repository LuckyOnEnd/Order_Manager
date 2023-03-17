using System.ComponentModel.DataAnnotations;

namespace OrderManager.Web.Models
{
    public class OrderLine
    {
        public int Id { get; set; }
        public int OrderID { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Za krótkia nazwa produktu")]
        [MaxLength(25, ErrorMessage = "Za dlugia nazwa produltu")]
        public string? Product { get; set; }
        [Required(ErrorMessage = "Wpisz cene produktu")]
        public decimal Price { get; set; }
    }
}
