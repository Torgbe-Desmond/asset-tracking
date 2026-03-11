namespace Asset_Tracking_Api.Common.Models
{
    public class ApiResponse<T>
    {
        public T? Data { get; set; }
        public string Message { get; set; } = "Success";
        public int StatusCode { get; set; }
        public bool Success => StatusCode >= 200 && StatusCode < 300;
    }
}
