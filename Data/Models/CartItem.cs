namespace apshop.Data.Models
{
    public class CartItem
    {
        
        public int cartItemId { get; set; }
        public int cartId { get; set; }
        public int itemId { get; set; }
        public int quantity { get; set; }
        public int itemCode { get; set; }
        public virtual Cart cart { get; set; }
        public virtual Item item { get; set; }

        public CartItem(int itemId, int itemCode, int quantity)
        {
            this.itemId = itemId;
            this.itemCode = itemCode;
            this.quantity = quantity;
        }
    }
}