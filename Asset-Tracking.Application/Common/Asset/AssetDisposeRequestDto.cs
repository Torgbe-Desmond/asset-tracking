namespace Asset_Tracking.Application.Common.Asset
{
    public class AssetDisposeRequestDto
    {
        public DateTime DisposeDate { get; set; }
        public string DisposeTo { get; set; } = null!;
        public string? Notes { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime? DateUpdated { get; set; }
        public string? UpdatedBy { get; set; }
        public int AssetId { get; set; }
    }
}
