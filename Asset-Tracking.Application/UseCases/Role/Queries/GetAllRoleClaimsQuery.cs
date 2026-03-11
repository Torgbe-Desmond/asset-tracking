using Asset_Tracking.Application.Common.Role;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Role.Queries
{


    public record GetAllRoleClaimsQuery(int RoleClaimId)
       : IRequest<List<RoleClaimResponseDto>>;

    public class GetRoleClaimsHandler(IRoleClaimsRepository roleClaimsRepository)
        : IRequestHandler<GetAllRoleClaimsQuery, List<RoleClaimResponseDto>>
    {
        public async Task<List<RoleClaimResponseDto>> Handle(
            GetAllRoleClaimsQuery request,
            CancellationToken cancellationToken)
        {
            var allRoleClaims = await roleClaimsRepository.GetAllAsync(cancellationToken);

            var dtos = allRoleClaims.Select(allRoleClaim => new RoleClaimResponseDto
            {
                Id = allRoleClaim.Id,
                RoleId = allRoleClaim.RoleId,
                ClaimType = allRoleClaim.ClaimType,
                ClaimValue = allRoleClaim.ClaimValue
            }).ToList();

            return dtos;
        }
    }
}
