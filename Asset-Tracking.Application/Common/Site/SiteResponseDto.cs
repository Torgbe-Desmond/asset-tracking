using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asset_Tracking.Application.Common.Site
{
    public record SiteResponseDto
    {
        public int SiteId { get; set; }
        public string SiteName { get; set; } = null!;
        public string? SiteDescription { get; set; }
        public string? Address { get; set; }
        public string? DigitalAddress { get; set; }
        public string? Email { get; set; }
        public string CreatedBy { get; set; } = null!;
        public string? UpdateBy { get; set; }   
    }
}
