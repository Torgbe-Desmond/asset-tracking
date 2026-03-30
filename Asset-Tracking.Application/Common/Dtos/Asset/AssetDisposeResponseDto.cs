namespace Asset_Tracking.Application.Common.Dtos.Asset
{
    /// <summary>
    /// Represents the details of an asset disposal transaction.
    /// </summary>
    public record AssetDisposeResponseDto
    {
        /// <example>50</example>
        public int AssetDisposeId { get; set; }

        /// <example>2026-03-12T10:00:00Z</example>
        public DateTime DisposeDate { get; set; }

        /// <example>Local Recycling Center</example>
        public string DisposeTo { get; set; } = null!;

        /// <example>Unit beyond economic repair</example>
        public string? Notes { get; set; }

        /// <example>admin_user</example>
        public string CreatedBy { get; set; } = null!;

        /// <example>null</example>
        public string? UpdatedBy { get; set; }

        /// <example>501</example>
        public int AssetId { get; set; }
    }
}