using System.ComponentModel.DataAnnotations;

namespace Asset_Tracking.Domain.Entities
{
    public class MaintenanceStatusEntity
    {
        [Key]
        public int MaintenanceStatusId { get; set; }

        [Required]
        [MaxLength(300)]
        public string StatusName { get; set; } = null!;

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        [MaxLength(300)]
        public string CreatedBy { get; set; } = null!;

        public DateTime? DateUpdated { get; set; }

        [MaxLength(300)]
        public string? UpdatedBy { get; set; }
    }
}
