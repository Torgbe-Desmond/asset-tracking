namespace Asset_Tracking.Application.Common.Dtos.Role
{

    public record AssignRoleDto
    {
        public string Email { get; init; } = null!;
        public string Role { get; init; } = null!;
    };
}
