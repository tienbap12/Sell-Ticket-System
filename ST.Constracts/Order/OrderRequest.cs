namespace ST.Constracts.Order
{
    public class OrderRequest
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; set; }
        public List<OrderDetailRequest> Details { get; set; }

        /*        public OrderRequest()
                {
                    Id = Guid.NewGuid();
                }*/
    }

    public class OrderDetailRequest
    {
        public Guid TicketId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}