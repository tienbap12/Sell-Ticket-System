namespace ST.Constracts.Order
{
    public class OrderDetailsResponse
    {
        public Guid Id { get; set; }
        public decimal TotalAmount { get; set; }
        public string UserId { get; set; }
        public List<DetailsResponse> Details { get; set; }
    }
    public class DetailsResponse
    {
        public  Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public  Guid TicketId { get; set; }
        public  Guid Quantity { get; set; }
        public decimal Price { get; set; }
        public string TicketName { get; set; }

    }
    public class OrderResponse
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public decimal TotalAmount { get; set; }
    }
}