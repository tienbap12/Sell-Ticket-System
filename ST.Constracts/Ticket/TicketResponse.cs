namespace ST.Contracts.Ticket
{
    public class TicketResponse
    {
        public  Guid Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public  Guid CategoryId { get; set; }
        public  Guid CounterDrive { get; set; }
        public bool IsCombo { get; set; }
        public string Slug { get; set; }
        public string Resources { get; set; }
        public decimal? FinalDiscount { get; set; }
        public decimal? FinalDiscountPercent { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal FinalPrice { get; set; }
    }
}
