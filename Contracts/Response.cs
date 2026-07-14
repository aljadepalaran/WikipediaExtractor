namespace WikipediaExtractor.Contracts;

public class Response<T>
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }
    public int StatusCode { get; set; } = 200;

    public Response(bool success, string message, T? data = default, int statusCode = 200)
    {
        Success = success;
        Message = message;
        StatusCode = statusCode;
        Data = data;
    }

    public static Response<T> SuccessResponse(T data, string message = "Operation successful", int statusCode = 200)
    {
        return new Response<T>(true, message, data, statusCode);
    }

    public static Response<T> FailureResponse(T? data, string message = "Operation failed", int statusCode = 400)
    {
        return new Response<T>(false, message, data, statusCode);
    }
}