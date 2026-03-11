using Asset_Tracking.Application.Common.Role;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Role.Queries
{
    public record GetRoleClaimByIdQuery(int RoleClaimId)
          : IRequest<RoleClaimResponseDto>;

    public class GetRoleClaimByIdHandler(IRoleClaimsRepository roleClaimsRepository)
        : IRequestHandler<GetRoleClaimByIdQuery, RoleClaimResponseDto>
    {
        public async Task<RoleClaimResponseDto> Handle(
            GetRoleClaimByIdQuery request,
            CancellationToken cancellationToken)
        {
            if (request.RoleClaimId <= 0)
                throw new ArgumentException("RoleClaimId is required.");

            var entity = await roleClaimsRepository.GetByIdAsync(request.RoleClaimId);

            if (entity is null)
                throw new KeyNotFoundException("Role claim not found.");

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
