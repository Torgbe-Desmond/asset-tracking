namespace Asset_Tracking.Application.Common.Dtos.User
{
    public class UserLoginUpdateRequestDto
    {
        public string LoginProvider { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string ProviderKey { get; set; } = null!;
        public string? ProviderDisplayName { get; set; }
    }
}
