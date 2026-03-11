using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asset_Tracking.Domain.Entities
{
    public class UserTokenEntity
    {
        [Key]
        [MaxLength(900)]
        public string LoginProvider { get; set; } = null!;

        [MaxLength(900)]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        public string? Name { get; set; }
        public string? Value { get; set; }
        public virtual UserEntity User { get; set; }
    }
}
    