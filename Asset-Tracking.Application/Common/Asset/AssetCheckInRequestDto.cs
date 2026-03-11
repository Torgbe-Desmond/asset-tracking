namespace Asset_Tracking.Application.Common.Asset
{
    public record AssetCheckInRequestDto
    {
        public DateTime ReturnDate { get; set; }
        public string? Notes { get; set; }
        public string ReturnedBy { get; set; } = null!;
        public string? StaffId { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime? DateUpdated { get; set; }
        public string? UpdatedBy { get; set; }
        public int AssetId { get; set; }
        public int? SiteId { get; set; }
    }
}
