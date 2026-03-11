using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asset_Tracking.Domain.Entities
{
    public class UserLoginEntity
    {
        [Key]
        [Required]
        [MaxLength(900)]
        public string LoginProvider { get; set; } = null!;

        [Key]
        [Required]
        [MaxLength(900)]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        [Key]
        [Required]
        public string ProviderKey { get; set; } = null!;

        [MaxLength(4000)]
        public string? ProviderDisplayName { get; set; }

        public virtual UserEntity User { get; set; }
    }
}
