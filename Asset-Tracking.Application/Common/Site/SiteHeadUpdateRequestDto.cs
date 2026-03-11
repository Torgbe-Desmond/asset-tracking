using System.ComponentModel.DataAnnotations;

namespace Asset_Tracking.Application.Common.Site
{
    public record SiteHeadUpdateRequestDto
    {

        [MaxLength(300)]
        public string? HeadName { get; set; }

        [EmailAddress]
        [MaxLength(300)]
        public string? HeadEmail { get; set; }

        [Phone]
        [MaxLength(30)]
        public string? HeadPhoneNumber { get; set; }

        [MaxLength(300)]
        public string? UpdatedBy { get; set; }
    }
}
