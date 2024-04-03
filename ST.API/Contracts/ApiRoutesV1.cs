namespace ST.API.Contracts
{
    public static class ApiRoutesV1
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/";

        public static class Ticket
        {
            public const string GetAll = Base + "Tickets";
            public const string GetById = GetAll + "/ticketId";
            public const string Create = Base + "Ticket";
            public const string Update = GetAll + "/ticketId";
            public const string Delete = GetAll + "/ticketId";
        }
        public static class Category
        {
            public const string GetAll = Base + "Category";
            public const string GetById = GetAll + "/categoryId";
            public const string Create = Base + "Category";
            public const string Update = Base + "Category";
            public const string Delete = Base + "Category";
        }
        public static class Account
        {
            public const string Login = Base + "Login";
            public const string Register = Base + "Register";
        }
    }
}
