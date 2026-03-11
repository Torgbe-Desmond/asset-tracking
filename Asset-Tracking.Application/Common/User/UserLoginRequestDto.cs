namespace Asset_Tracking.Application.Common.User
{
    public record UserLoginRequestDto
    {
        public string LoginProvider { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string ProviderKey { get; set; } = null!;
        public string? ProviderDisplayName { get; set; }
    }
}
