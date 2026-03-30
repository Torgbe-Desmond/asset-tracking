namespace Asset_Tracking.Application.Common.Dtos.User
{
    public record UserClaimsRequestDto
    {
        public string UserId { get; set; } = null!;
        public string? ClaimType { get; set; }
        public string? ClaimValue { get; set; }
    }
}
