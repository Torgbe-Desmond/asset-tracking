using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asset_Tracking.Domain.Entities
{
    public class UserClaimsEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(900)]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        [MaxLength(4000)]
        public string? ClaimType { get; set; }

        [MaxLength(4000)]
        public string? ClaimValue { get; set; }

        public virtual UserEntity? User { get; set; }

    }
}
