namespace Asset_Tracking.Application.Common.Asset
{
    public record AssetDetailResponseDto
    {
        public int AssetId { get; init; }
        public string AssetName { get; init; } = null!;
        public string? AssetDescription { get; init; }
        public string? PurchaseFrom { get; init; }
        public DateTime? PurchaseDate { get; init; }
        public decimal Cost { get; init; }
        public string? Brand { get; init; }
        public string? Model { get; init; }
        public string? SerialNumber { get; init; }
        public string? AssignedTo { get; init; }
        public bool HasWarranty { get; init; }
        public DateTime? WarrantyDate { get; init; }
        public string CreatedBy { get; init; } = null!;
        public string? UpdatedBy { get; init; }
        public int AssetCategoryId { get; init; }
        public int AssetStatusId { get; init; }
        public int? AssetImageId { get; init; }
        public int? SiteId { get; init; }
        public int? BuildingId { get; init; }
        public int? FloorId { get; init; }
        public int? RoomId { get; init; }
        public string? RoomLocationDescription { get; init; }
        public string AssetTagId { get; init; } = null!;
        public string? AssetConditionDescription { get; init; }
        public bool? IsAssetInGoodCondition { get; init; }
        public bool? IsRepairRequired { get; init; }

        // Optional: if you want to include navigation property data (flattened)
        // public string AssetCategoryName { get; init; } = null!;
        // public string AssetStatusName { get; init; } = null!;
        // public string? SiteName { get; init; }
        // public string? BuildingName { get; init; }
        // etc.
    }
}
