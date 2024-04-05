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
        public int TicketId { get; set; }
        public string TicketName { get; set; }
        public decimal TicketPrice { get; set; }
        public int TicketQuantity { get; set; }

    }
    public class OrderResponse
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public decimal TotalAmount { get; set; }
    }
}