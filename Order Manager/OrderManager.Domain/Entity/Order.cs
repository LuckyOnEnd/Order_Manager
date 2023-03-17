using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Domain.Entity
{
    public class Order
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Za krótkie imie klienta")]
        [MaxLength(25, ErrorMessage = "Za dlugie imie klienta")]
        public string? ClientName { get; set; }
        [Required]
        public decimal? OrderPrice { get; set; }
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string? AdditionalInfo { get; set; } = string.Empty;
    }
}
