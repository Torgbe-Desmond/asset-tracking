namespace Asset_Tracking.Application.Common.Room
{
    public record RoomResponseDto
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; } = null!;
        public int FloorId { get; set; }
        public string CreatedBy { get; set; } = null!;
        public string? UpdatedBy { get; set; }
    }
}
