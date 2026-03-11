namespace Asset_Tracking.Application.Common.User
{
    public record UserRoleUpdateRequestDto
    {
        public string RoleId { get; set; } = null!;
        public string UserId { get; set; } = null!;
    }
}
