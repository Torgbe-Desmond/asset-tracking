using System.ComponentModel.DataAnnotations;

namespace Asset_Tracking.Domain.Entities
{
    public class FloorEntity
    {
        [Key]
        public int FloorId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FloorName { get; set; } = null!;

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
