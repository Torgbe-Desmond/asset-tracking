namespace Asset_Tracking.Application.Common.User
{
    public class UserImageResponseDto
    {
        public int Id { get; set; }
        public byte[] Photo { get; set; } = null!;
    }
}
