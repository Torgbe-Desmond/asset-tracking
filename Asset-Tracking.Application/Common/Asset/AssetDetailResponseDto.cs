namespace Asset_Tracking.Application.Common.Asset
{
    /// <summary>
    /// Represents a flat, detailed summary of an asset.
    /// </summary>
    public record AssetDetailResponseDto
    {
        /// <example>501</example>
        public int AssetId { get; init; }

        /// <example>Laptop Pro 15</example>
        public string AssetName { get; init; } = null!;

        /// <example>High-performance laptop for development team.</example>
        public string? AssetDescription { get; init; }

        /// <example>Tech Supply Store</example>
        public string? PurchaseFrom { get; init; }

        /// <example>2025-01-15T00:00:00Z</example>
        public DateTime? PurchaseDate { get; init; }

        /// <example>1500.00</example>
        public decimal Cost { get; init; }

        /// <example>Dell</example>
        public string? Brand { get; init; }

        /// <example>XPS 15</example>
        public string? Model { get; init; }

        /// <example>SN-99823344</example>
        public string? SerialNumber { get; init; }

        /// <example>John Doe</example>
        public string? AssignedTo { get; init; }

        /// <example>true</example>
        public bool HasWarranty { get; init; }

        /// <example>2027-01-15T00:00:00Z</example>
        public DateTime? WarrantyDate { get; init; }

        /// <example>admin_user</example>
        public string CreatedBy { get; init; } = null!;

        /// <example>null</example>
        public string? UpdatedBy { get; init; }

        /// <example>1</example>
        public int AssetCategoryId { get; init; }

        /// <example>2</example>
        public int AssetStatusId { get; init; }

        /// <example>99</example>
        public int? AssetImageId { get; init; }

        /// <example>2</example>
        public int? SiteId { get; init; }

        /// <example>1</example>
        public int? BuildingId { get; init; }

        /// <example>3</example>
        public int? FloorId { get; init; }

        /// <example>12</example>
        public int? RoomId { get; init; }

        /// <example>South Wing, Room 302</example>
        public string? RoomLocationDescription { get; init; }

        /// <example>TAG-5501-ABC</example>
        public string AssetTagId { get; init; } = null!;

        /// <example>Excellent condition, no scuffs.</example>
        public string? AssetConditionDescription { get; init; }

        /// <example>true</example>
        public bool? IsAssetInGoodCondition { get; init; }

        /// <example>false</example>
        public bool? IsRepairRequired { get; init; }
    }
}