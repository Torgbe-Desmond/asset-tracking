using System.ComponentModel.DataAnnotations;

namespace Asset_Tracking.Domain.Entities
{
    public class RepairStatusEntity
    {
        [Key]
        public int RepairStatusId { get; set; }

        [Required]
        [MaxLength(100)]
        public string RepairStatusName { get; set; } = null!;
    }
}
