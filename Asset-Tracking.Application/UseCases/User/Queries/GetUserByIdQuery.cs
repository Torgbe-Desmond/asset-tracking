using Asset_Tracking.Application.Common.User;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.User.Queries
{
    public record GetUserByIdQuery(string Id)
         : IRequest<UserResponseDto>;

    public class GetUserByIdHandler(IUserRepository userRepository)
        : IRequestHandler<GetUserByIdQuery, UserResponseDto>
    {
        public async Task<UserResponseDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Id))
                throw new ArgumentException("Id is required.");

            var entity = await userRepository.GetByIdAsync(request.Id)
                ?? throw new ArgumentException("User not found.");

            return new UserResponseDto
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                TitleId = entity.TitleId,
                UserImageId = entity.UserImageId,
                StaffId = entity.StaffId,
                UserName = entity.UserName,
                NormalizedUserName = entity.NormalizedUserName,
                Email = entity.Email,
                NormalizedEmail = entity.NormalizedEmail,
                EmailConfirmed = entity.EmailConfirmed,
                PhoneNumber = entity.PhoneNumber,
                PhoneNumberConfirmed = entity.PhoneNumberConfirmed,
                TwoFactorEnabled = entity.TwoFactorEnabled
            };
        }
    }
}
