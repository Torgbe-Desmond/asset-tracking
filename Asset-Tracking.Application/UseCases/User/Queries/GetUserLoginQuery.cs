using Asset_Tracking.Application.Common.User;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.User.Queries
{
    public record GetUserLoginQuery(
         string UserId)
         : IRequest<UserLoginResponseDto>;

    public class GetUserLoginHandler(IUserLoginRepository userLoginRepository)
        : IRequestHandler<GetUserLoginQuery, UserLoginResponseDto>
    {
        public async Task<UserLoginResponseDto> Handle(GetUserLoginQuery request, CancellationToken cancellationToken)
        {

            if (string.IsNullOrWhiteSpace(request.UserId))
                throw new ArgumentException("UserId is required.");

            var entity = await userLoginRepository.GetByIdAsync(request.UserId)

                ?? throw new ArgumentException("User login not found.");

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
