namespace Asset_Tracking.Application.Common.Site
{
    public record SiteLocationResponseDto
    {
        public int SiteLocationId { get; set; }

        public string Location { get; set; } = null!;

        public int SiteId { get; set; }
    }
}
