namespace ST.Contracts.Ticket
{
    public class TicketRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public  Guid CategoryId { get; set; }
        public  Guid CounterDrive { get; set; }
        public bool IsCombo { get; set; }
        public string? Slug { get; set; }
        public string? Resources { get; set; }
        public decimal? FinalDiscount { get; set; }
        public decimal? FinalDiscountPercent { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal FinalPrice { get; set; }
    }
}
