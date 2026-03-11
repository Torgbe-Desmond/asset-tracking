namespace Asset_Tracking.Application.Common.Asset
{
    public record AssetCategoryRequestDto
    {
        public string AssetCategoryName { get; set; } = null!;
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime? DateUpdated { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
