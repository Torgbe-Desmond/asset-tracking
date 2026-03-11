using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asset_Tracking.Application.Common.User;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.User.Commands
{
    public record UpdateUserTokenCommand(string UserId, string LoginProvider, string Name, UserTokenUpdateRequestDto UserToken)
         : IRequest<UserTokenResponseDto>;

    public class UpdateUserTokenHandler(IUserTokenRepository userTokenRepository)
        : IRequestHandler<UpdateUserTokenCommand, UserTokenResponseDto>
    {
        public async Task<UserTokenResponseDto> Handle(UpdateUserTokenCommand request, CancellationToken cancellationToken)
        {
            var dto = request.UserToken;

            var entity = await userTokenRepository.GetAsync(
                request.UserId,
                request.LoginProvider,
                request.Name)
                ?? throw new ArgumentException("User token not found.");

            if (!string.IsNullOrWhiteSpace(dto.Value))
                entity.Value = dto.Value;

            await userTokenRepository.UpdateAsync(request.UserId, entity);

            return new UserTokenResponseDto
            {
                LoginProvider = entity.LoginProvider,
                UserId = entity.UserId,
                Name = entity.Name,
                Value = entity.Value
            };
        }
    }
}
