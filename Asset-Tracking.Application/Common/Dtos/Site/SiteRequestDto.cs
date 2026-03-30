namespace Asset_Tracking.Application.Common.Dtos.Site
{
    /// <summary>
    /// Request DTO for creating or updating site/location data.
    /// </summary>
    public class SiteRequestDto
    {
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

        /// <example>2026-02-15T09:30:00</example>
        public DateTime DateCreated { get; set; }

        /// <example>admin_user</example>
        public string CreatedBy { get; set; } = null!;

        /// <example>2026-02-18T14:45:00</example>
        public DateTime? DateUpdated { get; set; }

        /// <example>system_admin</example>
        public string? UpdatedBy { get; set; }
    }
}