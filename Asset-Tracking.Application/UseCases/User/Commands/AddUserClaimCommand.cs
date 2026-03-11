using Asset_Tracking.Application.Common.User;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.User.Commands
{
    public record AddUserClaimCommand(UserClaimsRequestDto UserClaim)
       : IRequest<UserClaimsResponseDto>;

    public class AddUserClaimHandler(IUserClaimRepository userClaimsRepository)
        : IRequestHandler<AddUserClaimCommand, UserClaimsResponseDto>
    {
        public async Task<UserClaimsResponseDto> Handle(AddUserClaimCommand request, CancellationToken cancellationToken)
        {
            var dto = request.UserClaim;

            if (string.IsNullOrWhiteSpace(dto.UserId))
                throw new ArgumentException("UserId is required.");

            if (string.IsNullOrWhiteSpace(dto.ClaimType))
                throw new ArgumentException("ClaimType is required.");

            if (string.IsNullOrWhiteSpace(dto.ClaimValue))
                throw new ArgumentException("ClaimValue is required.");

            var entity = new UserClaimsEntity
            {
                UserId = dto.UserId.Trim(),
                ClaimType = dto.ClaimType.Trim(),
                ClaimValue = dto.ClaimValue.Trim()
            };

            await userClaimsRepository.AddAsync(entity);

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
