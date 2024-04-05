namespace ST.Constracts.Order
{
    public class OrderRequest
    {
        public int UserId { get; set; }
        public List<OrderDetailRequest> Details { get; set; }
    }
    public class OrderDetailRequest
    {
        public int TicketId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

}