using System.ComponentModel.DataAnnotations;

namespace Asset_Tracking.Application.Common.Dtos.Site
{
    /// <summary>
    /// Request DTO for updating site location data.
    /// </summary>
    public record SiteLocationUpdateRequestDto
    {
        /// <example>Central Stores - Zone A</example>
        [MaxLength(300)]
        public string? Location { get; set; }

        /// <example>stores_manager</example>
        [MaxLength(300)]
        public string? UpdatedBy { get; set; }
    }
}