namespace Asset_Tracking.Application.Common.User
{
    public record UserClaimsResponseDto
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public string? ClaimType { get; set; }
        public string? ClaimValue { get; set; }
    }
}
