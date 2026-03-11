using Asset_Tracking.Application.Common.User;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.User.Queries
{
   
    public record GetUserTokenQuery(string UserId, string LoginProvider, string Name, UserTokenUpdateRequestDto UserToken)
         : IRequest<UserTokenResponseDto>;

    public class GetUserTokenHandler(IUserTokenRepository userTokenRepository)
        : IRequestHandler<GetUserTokenQuery, UserTokenResponseDto>
    {
        public async Task<UserTokenResponseDto> Handle(GetUserTokenQuery request, CancellationToken cancellationToken)
        {
            var dto = request.UserToken;

            var entity = await userTokenRepository.GetAsync(
                request.UserId,
                request.LoginProvider,
                request.Name)
                ?? throw new ArgumentException("User token not found.");

            if (!string.IsNullOrWhiteSpace(dto.Value))
                entity.Value = dto.Value;

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
