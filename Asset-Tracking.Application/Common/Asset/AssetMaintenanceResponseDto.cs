namespace Asset_Tracking.Application.Common.Asset
{
    /// <summary>
    /// Represents the details of an asset maintenance record.
    /// </summary>
    public record AssetMaintenanceResponseDto
    {
        /// <example>201</example>
        public int AssetMaintenanceId { get; set; }

        /// <example>Annual Calibration</example>
        public string MaintenanceTitle { get; set; } = null!;

        /// <example>Full system recalibration and sensor cleaning.</example>
        public string Details { get; set; } = null!;

        /// <example>2026-03-01T08:00:00Z</example>
        public DateTime DateSent { get; set; }

        /// <example>Technician A</example>
        public string MaintainedBy { get; set; } = null!;

        /// <example>2026-03-10T15:30:00Z</example>
        public DateTime? DateCompleted { get; set; }

        /// <example>150.50</example>
        public decimal? Cost { get; set; }

        /// <example>admin_user</example>
        public string CreatedBy { get; set; } = null!;

        /// <example>null</example>
        public string? UpdatedBy { get; set; }

        /// <example>1</example>
        public int MaintenanceStatusId { get; set; }

        /// <example>501</example>
        public int AssetId { get; set; }

        // Swagger will pull the <example> tags from these respective DTOs
        public AssetDto Asset { get; set; } = null!;
        public MaintenanceStatusResponseDto MaintenanceStatus { get; set; } = null!;
    }
}