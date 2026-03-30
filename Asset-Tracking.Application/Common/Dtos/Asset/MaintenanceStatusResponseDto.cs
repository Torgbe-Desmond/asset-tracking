namespace Asset_Tracking.Application.Common.Dtos.Asset
{
    /// <summary>
    /// Represents a possible status for an asset maintenance record.
    /// </summary>
    public record MaintenanceStatusResponseDto
    {
        /// <example>1</example>
        public int MaintenanceStatusId { get; set; }

        /// <example>In Progress</example>
        public string StatusName { get; set; } = null!;

        /// <example>system_admin</example>
        public string CreatedBy { get; set; } = null!;

        /// <example>null</example>
        public string? UpdatedBy { get; set; }
    }
}