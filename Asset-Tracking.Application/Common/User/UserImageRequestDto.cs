using Microsoft.AspNetCore.Http;

namespace Asset_Tracking.Application.Common.User
{
    public record UserImageRequestDto
    {
        public IFormFile PhotoFile { get; set; } = null!;

    }
}
