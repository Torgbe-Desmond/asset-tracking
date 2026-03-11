namespace Asset_Tracking_Api.Dtos
{
    public class ErrorResponseDto
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public 
        ErrorResponseDto(string message, int statusCode)
        {
            this.Message = message;
            this.StatusCode = statusCode;
        }
    }
}
