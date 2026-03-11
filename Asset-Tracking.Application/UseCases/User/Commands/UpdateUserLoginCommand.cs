using Asset_Tracking.Application.Common.User;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.User.Commands
{
    public record UpdateUserLoginCommand(string UserId, UserLoginUpdateRequestDto UserLogin)
         : IRequest<UserLoginResponseDto>;

    public class UpdateUserLoginHandler(IUserLoginRepository userLoginRepository)
        : IRequestHandler<UpdateUserLoginCommand, UserLoginResponseDto>
    {
        public async Task<UserLoginResponseDto> Handle(UpdateUserLoginCommand request, CancellationToken cancellationToken)
        {
            var dto = request.UserLogin;

            if (string.IsNullOrWhiteSpace(dto.LoginProvider))
                throw new ArgumentException("LoginProvider is required.");

            if (string.IsNullOrWhiteSpace(dto.UserId))
                throw new ArgumentException("UserId is required.");

            if (string.IsNullOrWhiteSpace(dto.ProviderKey))
                throw new ArgumentException("ProviderKey is required.");

            var entity = await userLoginRepository.GetByIdAsync(request.UserId)

                ?? throw new ArgumentException("User login not found.");
                
            if (!string.IsNullOrWhiteSpace(dto.ProviderDisplayName))
                entity.ProviderDisplayName = dto.ProviderDisplayName.Trim();

            await userLoginRepository.UpdateAsync(request.UserId, entity);

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
