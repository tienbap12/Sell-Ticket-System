namespace ST.Application
{
    public static class Response
    {
        public static Response<T> Success<T>(T data, string message) => new Response<T>(data, message, false);
        public static Result Success(string message) => new Result(message, false);

        public static Response<T> Fail<T>(string message, T data = default) => new Response<T>(data, message, true);
        public static Result Fail(string message) => new Result(message, true);
        public static Result CreateSuccessfully(string entityName) =>
           Success($"{entityName} has been added successfully.");

        public static Result UpdateSuccessfully(string entityName) =>
            Success($"{entityName} has been edited successfully.");

        public static Result DeleteSuccessfully(string entityName) =>
            Success($"{entityName} has been deleted successfully.");

        public static Result NotFound(string entityName, int id) =>
            Fail($"{entityName} was not found with Id {id}");

        public static Result UpdateFailed(string entityName) =>
            Fail($"Failed to update {entityName}.");

        public static Result DeleteFailed(string entityName) =>
            Fail($"Failed to delete {entityName}.");

        public static Result CreateFailed(string entityName) =>
            Fail($"Failed to create {entityName}.");
    }
    public class Result
    {
        public string Message { get; set; }
        public bool Error { get; set; }

        public Result(string message, bool error)
        {
            Message = message;
            Error = error;
        }
    }
    public class Response<T>
    {
        public string Message { get; set; }
        public bool Error { get; set; }
        public T Data { get; set; }

        public Response(T data, string message, bool error)
        {
            Message = message;
            Error = error;
            Data = data;
        }
    }
}