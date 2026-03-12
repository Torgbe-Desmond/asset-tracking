namespace Asset_Tracking.Application.Common.Asset
{
    /// <summary>
    /// Represents a historical record of changes made to an asset.
    /// </summary>
    public record AssetEventHistoryResponseDto
    {
        /// <example>hist-5501-abc-99</example>
        public string AssetEventHistoryId { get; set; } = null!;

        /// <example>2026-03-12T11:00:00Z</example>
        public DateTime Date { get; set; }

        /// <example>Status Update</example>
        public string Event { get; set; } = null!;

        /// <example>In Storage</example>
        public string StatusChangedFrom { get; set; } = null!;

        /// <example>Checked Out</example>
        public string StatusChangeTo { get; set; } = null!;

        /// <example>Warehouse A</example>
        public string? LocationChangedFrom { get; set; }

        /// <example>Site 2 - Room 101</example>
        public string? LocationChangedTo { get; set; }

        /// <example>Main Headquarters</example>
        public string? SiteChangedFrom { get; set; }

        /// <example>North Regional Office</example>
        public string? SiteChangedTo { get; set; }

        /// <example>Unassigned</example>
        public string? AssignedFrom { get; set; }

        /// <example>John Doe</example>
        public string? AssignedTo { get; set; }

        /// <example>501</example>
        public int AssetId { get; set; }
    }
}