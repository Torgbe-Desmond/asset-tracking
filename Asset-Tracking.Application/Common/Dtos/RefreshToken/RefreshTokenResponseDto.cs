namespace Asset_Tracking.Application.Common.Dtos.RefreshToken
{
    public record RefreshTokenResponseDto
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? GeneratedRefreshToken { get; set; }
    }
}
