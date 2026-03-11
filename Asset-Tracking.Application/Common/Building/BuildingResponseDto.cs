using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asset_Tracking.Application.Common.Building
{
    public record BuildingResponseDto
    {
        public int BuildingId { get; set; }
        public string? BuildingName { get; set; }
        public string CreatedBy { get; set; } = null!;
        public string? UpdatedBy { get; set; }
    }
}
