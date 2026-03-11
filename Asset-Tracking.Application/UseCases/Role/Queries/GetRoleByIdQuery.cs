using Asset_Tracking.Application.Common.Role;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Role.Queries
{
    public record GetRoleByIdQuery(string RoleId)
       : IRequest<RoleResponseDto>;

    public class GetRoleByIdHandler(IRoleRepository roleRepository)
        : IRequestHandler<GetRoleByIdQuery, RoleResponseDto>
    {
        public async Task<RoleResponseDto> Handle(
            GetRoleByIdQuery request,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.RoleId))
                throw new ArgumentException("RoleId is required.");

            var entity = await roleRepository.GetByIdAsync(request.RoleId);

            if (entity is null)
                throw new KeyNotFoundException("Role not found.");

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
