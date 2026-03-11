using System.ComponentModel.DataAnnotations;

namespace Asset_Tracking.Domain.Entities
{
    public class StaffEntity
    {
        [Key]
        [Required]
        [MaxLength(100)]
        public string StaffId { get; set; } = null!;

        public int? TitleId { get; set; }

        [Required]
        [MaxLength(300)]
        public string Surname { get; set; } = null!;

        [Required]
        [MaxLength(300)]
        public string OtherName { get; set; } = null!;

        [Required]
        [MaxLength(300)]
        [EmailAddress]
        public string TechMail { get; set; } = null!;

        public int? SiteId { get; set; }

        public int? BuildingId { get; set; }

        public int? FloorId { get; set; }

        public int? RoomId { get; set; }

        public bool HasRoom { get; set; }        

        [MaxLength(4000)]
        public string? RoomLocationDescription { get; set; }
    }
}
