namespace Asset_Tracking.Application.Common.Dtos.Asset
{
    /// <summary>
    /// Request DTO for recording asset check-in (return) data.
    /// </summary>
    public record AssetCheckInRequestDto
    {
        /// <example>2026-03-20T14:30:00</example>
        public DateTime ReturnDate { get; set; }

        /// <example>Returned in good condition, minor scratch on left side.</example>
        public string? Notes { get; set; }

        /// <example>john.doe</example>
        public string ReturnedBy { get; set; } = null!;

        /// <example>EMP-00123</example>
        public string? StaffId { get; set; }

        /// <example>2026-03-15T09:45:00</example>
        public DateTime DateCreated { get; set; }

        /// <example>asset_admin</example>
        public string CreatedBy { get; set; } = null!;

        /// <example>2026-03-16T11:20:00</example>
        public DateTime? DateUpdated { get; set; }

        /// <example>asset_manager</example>
        public string? UpdatedBy { get; set; }

        /// <example>42</example>
        public int AssetId { get; set; }

        /// <example>2</example>
        public int? SiteId { get; set; }
    }
}