using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Asset_Tracking.Domain.Entities
{
    /// <summary>
    /// Custom ApplicationUser that extends IdentityUser for the Asset Tracking System.
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// User's first name.
        /// </summary>
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// User's last name.
        /// </summary>
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Foreign key referencing the user's job title.
        /// </summary>
        public int TitleId { get; set; }

        /// <summary>
        /// Foreign key to the primary user image/profile picture.
        /// </summary>
        public int UserImageId { get; set; }

        /// <summary>
        /// Indicates whether the user account is active.
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Date and time when the user was created.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties

        /// <summary>
        /// Refresh tokens issued to this user for JWT authentication.
        /// </summary>
        public ICollection<RefreshTokenEntity> RefreshTokens { get; set; }
            = new List<RefreshTokenEntity>();

        /// <summary>
        /// All images associated with this user.
        /// </summary>
        public ICollection<UserImageEntity> UserImages { get; set; }
            = new List<UserImageEntity>();

        /// <summary>
        /// Returns the user's full name by combining FirstName and LastName.
        /// </summary>
        public string FullName => $"{FirstName} {LastName}".Trim();
    }
}