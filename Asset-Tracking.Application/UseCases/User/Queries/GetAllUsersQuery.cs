using Asset_Tracking.Application.Common.User;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.User.Queries
{
    public record GetAllUsersQuery(string Id)
       : IRequest<List<UserResponseDto>>;

    public class GetAllUsersHandler(IUserRepository userRepository)
        : IRequestHandler<GetAllUsersQuery, List<UserResponseDto>>
    {
        public async Task<List<UserResponseDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var allUsers = await userRepository.GetAllAsync();

            var dtos = allUsers.Select(allUser=> new UserResponseDto
            {
                Id = allUser.Id,
                FirstName = allUser.FirstName,
                LastName = allUser.LastName,
                TitleId = allUser.TitleId,
                UserImageId = allUser.UserImageId,
                StaffId = allUser.StaffId,
                UserName = allUser.UserName,
                NormalizedUserName = allUser.NormalizedUserName,
                Email = allUser.Email,
                NormalizedEmail = allUser.NormalizedEmail,
                EmailConfirmed = allUser.EmailConfirmed,
                PhoneNumber = allUser.PhoneNumber,
                PhoneNumberConfirmed = allUser.PhoneNumberConfirmed,
                TwoFactorEnabled = allUser.TwoFactorEnabled
            }).ToList();

            return dtos;
        }
    }
}
