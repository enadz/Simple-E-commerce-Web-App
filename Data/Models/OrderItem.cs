namespace apshop.Data.Models
{
    public class OrderItem
    {
        public int orderItemId { get; set; }
        public int orderId { get; set; }
        public int quantity;
        public virtual Order order { get; set; }
        public virtual Item item { get; set; }

    }
}