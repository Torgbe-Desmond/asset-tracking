using System.ComponentModel.DataAnnotations;

namespace Asset_Tracking.Domain.Entities
{
    public class TitleEntity
    {
        [Key]
        [Required]
        public int  TitleId { get; set; }

        [MaxLength(100)]
        [Required]
        public string TitleName { get; set; } = null!;
    }
}
