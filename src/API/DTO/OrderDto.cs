using Domain.Entities;

namespace API.DTO {
    public class OrderDto {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }

    }
}
