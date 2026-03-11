using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asset_Tracking.Domain.Entities
{
    public class RoleClaimsEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(900)]
        [ForeignKey(nameof(Role))]
        public string RoleId { get; set; } = null!;

        [MaxLength(4000)]
        public string? ClaimType { get; set; }

        [MaxLength(4000)]
        public string? ClaimValue { get; set; }

        public virtual RoleEntity Role { get; set; } = null!;
    }
}
