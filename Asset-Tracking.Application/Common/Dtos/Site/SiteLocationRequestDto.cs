using System.ComponentModel.DataAnnotations;

namespace Asset_Tracking.Application.Common.Dtos.Site
{
    /// <summary>
    /// Request DTO for creating or updating site location data.
    /// </summary>
    public record SiteLocationRequestDto
    {
        /// <example>Central Stores</example>
        [Required]
        [MaxLength(300)]
        public string Location { get; set; } = null!;

        /// <example>2</example>
        [Required]
        public int SiteId { get; set; }

        /// <example>stores_admin</example>
        [Required]
        [MaxLength(300)]
        public string CreatedBy { get; set; } = null!;
    }
}