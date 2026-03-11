using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asset_Tracking.Application.Common.Site
{
    public record SiteHeadRequestDto
    {
        [Required]
        [MaxLength(300)]
        public string HeadName { get; set; } = null!;

        [EmailAddress]
        [MaxLength(300)]
        public string? HeadEmail { get; set; }

        [Phone]
        [MaxLength(30)]
        public string? HeadPhoneNumber { get; set; }

        [Required]
        public int TitleId { get; set; }

        [Required]
        [MaxLength(300)]
        public string CreatedBy { get; set; } = null!;
    }
}
