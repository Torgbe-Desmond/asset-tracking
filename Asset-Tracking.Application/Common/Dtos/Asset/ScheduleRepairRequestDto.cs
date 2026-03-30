namespace Asset_Tracking.Application.Common.Dtos.Asset
{
    public record ScheduleRepairRequestDto
    {
        public string RepairTitle { get; set; } = null!;

        public string Details { get; set; } = null!;

        public string? RepairerName { get; set; }

        public string? RepairerContactNumber { get; set; }

        public decimal? Cost { get; set; }

        public string? DateCompleted { get; set; }

        public int RepairStatusId { get; set; }

        public int AssetId { get; set; }

        public int IsScheduleApproved { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime DateCreated { get; set; }

        public string? UpdateBy { get; set; }

        public DateTime? DateUpdated { get; set; }
    }
}