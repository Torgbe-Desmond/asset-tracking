namespace Asset_Tracking.Application.Common.Asset
{
    /// <summary>
    /// Represents a possible status for an asset repair record.
    /// </summary>
    public record RepairStatusResponseDto
    {
        /// <example>2</example>
        public int RepairStatusId { get; set; }

        /// <example>In Repair</example>
        public string RepairStatusName { get; set; } = null!;
    }
}