namespace Asset_Tracking.Application.Common.Staff
{
    public record StaffRequestDto
    {
        public string StaffId { get; set; } = default!;
        public int? TitleId { get; set; }
        public string Surname { get; set; } = default!;
        public string OtherName { get; set; } = default!;
        public string TechMail { get; set; } = default!;
        public int? SiteId { get; set; }
        public int? BuildingId { get; set; }
        public int? FloorId { get; set; }
        public int? RoomId { get; set; }
        public bool HasRoom { get; set; }
        public string? RoomLocationDescription { get; set; }
    }
}
