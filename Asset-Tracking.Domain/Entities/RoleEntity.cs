using System.ComponentModel.DataAnnotations;

namespace Asset_Tracking.Domain.Entities
{
    public class RoleEntity
    {
        [Key]
        public string Id { get; set; } = null!;

        [MaxLength(512)]
        public string? Name { get; set; }

        [MaxLength(512)]
        public string? NormalizedName { get; set; }
        public string? ConcurrencyStamp { get; set; }
    }
}
