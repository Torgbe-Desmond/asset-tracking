using System.ComponentModel.DataAnnotations;

namespace Asset_Tracking.Domain.Entities
{
    public class UserImageEntity
    {
        [Key]
        public int UserImageId { get; set; }  

        [Required]
        public byte[] Photo { get; set; } = null!;
    }
}
