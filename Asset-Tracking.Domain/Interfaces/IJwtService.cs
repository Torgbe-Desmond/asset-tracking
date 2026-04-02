using Asset_Tracking.Domain.Entities;

namespace Asset_Tracking.Domain.Interfaces
{
    public interface IJwtService

    {
        string GenerateToken(ApplicationUser user);

    }
}
