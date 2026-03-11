using Asset_Tracking.Application.Common.User;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.User.Queries
{
    public record GetAllUserClaimsQuery(int Id)
        : IRequest<UserClaimsResponseDto>;

    public class GetAllUserClaimsdHandler(IUserClaimRepository userClaimsRepository)
        : IRequestHandler<GetAllUserClaimsQuery, UserClaimsResponseDto>
    {
        public async Task<UserClaimsResponseDto> Handle(GetAllUserClaimsQuery request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0)
                throw new ArgumentException("Id is required.");

            var entity = await userClaimsRepository.GetByIdAsync(request.Id)
                ?? throw new ArgumentException("User claim not found.");

            return new UserClaimsResponseDto
            {
                Id = entity.Id,
                UserId = entity.UserId,
                ClaimType = entity.ClaimType,
                ClaimValue = entity.ClaimValue
            };
        }
    }
}
