namespace Asset_Tracking.Application.Common.Asset
{
    public record AssetEventHistoryResponseDto
    {
        public string AssetEventHistoryId { get; set; } = null!;
        public DateTime Date { get; set; }
        public string Event { get; set; } = null!;
        public string StatusChangedFrom { get; set; } = null!;
        public string StatusChangeTo { get; set; } = null!;
        public string? LocationChangedFrom { get; set; }
        public string? LocationChangedTo { get; set; }
        public string? SiteChangedFrom { get; set; }
        public string? SiteChangedTo { get; set; }
        public string? AssignedFrom { get; set; }
        public string? AssignedTo { get; set; }
        public int AssetId { get; set; }

    }
}
