namespace Asset_Tracking.Application.Common.Dtos.Site
{
    /// <summary>
    /// Response DTO for site location data.
    /// </summary>
    public record SiteLocationResponseDto
    {
        /// <example>15</example>
        public int SiteLocationId { get; set; }

        /// <example>Central Stores</example>
        public string Location { get; set; } = null!;

        /// <example>2</example>
        public int SiteId { get; set; }
    }
}