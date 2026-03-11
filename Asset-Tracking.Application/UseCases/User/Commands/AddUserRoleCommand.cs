using Asset_Tracking.Application.Common.User;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.User.Commands
{
    public record AddUserRoleCommand(UserRoleRequestDto UserRole)
        : IRequest<UserRoleResponseDto>;

    public class AddUserRoleHandler(IUserRolesRepository userRolesRepository)
        : IRequestHandler<AddUserRoleCommand, UserRoleResponseDto>
    {
        public async Task<UserRoleResponseDto> Handle(AddUserRoleCommand request, CancellationToken cancellationToken)
        {
            var dto = request.UserRole;

            if (string.IsNullOrWhiteSpace(dto.RoleId))
                throw new ArgumentException("RoleId is required.");

            if (string.IsNullOrWhiteSpace(dto.UserId))
                throw new ArgumentException("UserId is required.");

            var entity = new UserRolesEntity
            {
                RoleId = dto.RoleId.Trim(),
                UserId = dto.UserId.Trim()
            };

            await userRolesRepository.AddAsync(entity);

            return new UserRoleResponseDto
            {
                RoleId = entity.RoleId,
                UserId = entity.UserId
            };
        }
    }
}
