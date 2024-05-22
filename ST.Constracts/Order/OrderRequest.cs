namespace ST.Constracts.Order
{
    public class OrderRequest
    {
        public int Id { get; private set; }
        public int UserId { get; set; }
        public List<OrderDetailRequest> Details { get; set; }

        /*        public OrderRequest()
                {
                    Id = Guid.NewGuid();
                }*/
    }

    public class OrderDetailRequest
    {
        public int TicketId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}