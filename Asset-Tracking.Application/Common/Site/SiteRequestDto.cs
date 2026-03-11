namespace Asset_Tracking.Application.Common.Site
{
    public class SiteRequestDto
    {
        public string SiteName { get; set; } = null!;
        public string? SiteDescription { get; set; }
        public string? Address { get; set; }
        public string? DigitalAddress { get; set; }
        public string? Email { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime? DateUpdated { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
