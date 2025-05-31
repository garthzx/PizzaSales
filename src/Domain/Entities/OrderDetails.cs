using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities {
    public class OrderDetails {
        [Key]
        public int Id { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        [Required]
        public int OrderId { get; set; }
        [ForeignKey("PizzaId")]
        public Pizza Pizza { get; set; }
        [Required]
        public string PizzaId { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
