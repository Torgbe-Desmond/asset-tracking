using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Asset_Tracking.Domain.Entities
{
    public class SiteLocationEntity
    {
        [Key]
        public int SiteLocationId { get; set; }

        [Required]
        [MaxLength(300)]
        public string Location { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(SiteEntity))]
        public int SiteId { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        [MaxLength(300)]
        public string CreatedBy { get; set; } = null!;

        public DateTime? DateUpdated { get; set; }

        [MaxLength(300)]
        public string? UpdatedBy { get; set; }
      
        public virtual SiteEntity Site { get; set; } = null!;

    }
}

