namespace Asset_Tracking.Application.Common.Dtos.Asset
{
    /// <summary>
    /// Represents the scheduled repair information for an asset.
    /// </summary>
    public record ScheduleRepairResponseDto
    {
        /// <example>sch-9982-xyz</example>
        public string ScheduleRepairId { get; set; } = null!;

        /// <example>Routine Quarterly Maintenance</example>
        public string RepairTitle { get; set; } = null!;

        /// <example>Preventative maintenance on hydraulic sensors.</example>
        public string Details { get; set; } = null!;

        /// <example>TechFix Solutions</example>
        public string? RepairerName { get; set; }

        /// <example>+1-555-0199</example>
        public string? RepairerContactNumber { get; set; }

        /// <example>250.00</example>
        public decimal? Cost { get; set; }

        /// <example>2026-03-20</example>
        public string? DateCompleted { get; set; }

        /// <example>1</example>
        public int RepairStatusId { get; set; }

        /// <example>501</example>
        public int AssetId { get; set; }

        /// <summary>
        /// Approval status: 0 = Pending, 1 = Approved, 2 = Rejected.
        /// </summary>
        /// <example>1</example>
        public int IsScheduleApproved { get; set; }

        /// <example>admin_user</example>
        public string CreatedBy { get; set; } = null!;

        /// <example>null</example>
        public string? UpdateBy { get; set; }
    }
}