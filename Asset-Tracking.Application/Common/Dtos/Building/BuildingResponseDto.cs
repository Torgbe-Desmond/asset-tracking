namespace Asset_Tracking.Application.Common.Dtos.Building
{
    /// <summary>
    /// Represents a building within a specific site location.
    /// </summary>
    public record BuildingResponseDto
    {
        /// <example>1</example>
        public int BuildingId { get; set; }

        /// <example>Main Administration Building</example>
        public string? BuildingName { get; set; }

        /// <example>admin_user</example>
        public string CreatedBy { get; set; } = null!;

        /// <example>null</example>
        public string? UpdatedBy { get; set; }
    }
}