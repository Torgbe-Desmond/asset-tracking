namespace Asset_Tracking.Application.Common.Asset
{
    /// <summary>
    /// Represents an image associated with an asset.
    /// </summary>
    public class AssetImageResponseDto
    {
        /// <example>99</example>
        public int AssetImageId { get; set; }

        /// <summary>
        /// The photo data represented as a Base64-encoded string.
        /// </summary>
        /// <example>iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mP8/5+hHgAHggJ/PchI7wAAAABJRU5ErkJggg==</example>
        public byte[] Photo { get; set; } = null!;
    }
}