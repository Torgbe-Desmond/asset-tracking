namespace Asset_Tracking_Api.Dtos.Asset
{
    public class AssetCategoryDto
    {
        public int AssetCategoryId { get; set; }
        public string AssetCategoryName { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
        public string? UpdatedBy { get; set; }
    }
}
