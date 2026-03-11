using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asset_Tracking.Application.Common.Building;
using Asset_Tracking.Application.Common.Floor;
using Asset_Tracking.Application.Common.Room;
using Asset_Tracking.Application.Common.Site;

namespace Asset_Tracking.Application.Common.Asset
{
    public class AssetDetailDto
    {
        public int AssetId { get; set; }
        public string AssetName { get; set; } = null!;
        public string AssetTagId { get; set; } = null!;
        public string? SerialNumber { get; set; }
        public string? AssetDescription { get; set; }
        public string? PurchaseFrom { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public decimal Cost { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? AssignedTo { get; set; }
        public bool HasWarranty { get; set; }
        public DateTime? WarrantyDate { get; set; }
        public int AssetCategoryId { get; set; }
        public int AssetStatusId { get; set; }
        public int? SiteId { get; set; }
        public int? BuildingId { get; set; }
        public int? FloorId { get; set; }
        public int? RoomId { get; set; }
        public string? RoomLocationDescription { get; set; }
        public string? AssetConditionDescription { get; set; }
        public bool? IsAssetInGoodCondition { get; set; }
        public bool? IsRepairRequired { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; } = null!;

        // Nested objects — exactly like your JSON
        public AssetCategoryResponseDto? AssetCategory { get; set; }
        public AssetStatusResponseDto? AssetStatus { get; set; }
        public SiteResponseDto? Site { get; set; }
        public BuildingResponseDto? Building { get; set; }
        public FloorResponseDto? Floor { get; set; }
        public RoomResponseDto? Room { get; set; }
        public AssetImageResponseDto? AssetImage { get; set; }
    }
   
}
