using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asset_Tracking.Domain.Entities
{
    public class UserEntity 
    {
        [Key]
        [MaxLength(900)]
        [Required]
        public string Id { get; set; } = null!;

        [MaxLength(4000)] 
        public string? FirstName { get; set; }

        [MaxLength(4000)]
        public string? LastName { get; set; }

        public int? TitleId { get; set; }

        public int? UserImageId { get; set; }

        public int? StaffId { get; set; }

        [MaxLength(512)]
        public string? UserName { get; set; }

        [MaxLength(512)]
        public string? NormalizedUserName { get; set; }

        [MaxLength(512)]
        [EmailAddress]
        public string? Email { get; set; }

        [MaxLength(512)]
        public string? NormalizedEmail { get; set; }

        [Required]
        public bool EmailConfirmed { get; set; }  

        [MaxLength(4000)]
        public string? PasswordHash { get; set; }

        [MaxLength(4000)]
        public string? SecurityStamp { get; set; }

        [MaxLength(4000)]
        public string? ConcurrencyStamp { get; set; } 

        [MaxLength(4000)]
        [Phone]
        public string? PhoneNumber { get; set; }

        [Required]
        public bool PhoneNumberConfirmed { get; set; }  

        [Required]
        public bool TwoFactorEnabled { get; set; }
        public bool LockoutEnabled { get; set; }
        public bool AccessFailedCount   { get; set; }
}
}   
