using System.ComponentModel.DataAnnotations;

namespace Asset_Tracking.Domain.Entities
{
    public class BuildingEntity
    {
        [Key]
        public int BuildingId { get; set; }

        [MaxLength(300)]
        public string? BuildingName { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(300)]
        public string CreatedBy { get; set; } = null!;

        public DateTime? UpdatedDate { get; set; }

        [MaxLength(300)]
        public string? UpdatedBy { get; set; }
    }
}
