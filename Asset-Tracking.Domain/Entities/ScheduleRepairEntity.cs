using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Asset_Tracking.Domain.Entities
{
    public class ScheduleRepairEntity
    {
        [Key]
        [Required]
        [MaxLength(200)]
        public string ScheduleRepairId { get; set; } = null!;

        [Required]
        [MaxLength(300)]
        public string RepairTitle { get; set; } = null!;

        [Required]
        [MaxLength(4000)]
        public string Details { get; set; } = null!;

        [MaxLength(300)]
        public string? RepairerName { get; set; }

        [MaxLength(30)]
        [Phone]
        public string? RepairerContactNumber { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? Cost { get; set; }

        [MaxLength(100)]
        public string? DateCompleted { get; set; }  

        [Required]
        [MaxLength(200)]
        public string CreatedBy { get; set; } = null!;

        [Required]
        public DateTime DateCreated { get; set; }

        [MaxLength(200)]
        public string? UpdateBy { get; set; }

        public DateTime? DateUpdated { get; set; }

        [Required]
        [ForeignKey(nameof(RepairStatus))]
        public int RepairStatusId { get; set; }
        public virtual RepairStatusEntity RepairStatus { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Asset))]
        public int AssetId { get; set; }
        public virtual AssetEntity Asset { get; set; } = null!;

        public int IsScheduleApproved { get; set; }  
    }
}
