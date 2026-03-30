namespace Asset_Tracking.Application.Common.Dtos.RefreshToken
{
    public record RefreshTokenRequestDto
    {
        public string? UserId { get; set; }
        public string? GeneratedRefreshToken { get; set; }
    }
}
