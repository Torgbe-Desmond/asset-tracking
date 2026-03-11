using Asset_Tracking.Application.Common.User;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.User.Commands
{
    public record CreateUserTokenCommand(UserTokenRequestDto UserToken)
         : IRequest<UserTokenResponseDto>;

    public class CreateUserTokenHandler(IUserTokenRepository userTokenRepository)
        : IRequestHandler<CreateUserTokenCommand, UserTokenResponseDto>
    {
        public async Task<UserTokenResponseDto> Handle(CreateUserTokenCommand request, CancellationToken cancellationToken)
        {
            var dto = request.UserToken;

            if (string.IsNullOrWhiteSpace(dto.LoginProvider))
                throw new ArgumentException("LoginProvider is required.");

            if (string.IsNullOrWhiteSpace(dto.UserId))
                throw new ArgumentException("UserId is required.");

            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new ArgumentException("Token Name is required.");

            var entity = new UserTokenEntity
            {
                LoginProvider = dto.LoginProvider.Trim(),
                UserId = dto.UserId.Trim(),
                Name = dto.Name.Trim(),
                Value = dto.Value
            };

            await userTokenRepository.AddAsync(entity);

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
