using Asset_Tracking.Application.Common.User;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.User.Queries
{
    public record GetUserRoleQuery(string RoleId, string UserId)
         : IRequest<UserRoleResponseDto>;

    public class GetUserRoleHandler(IUserRolesRepository userRolesRepository)
        : IRequestHandler<GetUserRoleQuery, UserRoleResponseDto>
    {
        public async Task<UserRoleResponseDto> Handle(GetUserRoleQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.RoleId))
                throw new ArgumentException("RoleId is required.");

            if (string.IsNullOrWhiteSpace(request.UserId))
                throw new ArgumentException("UserId is required.");

            var entity = await userRolesRepository.GetAsync(request.RoleId, request.UserId)
                ?? throw new ArgumentException("User role not found.");

            return new UserRoleResponseDto
            {
                RoleId = entity.RoleId,
                UserId = entity.UserId
            };
        }
    }
}
