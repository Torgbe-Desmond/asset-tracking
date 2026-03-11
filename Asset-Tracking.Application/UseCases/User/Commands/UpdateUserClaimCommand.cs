using Asset_Tracking.Application.Common.User;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.User.Commands
{
    public record UpdateUserClaimCommand(int Id, UserClaimsUpdateRequestDto UserClaim)
        : IRequest<UserClaimsResponseDto>;

    public class UpdateUserClaimHandler(IUserClaimRepository userClaimsRepository)
        : IRequestHandler<UpdateUserClaimCommand, UserClaimsResponseDto>
    {
        public async Task<UserClaimsResponseDto> Handle(UpdateUserClaimCommand request, CancellationToken cancellationToken)
        {
            var dto = request.UserClaim;

            if (dto.Id <= 0)
                throw new ArgumentException("Id is required.");

            var entity = await userClaimsRepository.GetByIdAsync(dto.Id)
                ?? throw new ArgumentException("User claim not found.");

            if (!string.IsNullOrWhiteSpace(dto.ClaimType))
                entity.ClaimType = dto.ClaimType.Trim();

            if (!string.IsNullOrWhiteSpace(dto.ClaimValue))
                entity.ClaimValue = dto.ClaimValue.Trim();

            await userClaimsRepository.UpdateAsync(request.Id,entity);

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
