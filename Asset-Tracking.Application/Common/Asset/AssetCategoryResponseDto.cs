namespace Asset_Tracking.Application.Common.Asset
{
    public record AssetCategoryResponseDto
    {
        public int AssetCategoryId { get; set; }
        public string AssetCategoryName { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
        public string? UpdatedBy { get; set; }
    }
}
