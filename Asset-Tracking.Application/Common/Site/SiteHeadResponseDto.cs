namespace Asset_Tracking.Application.Common.Site
{
    public record SiteHeadResponseDto
    {
        public int SiteheadId { get; set; }

        public string HeadName { get; set; } = null!;

        public string? HeadEmail { get; set; }

        public string? HeadPhoneNumber { get; set; }

        public int TitleId { get; set; }
    }
}
