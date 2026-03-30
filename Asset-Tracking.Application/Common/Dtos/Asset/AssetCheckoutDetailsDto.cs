using Asset_Tracking.Application.Common.Dtos.Building;
using Asset_Tracking.Application.Common.Dtos.Floor;
using Asset_Tracking.Application.Common.Dtos.Room;
using Asset_Tracking.Application.Common.Dtos.Site;
using Asset_Tracking.Application.Common.Dtos.Staff;

namespace Asset_Tracking.Application.Common.Dtos.Asset
{
    /// <summary>
    /// Detailed DTO for asset checkout information.
    /// </summary>
    public record AssetCheckoutDetailsDto
    {
        /// <example>28</example>
        public int AssetCheckOutId { get; set; }

        /// <example>2026-03-10T09:00:00</example>
        public DateTime AssetCheckOutDate { get; set; }

        /// <example>2026-06-10T23:59:59</example>
        public DateTime? DueDate { get; set; }

        /// <example>Assigned to staff for field project use.</example>
        public string? Notes { get; set; }

        /// <example>2026-03-09T14:30:00</example>
        public DateTime DateCreated { get; set; }

        /// <example>asset_admin</example>
        public string CreatedBy { get; set; } = null!;

        /// <example>2026-03-11T10:15:00</example>
        public DateTime? DateUpdated { get; set; }

        /// <example>asset_manager</example>
        public string? UpdatedBy { get; set; }

        /// <example>42</example>
        public int AssetId { get; set; }

        /// <example>EMP-00123</example>
        public string? StaffId { get; set; }

        /// <example>John Kofi Mensah</example>
        public string? AssignedTo { get; set; }

        /// <example>2</example>
        public int? SiteId { get; set; }

        /// <example>5</example>
        public int BuildingId { get; set; }

        /// <example>12</example>
        public int FloorId { get; set; }

        /// <example>34</example>
        public int RoomId { get; set; }

        /// <example>Room 204 - Left corner desk near window</example>
        public string? RoomLocationDescription { get; set; }

        /// <example>true</example>
        public bool IsConfirmedEmailSent { get; set; }

        /// <example>2026-03-10T09:15:00</example>
        public DateTime? EmailSentDate { get; set; }

        /// <example>true</example>
        public bool HasReceivedConfirmed { get; set; }

        /// <example>2026-03-10T10:45:00</example>
        public DateTime? HasReceivedConfirmedDate { get; set; }

        /// <example>false</example>
        public bool IsSMSSent { get; set; }

        /// <example>2026-03-10T09:20:00</example>
        public DateTime? SMSSentDate { get; set; }

        public AssetDto Asset { get; set; }

        public StaffResponseDto Staff { get; set; }

        public BuildingResponseDto Building { get; set; }

        public SiteResponseDto Site { get; set; }

        public FloorResponseDto Floor { get; set; }

        public RoomResponseDto Room { get; set; }
    }
}