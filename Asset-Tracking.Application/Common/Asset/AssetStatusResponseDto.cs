using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asset_Tracking.Application.Common.Asset
{
    public record AssetStatusResponseDto
    {
        public int AssetStatusId { get; set; }

        public string AssetStatusName { get; set; } = null!;

        public string CreatedBy { get; set; } = null!;

        public string? UpdatedBy { get; set; }
    }
}
