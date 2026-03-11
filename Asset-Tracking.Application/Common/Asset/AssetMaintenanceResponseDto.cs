namespace Asset_Tracking.Application.Common.Asset
{
    public record AssetMaintenanceResponseDto
    {
        public int AssetMaintenanceId { get; set; }

        public string MaintenanceTitle { get; set; } = null!;

        public string Details { get; set; } = null!;

        public DateTime DateSent { get; set; }

        public string MaintainedBy { get; set; } = null!;

        public DateTime? DateCompleted { get; set; }

        public decimal? Cost { get; set; }

        public string CreatedBy { get; set; } = null!;

        public string? UpdatedBy { get; set; }

        public int MaintenanceStatusId { get; set; }

        public int AssetId { get; set; }

        public AssetDto  Asset { get; set; }
        public MaintenanceStatusResponseDto  MaintenanceStatus {  get; set; }
    }
}
