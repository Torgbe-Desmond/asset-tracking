namespace Asset_Tracking.Application.Common.Dtos.Asset
{
    public record AssetCategoryResponseDto
    {
        /// <summary>
        /// The unique identifier for the asset category.
        /// </summary>
        /// <example>1</example>
        public int AssetCategoryId { get; set; }

        /// <summary>
        /// The name of the category (e.g., Laptop, Furniture).
        /// </summary>
        /// <example>Electronics</example>
        public string AssetCategoryName { get; set; } = null!;

        /// <summary>
        /// The user who created the category.
        /// </summary>
        /// <example>admin_user</example>
        public string CreatedBy { get; set; } = null!;

        /// <summary>
        /// The user who last updated the category, if applicable.
        /// </summary>
        /// <example>null</example>
        public string? UpdatedBy { get; set; }
    }
}