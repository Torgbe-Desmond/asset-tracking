using Asset_Tracking.Application.Common.Dtos.RefreshToken;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.RefreshToken.Commands
{
    public record AddRefreshTokenCommand(RefreshTokenRequestDto RefreshToken)
        : IRequest<RefreshTokenResponseDto>;

    public class AddRefreshTokenHandler : IRequestHandler<AddRefreshTokenCommand, RefreshTokenResponseDto>
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public AddRefreshTokenHandler(IRefreshTokenRepository refreshTokenRepository)
        {
            _refreshTokenRepository = refreshTokenRepository ?? throw new ArgumentNullException(nameof(refreshTokenRepository));
        }

        public async Task<RefreshTokenResponseDto> Handle(
            AddRefreshTokenCommand request,
            CancellationToken cancellationToken)
        {
            if (request?.RefreshToken == null)
            {
                throw new ArgumentNullException(nameof(request.RefreshToken));
            }

            var dto = request.RefreshToken;

            // Optional: Add basic validation (you can move to validator pipeline)
            if (string.IsNullOrWhiteSpace(dto.UserId))
            {
                throw new ArgumentException("UserId is required", nameof(dto.UserId));
            }
            if (string.IsNullOrWhiteSpace(dto.GeneratedRefreshToken))
            {
                throw new ArgumentException("Refresh token value is required", nameof(dto.GeneratedRefreshToken));
            }

            var entity = new RefreshTokenEntity
            {
                UserId = dto.UserId,
                GeneratedRefreshToken = dto.GeneratedRefreshToken,              
            };

            await _refreshTokenRepository.AddAsync(entity, cancellationToken);

            return new RefreshTokenResponseDto
            {
                Id = entity.Id,
                UserId = entity.UserId,
                GeneratedRefreshToken = entity.GeneratedRefreshToken,         
           
            };
        }
    }
}