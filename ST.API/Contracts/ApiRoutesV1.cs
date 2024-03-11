namespace SchoolManagementSystem.API.Contracts
{
    public static class ApiRoutesV1
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/";

        public static class Ticket
        {
            public const string GetAll = Base + "Tickets";
            public const string GetById = GetAll + "/{ticketId}";
            public const string Create = Base + "Ticket";
            public const string Update = GetAll + "/{ticketId}";
            public const string Delete = GetAll + "/{ticketId}";
        }
    }
}