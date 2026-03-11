using System.ComponentModel.DataAnnotations;

namespace Asset_Tracking.Application.Common.Site
{
    public record SiteLocationRequestDto
    {
        [Required]
        [MaxLength(300)]
        public string Location { get; set; } = null!;

        [Required]
        public int SiteId { get; set; }

        [Required]
        [MaxLength(300)]
        public string CreatedBy { get; set; } = null!;
    }
}
