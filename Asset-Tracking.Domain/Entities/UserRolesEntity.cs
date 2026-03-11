using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asset_Tracking.Domain.Entities
{

    public class UserRolesEntity
    {
        [Key]
        [Required]
        [MaxLength(900)]
        [ForeignKey(nameof(Role))]
        public string RoleId { get; set; } = null!;

        [Key]
        [Required]
        [MaxLength(900)]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        public virtual UserEntity User { get; set; }
        public virtual RoleEntity Role { get; set; }
    }
}
