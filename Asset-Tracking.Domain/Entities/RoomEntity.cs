using System.ComponentModel.DataAnnotations;

namespace Asset_Tracking.Domain.Entities
{
    public class RoomEntity
    {
        [Key]
        public int RoomId { get; set; }
        [Required]
        [MaxLength(100)]
        public string RoomName { get; set; } = null!;
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
