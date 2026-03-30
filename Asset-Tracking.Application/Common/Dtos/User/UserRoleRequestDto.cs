namespace Asset_Tracking.Application.Common.Dtos.User
{
    public record UserRoleRequestDto
    {
        public string RoleId { get; set; } = null!;
        public string UserId { get; set; } = null!;
    }
}
