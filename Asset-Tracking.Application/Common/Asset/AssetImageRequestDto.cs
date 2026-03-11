using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Asset_Tracking.Application.Common.Asset
{
    public record AssetImageRequestDto
    {
        public IFormFile PhotoFile { get; set; } = null!;
    }
}
