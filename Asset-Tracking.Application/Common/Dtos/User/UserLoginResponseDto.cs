namespace Asset_Tracking.Application.Common.Dtos.User
{
    /// <summary>
    /// Represents a Data Transfer Object containing details for an external login provider response.
    /// </summary>
    public record UserLoginResponseDto
    {
        /// <example>Google</example>
        public string LoginProvider { get; set; } = null!;

        /// <example>u_987654321</example>
        public string UserId { get; set; } = null!;

        /// <example>10928374655647382910</example>
        public string ProviderKey { get; set; } = null!;

        /// <example>Google Account</example>
        public string? ProviderDisplayName { get; set; }
    }
}