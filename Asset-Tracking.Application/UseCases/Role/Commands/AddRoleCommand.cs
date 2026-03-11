using Asset_Tracking.Application.Common.Role;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Role.Commands
{
    public record AddRoleCommand(RoleRequestDto Role) : IRequest<RoleResponseDto>;

    public class AddRoleHandler(IRoleRepository roleRepository)
        : IRequestHandler<AddRoleCommand, RoleResponseDto>
    {
        public async Task<RoleResponseDto> Handle(
            AddRoleCommand request,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Role.Name))
                throw new ArgumentException("Role name is required.");

            var entity = new RoleEntity
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Role.Name,
                NormalizedName = request.Role.NormalizedName,
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };

            await roleRepository.AddAsync(entity);

            return new RoleResponseDto
            {
                Id = entity.Id,
                Name = entity.Name,
                NormalizedName = entity.NormalizedName,
                ConcurrencyStamp = entity.ConcurrencyStamp
            };
        }
    }
}
