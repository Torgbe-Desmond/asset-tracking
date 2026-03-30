using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asset_Tracking.Application.Common.Dtos.Asset
{
    public class AssetMaintenanceRequestDto
    {
        public string MaintenanceTitle { get; set; } = null!;

        public string Details { get; set; } = null!;

        public DateTime DateSent { get; set; }

        public string MaintainedBy { get; set; } = null!;

        public DateTime? DateCompleted { get; set; }

        public decimal? Cost { get; set; }

        public DateTime DateCreated { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime? DateUpdated { get; set; }

        public string? UpdatedBy { get; set; }

        public int MaintenanceStatusId { get; set; }

        public int AssetId { get; set; }
    }
}
