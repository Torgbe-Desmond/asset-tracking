namespace Asset_Tracking.Application.Common.Dtos.Room
{
    public record RoomRequestDto
    {
        public string RoomName { get; set; } = null!;
        public int FloorId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
