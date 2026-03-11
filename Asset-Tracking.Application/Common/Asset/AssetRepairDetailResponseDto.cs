namespace Asset_Tracking.Application.Common.Asset
{
    public record AssetRepairDetailResponseDto
    {
        public int AssetRepairId { get; init; }

        public string RepairTitle { get; init; } = null!;
        public string Details { get; init; } = null!;

        public string? RepairerName { get; init; }
        public string? RepairerContactNumber { get; init; }
        public decimal? Cost { get; init; }
        public string? DateCompleted { get; init; }

        public string CreatedBy { get; init; } = null!;
        public string? UpdateBy { get; init; }
        public int RepairStatusId { get; init; }
        public int AssetId { get; init; }

        public DateTime? AssetReceiveDate { get; init; }
        public string? ReceivedBy { get; init; }

        public AssetDto Asset { get; init; }

        public RepairStatusResponseDto RepairStatus { get; init; }
    }
}
