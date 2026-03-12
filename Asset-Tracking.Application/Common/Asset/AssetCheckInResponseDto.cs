namespace Asset_Tracking.Application.Common.Asset
{
    /// <summary>
    /// Represents the details of an asset check-in transaction.
    /// </summary>
    public record AssetCheckInResponseDto
    {
        /// <example>10</example>
        public int AssetCheckInId { get; set; }

        /// <example>2026-03-12T14:30:00Z</example>
        public DateTime ReturnDate { get; set; }

        /// <example>Returned in good working condition</example>
        public string? Notes { get; set; }

        /// <example>John Doe</example>
        public string ReturnedBy { get; set; } = null!;

        /// <example>STF-9982</example>
        public string? StaffId { get; set; }

        /// <example>admin_user</example>
        public string CreatedBy { get; set; } = null!;

        /// <example>null</example>
        public string? UpdatedBy { get; set; }

        /// <example>501</example>
        public int AssetId { get; set; }

        /// <example>2</example>
        public int? SiteId { get; set; }
    }
}