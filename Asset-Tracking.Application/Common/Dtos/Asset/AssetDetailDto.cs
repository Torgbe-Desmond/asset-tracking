using Asset_Tracking.Application.Common.Dtos.Building;
using Asset_Tracking.Application.Common.Dtos.Floor;
using Asset_Tracking.Application.Common.Dtos.Room;
using Asset_Tracking.Application.Common.Dtos.Site;

namespace Asset_Tracking.Application.Common.Dtos.Asset
{
    /// <summary>
    /// Represents the full, detailed profile of an asset including all relational data.
    /// </summary>
    public class AssetDetailDto
    {
        /// <example>501</example>
        public int AssetId { get; set; }

        /// <example>Laptop Pro 15</example>
        public string AssetName { get; set; } = null!;

        /// <example>TAG-5501-ABC</example>
        public string AssetTagId { get; set; } = null!;

        /// <example>SN-99823344</example>
        public string? SerialNumber { get; set; }

        /// <example>High-performance laptop for development team.</example>
        public string? AssetDescription { get; set; }

        /// <example>Tech Supply Store</example>
        public string? PurchaseFrom { get; set; }

        /// <example>2025-01-15T00:00:00Z</example>
        public DateTime? PurchaseDate { get; set; }

        /// <example>1500.00</example>
        public decimal Cost { get; set; }

        /// <example>Dell</example>
        public string? Brand { get; set; }

        /// <example>XPS 15</example>
        public string? Model { get; set; }

        /// <example>John Doe</example>
        public string? AssignedTo { get; set; }

        /// <example>true</example>
        public bool HasWarranty { get; set; }

        /// <example>2027-01-15T00:00:00Z</example>
        public DateTime? WarrantyDate { get; set; }

        /// <example>1</example>
        public int AssetCategoryId { get; set; }

        /// <example>2</example>
        public int AssetStatusId { get; set; }

        /// <example>2</example>
        public int? SiteId { get; set; }

        /// <example>1</example>
        public int? BuildingId { get; set; }

        /// <example>3</example>
        public int? FloorId { get; set; }

        /// <example>12</example>
        public int? RoomId { get; set; }

        /// <example>South Wing, Room 302</example>
        public string? RoomLocationDescription { get; set; }

        /// <example>Excellent condition, no scuffs.</example>
        public string? AssetConditionDescription { get; set; }

        /// <example>true</example>
        public bool? IsAssetInGoodCondition { get; set; }

        /// <example>false</example>
        public bool? IsRepairRequired { get; set; }

        /// <example>2026-03-12T08:00:00Z</example>
        public DateTime DateCreated { get; set; }

        /// <example>admin_user</example>
        public string CreatedBy { get; set; } = null!;

        // Swagger automatically hydrates nested objects from their respective DTO definitions
        public AssetCategoryResponseDto? AssetCategory { get; set; }
        public AssetStatusResponseDto? AssetStatus { get; set; }
        public SiteResponseDto? Site { get; set; }
        public BuildingResponseDto? Building { get; set; }
        public FloorResponseDto? Floor { get; set; }
        public RoomResponseDto? Room { get; set; }
        public AssetImageResponseDto? AssetImage { get; set; }
    }
}