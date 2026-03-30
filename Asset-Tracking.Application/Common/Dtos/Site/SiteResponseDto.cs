namespace Asset_Tracking.Application.Common.Dtos.Site
{
    /// <summary>
    /// Represents a physical site or location in the asset tracking system.
    /// </summary>
    public record SiteResponseDto
    {
        /// <example>2</example>
        public int SiteId { get; set; }

        /// <example>Kumasi Regional Office</example>
        public string SiteName { get; set; } = null!;

        /// <example>Main warehouse and distribution hub for the Ashanti Region.</example>
        public string? SiteDescription { get; set; }

        /// <example>12 Osei Tutu Ave, Kumasi</example>
        public string? Address { get; set; }

        /// <example>AK-123-4567</example>
        public string? DigitalAddress { get; set; }

        /// <example>kumasi.office@company.com</example>
        public string? Email { get; set; }

        /// <example>admin_user</example>
        public string CreatedBy { get; set; } = null!;

        /// <example>null</example>
        public string? UpdateBy { get; set; }
    }
}