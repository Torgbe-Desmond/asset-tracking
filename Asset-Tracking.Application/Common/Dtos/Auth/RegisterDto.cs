namespace Asset_Tracking.Application.Common.Dtos.Auth
{
    public record RegisterDto
    {
       public string Email { get; set; }
       public string Password { get; set; }
       public string Role { get; set; } = null!;
    };

}
