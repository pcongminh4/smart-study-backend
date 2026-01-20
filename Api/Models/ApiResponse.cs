public class ApiResponse<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
    public ApiError? Error { get; set; }

    public static ApiResponse<T> Ok(T data) => new ApiResponse<T>
    {
        Success = true,
        Data = data,
        Error = null
    };

    public static ApiResponse<T> Fail(
        int code,
        string message,
        object? details = null
    ) => new()
    {
        Success = false,
        Error = new ApiError
        {
            Code = code,
            Message = message,
            Details = details
        }
    };
}

public class ApiError
{
    public int Code { get; set; }
    public string Message { get; set; } = null!;
    public object? Details { get; set; }
}