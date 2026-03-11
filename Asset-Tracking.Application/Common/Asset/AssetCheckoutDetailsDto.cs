using Asset_Tracking.Application.Common.Building;
using Asset_Tracking.Application.Common.Floor;
using Asset_Tracking.Application.Common.Room;
using Asset_Tracking.Application.Common.Site;
using Asset_Tracking.Application.Common.Staff;

namespace Asset_Tracking.Application.Common.Asset
{
    public record AssetCheckoutDetailsDto
    {
        public int AssetCheckOutId { get; set; }
        public DateTime AssetCheckOutDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string? Notes { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime? DateUpdated { get; set; }
        public string? UpdatedBy { get; set; }
        public int AssetId { get; set; }
        public string? StaffId { get; set; }
        public string? AssignedTo { get; set; }
        public int? SiteId { get; set; }
        public int BuildingId { get; set; }
        public int FloorId { get; set; }
        public int RoomId { get; set; }
        public string? RoomLocationDescription { get; set; }
        public bool IsConfirmedEmailSent { get; set; }
        public DateTime? EmailSentDate { get; set; }
        public bool HasReceivedConfirmed { get; set; }
        public DateTime? HasReceivedConfirmedDate { get; set; }
        public bool IsSMSSent { get; set; }
        public DateTime? SMSSentDate { get; set; }

        public AssetDto Asset { get; set; }

        public StaffResponseDto Staff { get; set; }

        public BuildingResponseDto Building { get; set; }

        public SiteResponseDto Site { get; set; }

        public FloorResponseDto Floor { get; set; } 

        public RoomResponseDto Room { get; set; }   



    }
}
