using Microsoft.AspNetCore.Identity;

namespace Asset_Tracking.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TitleId { get; set; }
        public int UserImageId { get; set; }

        // Navigation properties
        public ICollection<RefreshTokenEntity> RefreshTokens { get; set; } = new List<RefreshTokenEntity>();
        public ICollection<UserImageEntity> UserImages { get; set; } = new List<UserImageEntity>();
    }
}
