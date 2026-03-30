namespace Asset_Tracking.Application.Common.Dtos.Asset
{
    public record AssetRepairRequestDto
    {
        //  AssetRepairId int[pk, increment]
        //  RepairTitle nvarchar(150)
        //  Details nvarchar(max)
        //  RepairerName nvarchar(150) [null]
        //  RepairerContactNumber nvarchar(15) [null]
        //  Cost numeric(10,2) [null]
        //  DateCompleted nvarchar(50) [null]
        //  CreatedBy nvarchar(100)
        //  DateCreated datetime
        //  UpdateBy nvarchar(100) [null]
        //  DateUpdated datetime[null]
        //  RepairStatusId int
        //  AssetId int
        //  AssetReceiveDate datetime[null]
        //  ReceivedBy nvarchar(100) [null]
        public string RepairTitle { get; init; } = null!;
        public string Details { get; init; } = null!;
        public string? RepairerName { get; init; }
        public string? RepairerContactNumber { get; init; }
        public decimal? Cost { get; init; }
        public string? DateCompleted { get; init; }
        public int RepairStatusId { get; init; }
        public int AssetId { get; init; }
        public string? CreatedBy { get; init; }
        public DateTime DateCreated { get; init; } = DateTime.UtcNow;
        public string? UpdatedBy { get; init; }
        public DateTime? DateUpdated { get; init; }
        public DateTime? AssetReceiveDate { get; init; }
        public string? ReceivedBy { get; init; }
    }
}
