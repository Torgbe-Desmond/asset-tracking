namespace Asset_Tracking.Application.Common.Floor
{
    public class FloorRequestDto
    {
        public string FloorName { get; set; } = null!;
        public int BuildingId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
