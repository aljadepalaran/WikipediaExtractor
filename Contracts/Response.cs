namespace WikipediaExtractor.Contracts;

public class Response<T>
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }

    public Response(bool success, string message, T? data = default)
    {
        Success = success;
        Message = message;
        Data = data;
    }

    public static Response<T> SuccessResponse(T data, string message = "Operation successful")
    {
        return new Response<T>(true, message, data);
    }

    public static Response<T> FailureResponse(string message, T? data = default)
    {
        return new Response<T>(false, message, data);
    }
}