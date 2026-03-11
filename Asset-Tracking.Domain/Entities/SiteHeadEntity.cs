using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asset_Tracking.Domain.Entities
{
    public class SiteHeadEntity
    {
        [Key]
        public int SiteheadId { get; set; }

        [Required]
        [MaxLength(300)]
        public string HeadName { get; set; } = null!;

        [MaxLength(300)]
        [EmailAddress]
        public string? HeadEmail { get; set; }

        [MaxLength(30)]
        [Phone]
        public string? HeadPhoneNumber { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        [MaxLength(300)]
        public string CreatedBy { get; set; } = null!;

        public DateTime? DateUpdated { get; set; }

        [MaxLength(300)]
        public string? UpdatedBy { get; set; }

        [Required]
        [ForeignKey(nameof(Title))]
        public int TitleId { get; set; }

        public virtual TitleEntity? Title { get; set; }
    }
}
