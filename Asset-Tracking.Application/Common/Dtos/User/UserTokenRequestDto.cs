namespace Asset_Tracking.Application.Common.Dtos.User
{
    public record UserTokenRequestDto
    {
        public string LoginProvider { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Value { get; set; }
    }
}
