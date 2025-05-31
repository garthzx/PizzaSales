using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities {
    public class Pizza {
        [Key]
        public string Id { get; set; }
        [ForeignKey("PizzaTypeId")]
        public PizzaType PizzaType { get; set; }
        public string PizzaTypeId { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        public Decimal Price { get; set; }
    }
}
