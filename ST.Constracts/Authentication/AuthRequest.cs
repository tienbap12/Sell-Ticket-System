namespace ST.Contracts.Authentication
{
    public class AuthRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string? FullName { get; set; }
        public DateTime? DoB { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public  Guid RoleId { get; set; }
    }
}
