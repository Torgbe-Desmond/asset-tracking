using System.ComponentModel.DataAnnotations;

namespace Asset_Tracking.Application.Common.Dtos.Asset
{
    public record RepairStatusRequestDto
    {
        [Required]
        [MaxLength(100)]
        public string RepairStatusName { get; set; } = null!;
    }
}
