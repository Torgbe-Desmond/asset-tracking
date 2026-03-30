namespace Asset_Tracking.Application.Common.Dtos.Site
{
    /// <summary>
    /// Response DTO for site head data.
    /// </summary>
    public record SiteHeadResponseDto
    {
        /// <example>5</example>
        public int SiteheadId { get; set; }

        /// <example>Ama Serwaa Boateng</example>
        public string HeadName { get; set; } = null!;

        /// <example>ama.boateng@company.com</example>
        public string? HeadEmail { get; set; }

        /// <example>+233 24 123 4567</example>
        public string? HeadPhoneNumber { get; set; }

        /// <example>3</example>
        public int TitleId { get; set; }
    }
}