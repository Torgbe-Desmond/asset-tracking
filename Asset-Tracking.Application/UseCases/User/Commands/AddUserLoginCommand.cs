using Asset_Tracking.Application.Common.User;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.User.Commands
{
    public record AddUserLoginCommand(UserLoginRequestDto UserLogin)
       : IRequest<UserLoginResponseDto>;

    public class AddUserLoginHandler(IUserLoginRepository userLoginRepository)
        : IRequestHandler<AddUserLoginCommand, UserLoginResponseDto>
    {
        public async Task<UserLoginResponseDto> Handle(AddUserLoginCommand request, CancellationToken cancellationToken)
        {
            var dto = request.UserLogin;

            if (string.IsNullOrWhiteSpace(dto.LoginProvider))
                throw new ArgumentException("LoginProvider is required.");

            if (string.IsNullOrWhiteSpace(dto.UserId))
                throw new ArgumentException("UserId is required.");

            if (string.IsNullOrWhiteSpace(dto.ProviderKey))
                throw new ArgumentException("ProviderKey is required.");

            var entity = new UserLoginEntity
            {
                LoginProvider = dto.LoginProvider.Trim(),
                UserId = dto.UserId.Trim(),
                ProviderKey = dto.ProviderKey.Trim(),
                ProviderDisplayName = dto.ProviderDisplayName?.Trim()
            };

            await userLoginRepository.AddAsync(entity);

            return new UserLoginResponseDto
            {
                LoginProvider = entity.LoginProvider,
                UserId = entity.UserId,
                ProviderKey = entity.ProviderKey,
                ProviderDisplayName = entity.ProviderDisplayName
            };
        }
    }
}
