using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asset_Tracking.Domain.Entities
{
    public class RefreshTokenEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(900)]
        [ForeignKey(nameof(User))]
        public string? UserId { get; set; }

        [MaxLength(4000)]
        public string? GeneratedRefreshToken { get; set; }

        public virtual ApplicationUser? User { get; set; }
    }
}
