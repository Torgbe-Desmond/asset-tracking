namespace Asset_Tracking.Application.Common.Role
{
    /// <summary>
    /// Represents a security role within the system.
    /// </summary>
    public record RoleResponseDto
    {
        /// <example>1234-abcd-5678-efgh</example>
        public string Id { get; set; } = null!;

        /// <example>Administrator</example>
        public string? Name { get; set; }

        /// <example>ADMINISTRATOR</example>
        public string? NormalizedName { get; set; }

        /// <example>a1b2c3d4-e5f6-g7h8-i9j0</example>
        public string? ConcurrencyStamp { get; set; }
    }
}