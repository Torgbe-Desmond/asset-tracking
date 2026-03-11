using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asset_Tracking.Domain.Entities
{
    public class AssetMaintenanceEntity
    {
        [Key]
        public int AssetMaintenanceId { get; set; }

        [Required]
        [MaxLength(300)]
        public string MaintenanceTitle { get; set; } = null!;

        [Required]
        [MaxLength(300)]
        public string Details { get; set; } = null!;

        [Required]
        public DateTime DateSent { get; set; }

        [Required]
        [MaxLength(300)]
        public string MaintainedBy { get; set; } = null!;

        public DateTime? DateCompleted { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? Cost { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        [MaxLength(300)]
        public string CreatedBy { get; set; } = null!;

        public DateTime? DateUpdated { get; set; }

        [MaxLength(300)]
        public string? UpdatedBy { get; set; }

        [Required]
        [ForeignKey(nameof(MaintenanceStatus))]
        public int MaintenanceStatusId { get; set; }

        public virtual MaintenanceStatusEntity MaintenanceStatus { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Asset))]
        public int AssetId { get; set; }

        public virtual AssetEntity Asset { get; set; } = null!;
    }
}
