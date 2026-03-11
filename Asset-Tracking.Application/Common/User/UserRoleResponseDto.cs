namespace Asset_Tracking.Application.Common.User
{
    public record UserRoleResponseDto
    {
        public string RoleId { get; set; } = null!;
        public string UserId { get; set; } = null!;
    }
}
