namespace Asset_Tracking.Application.Common.Floor
{
    public record FloorResponseDto
    {
        public int FloorId { get; set; }
        public string FloorName { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
        public string? UpdatedBy { get; set; }
    }
}
