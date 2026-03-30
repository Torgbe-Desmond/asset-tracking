using System.ComponentModel.DataAnnotations;

namespace Asset_Tracking.Application.Common.Dtos.Site
{
    /// <summary>
    /// Request DTO for creating or updating site head data.
    /// </summary>
    public record SiteHeadRequestDto
    {
        /// <example>Ama Serwaa Boateng</example>
        [Required]
        [MaxLength(300)]
        public string HeadName { get; set; } = null!;

        /// <example>ama.boateng@company.com</example>
        [EmailAddress]
        [MaxLength(300)]
        public string? HeadEmail { get; set; }

        /// <example>+233 24 123 4567</example>
        [Phone]
        [MaxLength(30)]
        public string? HeadPhoneNumber { get; set; }

        /// <example>3</example>
        [Required]
        public int TitleId { get; set; }

        /// <example>admin_user</example>
        [Required]
        [MaxLength(300)]
        public string CreatedBy { get; set; } = null!;
    }
}