namespace Asset_Tracking.Application.Common.Dtos.User
{
    public record UserClaimsUpdateRequestDto
    {
        public int Id { get; set; }
        public string? ClaimType { get; set; }
        public string? ClaimValue { get; set; }
    }
}
