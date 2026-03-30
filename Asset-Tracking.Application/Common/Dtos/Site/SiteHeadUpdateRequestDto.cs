using System.ComponentModel.DataAnnotations;

namespace Asset_Tracking.Application.Common.Dtos.Site
{
    /// <summary>
    /// Request DTO for updating site head data.
    /// </summary>
    public record SiteHeadUpdateRequestDto
    {
        /// <example>Kofi Amoah</example>
        [MaxLength(300)]
        public string? HeadName { get; set; }

        /// <example>kofi.amoah@company.com</example>
        [EmailAddress]
        [MaxLength(300)]
        public string? HeadEmail { get; set; }

        /// <example>+233 27 987 6543</example>
        [Phone]
        [MaxLength(30)]
        public string? HeadPhoneNumber { get; set; }

        /// <example>hr_manager</example>
        [MaxLength(300)]
        public string? UpdatedBy { get; set; }
    }
}