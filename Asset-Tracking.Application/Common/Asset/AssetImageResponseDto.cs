namespace Asset_Tracking.Application.Common.Asset
{
    public class AssetImageResponseDto
    {
        public int AssetImageId { get; set; }
        public byte[] Photo { get; set; } = null!;
    }
}
