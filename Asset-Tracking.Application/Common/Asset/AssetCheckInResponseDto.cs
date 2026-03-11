using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asset_Tracking.Application.Common.Site;

namespace Asset_Tracking.Application.Common.Asset
{
    public record AssetCheckInResponseDto
    {
        public int AssetCheckInId { get; set; }
        public DateTime ReturnDate { get; set; }
        public string? Notes { get; set; }
        public string ReturnedBy { get; set; } = null!;
        public string? StaffId { get; set; }
        public string CreatedBy { get; set; } = null!;
        public string? UpdatedBy { get; set; }
        public int AssetId { get; set; }
        public int? SiteId { get; set; }
    }
}
