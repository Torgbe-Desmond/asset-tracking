namespace Asset_Tracking.Application.Common.Asset
{
    public record RepairStatusResponseDto
    {
        public int RepairStatusId { get; set; }
        public string RepairStatusName { get; set; } = null!;
    }
}
