using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asset_Tracking.Domain.Entities
{
    public class AssetEventHistoryEntity
    {
        [Key]
        [Required]
        [MaxLength(200)]
        public string AssetEventHistoryId { get; set; } = null!;

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(300)]
        public string Event { get; set; } = null!;

        [Required]
        [MaxLength(300)]
        public string StatusChangedFrom { get; set; } = null!;

        [Required]
        [MaxLength(300)]
        public string StatusChangeTo { get; set; } = null!;

        [MaxLength(300)]
        public string? LocationChangedFrom { get; set; }

        [MaxLength(300)]
        public string? LocationChangedTo { get; set; }

        [MaxLength(300)]
        public string? SiteChangedFrom { get; set; }

        [MaxLength(300)]
        public string? SiteChangedTo { get; set; }

        [MaxLength(300)]
        public string? AssignedFrom { get; set; }

        [MaxLength(300)]
        public string? AssignedTo { get; set; }

        [Required]
        [ForeignKey(nameof(Asset))]
        public int AssetId { get; set; }

        public virtual AssetEntity Asset { get; set; } = null!;
    }
}
