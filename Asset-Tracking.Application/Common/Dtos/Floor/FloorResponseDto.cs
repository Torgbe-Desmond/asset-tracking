namespace Asset_Tracking.Application.Common.Dtos.Floor
{
    /// <summary>
    /// Represents a specific floor within a building.
    /// </summary>
    public record FloorResponseDto
    {
        /// <example>3</example>
        public int FloorId { get; set; }

        /// <example>Third Floor</example>
        public string FloorName { get; set; } = null!;

        /// <example>admin_user</example>
        public string CreatedBy { get; set; } = null!;

        /// <example>null</example>
        public string? UpdatedBy { get; set; }
    }
}