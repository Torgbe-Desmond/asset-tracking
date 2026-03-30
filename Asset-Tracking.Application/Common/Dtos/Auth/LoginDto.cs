namespace Asset_Tracking.Application.Common.Dtos.Auth
{
  
    public record LoginDto
    {
       public string Email { set; get; } 
       public  string Password { set; get; }
    };
}
