namespace Asset_Tracking.Application.Common.Dtos.Asset
{
    /// <summary>
    /// Represents the full details of an asset repair record.
    /// </summary>
    public record AssetRepairDetailResponseDto
    {
        /// <example>301</example>
        public int AssetRepairId { get; init; }

        /// <example>Screen Replacement</example>
        public string RepairTitle { get; init; } = null!;

        /// <example>Replaced shattered digitizer and recalibrated touch sensors.</example>
        public string Details { get; init; } = null!;

        /// <example>TechFix Solutions</example>
        public string? RepairerName { get; init; }

        /// <example>+1-555-0199</example>
        public string? RepairerContactNumber { get; init; }

        /// <example>275.00</example>
        public decimal? Cost { get; init; }

        /// <example>2026-03-10</example>
        public string? DateCompleted { get; init; }

        /// <example>admin_user</example>
        public string CreatedBy { get; init; } = null!;

        /// <example>null</example>
        public string? UpdateBy { get; init; }

        /// <example>2</example>
        public int RepairStatusId { get; init; }

        /// <example>501</example>
        public int AssetId { get; init; }

        /// <example>2026-03-12T09:00:00Z</example>
        public DateTime? AssetReceiveDate { get; init; }

        /// <example>Inventory Manager</example>
        public string? ReceivedBy { get; init; }

        public AssetDto Asset { get; init; } = null!;

        public RepairStatusResponseDto RepairStatus { get; init; } = null!;
    }
}