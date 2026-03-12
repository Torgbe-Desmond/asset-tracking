using Asset_Tracking.Application.Common.Site;
using Asset_Tracking.Application.Common.Staff;

namespace Asset_Tracking.Application.Common.Asset
{
    /// <summary>
    /// Detailed view of an asset check-in including related entity information.
    /// </summary>
    public record AssetCheckInDetailsResponseDto
    {
        /// <example>10</example>
        public int AssetCheckInId { get; set; }

        /// <example>2026-03-12T14:30:00Z</example>
        public DateTime ReturnDate { get; set; }

        /// <example>Equipment returned after project completion</example>
        public string? Notes { get; set; }

        /// <example>admin_user</example>
        public string ReturnedBy { get; set; } = null!;

        /// <example>STF-9982</example>
        public string? StaffId { get; set; }

        /// <example>2026-03-10T09:00:00Z</example>
        public DateTime DateCreated { get; set; }

        /// <example>system_admin</example>
        public string CreatedBy { get; set; } = null!;

        /// <example>null</example>
        public DateTime? DateUpdated { get; set; }

        /// <example>null</example>
        public string? UpdatedBy { get; set; }

        /// <example>501</example>
        public int AssetId { get; set; }

        /// <example>2</example>
        public int? SiteId { get; set; }

        public AssetDto Asset { get; set; } = null!;

        public SiteResponseDto Site { get; set; } = null!;

        public StaffResponseDto Staff { get; set; } = null!;
    }
}