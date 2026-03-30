namespace Asset_Tracking.Application.Common.Dtos.Asset
{
    /// <summary>
    /// Request DTO for creating or updating asset category data.
    /// </summary>
    public record AssetCategoryRequestDto
    {
        /// <example>Laptops & Computers</example>
        public string AssetCategoryName { get; set; } = null!;

        /// <example>2026-02-10T10:15:00</example>
        public DateTime DateCreated { get; set; }

        /// <example>inventory_admin</example>
        public string CreatedBy { get; set; } = null!;

        /// <example>2026-02-12T16:20:00</example>
        public DateTime? DateUpdated { get; set; }

        /// <example>inventory_manager</example>
        public string? UpdatedBy { get; set; }
    }
}