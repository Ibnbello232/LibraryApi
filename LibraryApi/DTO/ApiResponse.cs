namespace LibraryApi.DTO
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }

        public ApiResponse(bool success, string message, T? data = default)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public static ApiResponse<T> SuccessResponse(T data, string message = "Request successful")
            => new ApiResponse<T>(true, message, data);

        public static ApiResponse<T> FailResponse(string message)
            => new ApiResponse<T>(false, message);
    }
}
