namespace Asset_Tracking.Application.Common.Dtos.Asset
{
    /// <summary>
    /// Represents the details of an asset check-out transaction.
    /// </summary>
    public record AssetCheckOutResponseDto
    {
        /// <example>101</example>
        public int AssetCheckOutId { get; set; }

        /// <example>2026-03-12T09:00:00Z</example>
        public DateTime AssetCheckOutDate { get; set; }

        /// <example>2026-03-20T17:00:00Z</example>
        public DateTime? DueDate { get; set; }

        /// <example>Equipment assigned for site project</example>
        public string? Notes { get; set; }

        /// <example>admin_user</example>
        public string CreatedBy { get; set; } = null!;

        /// <example>null</example>
        public string? UpdatedBy { get; set; }

        /// <example>501</example>
        public int AssetId { get; set; }

        /// <example>STF-9982</example>
        public string? StaffId { get; set; }

        /// <example>John Doe</example>
        public string? AssignedTo { get; set; }

        /// <example>2</example>
        public int? SiteId { get; set; }

        /// <example>1</example>
        public int BuildingId { get; set; }

        /// <example>3</example>
        public int FloorId { get; set; }

        /// <example>12</example>
        public int RoomId { get; set; }

        /// <example>Near the south entrance</example>
        public string? RoomLocationDescription { get; set; }

        /// <example>true</example>
        public bool IsConfirmedEmailSent { get; set; }

        /// <example>2026-03-12T09:05:00Z</example>
        public DateTime? EmailSentDate { get; set; }

        /// <example>false</example>
        public bool HasReceivedConfirmed { get; set; }

        /// <example>null</example>
        public DateTime? HasReceivedConfirmedDate { get; set; }

        /// <example>true</example>
        public bool IsSMSSent { get; set; }

        /// <example>2026-03-12T09:05:30Z</example>
        public DateTime? SMSSentDate { get; set; }
    }
}