using Asset_Tracking.Application.Common.Dtos.User;
using Asset_Tracking.Domain.Entities;

namespace Asset_Tracking.Application.Common.Dtos.Auth
{
    public record AuthResponse(string Token, UserDto User);
}
