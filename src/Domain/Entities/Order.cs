using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities {
    public class Order {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public TimeSpan OrderTime { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
        [NotMapped]
        public DateTime OrderDateTime => OrderDate + OrderTime;
    }
}
