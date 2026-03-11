using Asset_Tracking.Application.Common.Role;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Role.Commands
{
    public record UpdateRoleClaimCommand(int RoleClaimId, RoleClaimRequestDto RoleClaim)
       : IRequest<RoleClaimResponseDto>;

    public class UpdateRoleClaimHandler(IRoleClaimsRepository roleClaimsRepository)
        : IRequestHandler<UpdateRoleClaimCommand, RoleClaimResponseDto>
    {
        public async Task<RoleClaimResponseDto> Handle(
            UpdateRoleClaimCommand request,
            CancellationToken cancellationToken)
        {
            if (request.RoleClaimId <= 0)
                throw new ArgumentException("RoleClaimId is required.");

            var entity = await roleClaimsRepository.GetByIdAsync(request.RoleClaimId);

            if (entity is null)
                throw new KeyNotFoundException("Role claim not found.");

            entity.RoleId = request.RoleClaim.RoleId;
            entity.ClaimType = request.RoleClaim.ClaimType;
            entity.ClaimValue = request.RoleClaim.ClaimValue;

            await roleClaimsRepository.UpdateAsync(request.RoleClaimId, entity);

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
