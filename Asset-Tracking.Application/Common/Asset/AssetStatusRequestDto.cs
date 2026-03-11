using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asset_Tracking.Application.Common.Asset
{
    public record AssetStatusRequestDto
    {
        public string AssetStatusName { get; set; } = null!;

        public DateTime DateCreated { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime? DateUpdated { get; set; }

        public string? UpdatedBy { get; set; }
    }
}
