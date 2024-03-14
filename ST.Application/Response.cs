namespace ST.Application
{
    public class Response
    {
        public static Response<T> Success<T>(T data, string message) =>
            new Response<T>(data, message, false);
        public static Result Success(string message) =>
           new Result(message, false);

        public static Response<T> Fail<T>(string message, T data = default) =>
            new Response<T>(data, message, true);
        public static Result Fail(string message) =>
            new Result(message, true);

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