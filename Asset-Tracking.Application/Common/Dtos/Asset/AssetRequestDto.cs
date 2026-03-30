namespace Asset_Tracking.Application.Common.Dtos.Asset
{
    public record AssetRequestDto
    {
        public string AssetName { get; init; } = null!;
        public string? AssetDescription { get; init; }
        public string? PurchaseFrom { get; init; }
        public DateTime? PurchaseDate { get; init; }
        public decimal Cost { get; init; }
        public string? Brand { get; init; }
        public string? Model { get; init; }
        public string? SerialNumber { get; init; }
        public string? AssignedTo { get; init; }
        public bool HasWarranty { get; init; } = false!;
        public DateTime? WarrantyDate { get; init; }
        public int AssetCategoryId { get; init; }
        public int AssetStatusId { get; init; }
        public int AssetImageId { get; init; }
        public int? SiteId { get; init; }
        public int? BuildingId { get; init; }
        public int? FloorId { get; init; }
        public int? RoomId { get; init; }
        public string CreatedBy { get; init; } = null!;
        public string? RoomLocationDescription { get; init; }
        public string AssetTagId { get; init; } = null!;
        public string? AssetConditionDescription { get; init; }
        public bool IsAssetInGoodCondition { get; init; } = false!;
        public bool IsRepairRequired { get; init; } = false!;
        public DateTime DateCreated { get; init; }
        public DateTime? DateUpdated { get; init; }
        public string? UpdatedBy { get; set; }

    }
}
