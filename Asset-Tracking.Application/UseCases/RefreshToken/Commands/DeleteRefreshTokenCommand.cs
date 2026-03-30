using System;
using System.Threading;
using System.Threading.Tasks;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.RefreshToken.Commands
{
    public record DeleteRefreshTokenCommand(int Id)
        : IRequest<bool>;

    public class DeleteRefreshTokenHandler(IRefreshTokenRepository refreshTokenRepository) : IRequestHandler<DeleteRefreshTokenCommand, bool>
    {
       
        public async Task<bool> Handle(
            DeleteRefreshTokenCommand request,
            CancellationToken cancellationToken)
        {
           
            var refreshToken = await refreshTokenRepository.GetByIdAsync(request.Id);
            if (refreshToken == null) return false;
                
            return await refreshTokenRepository.DeleteAsync(request.Id, cancellationToken);
        }
    }
}