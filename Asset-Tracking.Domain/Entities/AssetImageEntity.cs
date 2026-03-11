using System.ComponentModel.DataAnnotations;

namespace Asset_Tracking.Domain.Entities
{
    public class AssetImageEntity
    {
        [Key]
        public int AssetImageId { get; set; }

        [Required]
        public byte[] Photo { get; set; } = null!;
    }
}
