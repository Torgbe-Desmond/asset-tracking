using System.ComponentModel.DataAnnotations;

namespace Asset_Tracking.Application.Common.Role
{
    public record RoleClaimRequestDto
    {
        [Required]
        public string RoleId { get; set; } = null!;

        [MaxLength(4000)]
        public string? ClaimType { get; set; }

        [MaxLength(4000)]
        public string? ClaimValue { get; set; }
    }
}
