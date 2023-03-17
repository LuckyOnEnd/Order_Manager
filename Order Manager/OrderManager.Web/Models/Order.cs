using System.ComponentModel.DataAnnotations;

namespace OrderManager.Web.Models
{
    public class Order
    {
        [Required]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string Status { get; set; }
        public decimal? OrderPrice { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Za krótkie imie klienta")]
        [MaxLength(25, ErrorMessage = "Za dlugie imie klienta")]
        public string? ClientName { get; set; }
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string? AdditionalInfo { get; set; } = "brak";
    }
}
