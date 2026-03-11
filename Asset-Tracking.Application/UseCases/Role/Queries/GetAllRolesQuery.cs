using Asset_Tracking.Application.Common.Role;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Role.Queries
{


    public record GetAllRolesQuery()
     : IRequest<List<RoleResponseDto>>;

    public class GetAllRolesQueryHandler(IRoleRepository roleRepository)
        : IRequestHandler<GetAllRolesQuery, List<RoleResponseDto>>
    {
        public async Task<List<RoleResponseDto>> Handle(
            GetAllRolesQuery request,
            CancellationToken cancellationToken)
        {
            var roles = await roleRepository.GetAllAsync();

            var dtos = roles.Select(role =>  new RoleResponseDto
            {
                Id = role.Id,
                Name = role.Name,
                NormalizedName = role.NormalizedName,
                ConcurrencyStamp = role.ConcurrencyStamp
            }).ToList();

            return dtos;
        }
    }
}
