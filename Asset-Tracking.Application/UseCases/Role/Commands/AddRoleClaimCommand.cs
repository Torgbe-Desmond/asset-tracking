using Asset_Tracking.Application.Common.Role;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Role.Commands
{
    public record AddRoleClaimCommand(RoleClaimRequestDto RoleClaim)
         : IRequest<RoleClaimResponseDto>;

    public class AddRoleClaimHandler(IRoleClaimsRepository roleClaimsRepository)
        : IRequestHandler<AddRoleClaimCommand, RoleClaimResponseDto>
    {
        public async Task<RoleClaimResponseDto> Handle(
            AddRoleClaimCommand request,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.RoleClaim.RoleId))
                throw new ArgumentException("RoleId is required.");

            var entity = new RoleClaimsEntity
            {
                RoleId = request.RoleClaim.RoleId,
                ClaimType = request.RoleClaim.ClaimType,
                ClaimValue = request.RoleClaim.ClaimValue
            };

            await roleClaimsRepository.AddAsync(entity);

            return new RoleClaimResponseDto
            {
                Id = entity.Id,
                RoleId = entity.RoleId,
                ClaimType = entity.ClaimType,
                ClaimValue = entity.ClaimValue
            };
        }
    }
}
