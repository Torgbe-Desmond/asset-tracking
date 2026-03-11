using System.ComponentModel.DataAnnotations;

namespace Asset_Tracking.Domain.Entities
{
    public class AssetCategoryEntity
    {
        [Key]
        public int AssetCategoryId { get; set; }

        [Required]
        [MaxLength(300)]
        public string AssetCategoryName { get; set; } = null!;

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
