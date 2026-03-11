using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asset_Tracking.Domain.Entities
{
    public class SiteEntity
    {
        [Key]
        public int SiteId { get; set; }

        [Required]
        [MaxLength(300)]
        public string SiteName { get; set; } = null!;

        [MaxLength(4000)]
        public string? SiteDescription { get; set; }

        [MaxLength(300)]
        public string? Address { get; set; }

        [MaxLength(30)]
        public string? DigitalAddress { get; set; }

        [MaxLength(300)]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        [Required]
        [MaxLength(300)]
        public string CreatedBy { get; set; } = null!;

        public string? UpdatedBy { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(SiteHead))]
        public int SiteheadId { get; set; }
        public virtual SiteHeadEntity? SiteHead { get; set; }

    }
}
