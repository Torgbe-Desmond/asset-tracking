using Asset_Tracking.Application.Common.Dtos.RefreshToken;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.RefreshToken.Queries
{
    public record GetRefreshTokenByIdQuery(int Id)
        : IRequest<RefreshTokenResponseDto?>;

    public class GetRefreshTokenByIdHandler(IRefreshTokenRepository refreshTokenRepository) : IRequestHandler<GetRefreshTokenByIdQuery, RefreshTokenResponseDto?>
    {
        public async Task<RefreshTokenResponseDto?> Handle(
            GetRefreshTokenByIdQuery request,
            CancellationToken cancellationToken)
        {
         
            var refreshToken = await refreshTokenRepository.GetByIdAsync(request.Id);

            if (refreshToken == null)
            {
                return null;
            }

            return new RefreshTokenResponseDto
            {
                Id = refreshToken.Id,
                UserId = refreshToken.UserId,
                GeneratedRefreshToken = refreshToken.GeneratedRefreshToken,     
            };
        }
    }
}