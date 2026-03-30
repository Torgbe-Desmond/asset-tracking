using Microsoft.AspNetCore.Http;

namespace Asset_Tracking.Application.Common.Dtos.User
{
    public class UserImageUpdateRequestDto
    {
        public int Id { get; set; }
        public IFormFile PhotoFile { get; set; } = null!;
    }
}
