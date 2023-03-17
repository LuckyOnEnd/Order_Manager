using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Domain.Entity
{
    public class OrderLine
    {
        [Required]
        public int Id { get; set; }
        public int OrderID { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Za krótkia nazwa produktu")]
        [MaxLength(25, ErrorMessage = "Za dlugia nazwa produltu")]
        public string? Product { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
