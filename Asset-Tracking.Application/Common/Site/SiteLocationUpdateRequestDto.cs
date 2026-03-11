using System.ComponentModel.DataAnnotations;

namespace Asset_Tracking.Application.Common.Site
{
    public record SiteLocationUpdateRequestDto
    {
        [MaxLength(300)]
        public string? Location { get; set; }

        [MaxLength(300)]
        public string? UpdatedBy { get; set; }
    }
}
