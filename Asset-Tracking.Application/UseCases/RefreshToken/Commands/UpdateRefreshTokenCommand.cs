using Asset_Tracking.Application.Common.Dtos.RefreshToken;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.RefreshToken.Commands
{
    public record UpdateRefreshTokenCommand(
        int Id,
        RefreshTokenUpdateRequestDto RefreshToken)
        : IRequest<bool>;

    public class UpdateRefreshTokenHandler(IRefreshTokenRepository refreshTokenRepository) : IRequestHandler<UpdateRefreshTokenCommand, bool>
    {
        public async Task<bool> Handle(
            UpdateRefreshTokenCommand request,
            CancellationToken cancellationToken)
        {

            var dto = request.RefreshToken;

            var existing = await refreshTokenRepository.GetByIdAsync(request.Id);
            if (existing == null)
            {
                return false;
            }

            existing.GeneratedRefreshToken = dto.GeneratedRefreshToken ?? existing.GeneratedRefreshToken;
      
            return await refreshTokenRepository.UpdateAsync(request.Id, existing, cancellationToken);
        }
    }
}