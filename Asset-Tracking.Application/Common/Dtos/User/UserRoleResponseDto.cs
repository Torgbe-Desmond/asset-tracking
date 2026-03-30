namespace Asset_Tracking.Application.Common.Dtos.User
{
    public record UserRoleResponseDto
    {
        public string RoleId { get; set; } = null!;
        public string UserId { get; set; } = null!;
    }
}
