using System.ComponentModel.DataAnnotations;

namespace Asset_Tracking.Application.Common.Role
{
    public record RoleRequestDto
    {
        [Required]
        [MaxLength(512)]
        public string? Name { get; set; }

        [MaxLength(512)]
        public string? NormalizedName { get; set; }
    }
}
