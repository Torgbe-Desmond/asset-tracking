namespace Asset_Tracking.Application.Common.Dtos.User
{
    /// <summary>
    /// Represents a Data Transfer Object for delivering user profile images.
    /// </summary>
    public class UserImageResponseDto
    {
        /// <summary>
        /// Gets or sets the unique identifier associated with the user or image record.
        /// </summary>
        public int UserImageId { get; set; }

        /// <summary>
        /// Gets or sets the binary content of the user's photo.
        /// </summary>
        public byte[] Photo { get; set; } = null!;
    }
}