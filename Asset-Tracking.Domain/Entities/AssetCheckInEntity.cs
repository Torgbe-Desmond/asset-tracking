using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asset_Tracking.Domain.Entities
{
    public class AssetCheckInEntity
    {
        [Key]
        public int AssetCheckInId { get; set; }

        [Required]
        public DateTime ReturnDate { get; set; }

        [MaxLength(300)]
        public string? Notes { get; set; }

        [Required]
        [MaxLength(300)]
        public string ReturnedBy { get; set; } = null!;

        [MaxLength(100)]
        [ForeignKey(nameof(StaffId))]
        public string? StaffId { get; set; }
        public virtual StaffEntity? Staff { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        [MaxLength(300)]
        public string CreatedBy { get; set; } = null!;

        public DateTime? DateUpdated { get; set; }

        [MaxLength(300)]
        public string? UpdatedBy { get; set; }

        [Required]
        public int AssetId { get; set; }
        public int? SiteId { get; set; }

        [ForeignKey(nameof(SiteId))]
        public virtual SiteEntity? Site { get; set; }

        [ForeignKey(nameof(AssetId))]
        public virtual AssetEntity? Asset { get; set; }
       

    }
}
