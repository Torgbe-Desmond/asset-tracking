using Asset_Tracking.Application.Common.User;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.User.Commands
{
    public record AddUserCommand(UserRequestDto User)
        : IRequest<UserResponseDto>;

    public class AddUserHandler(IUserRepository userRepository)
        : IRequestHandler<AddUserCommand, UserResponseDto>
    {
        public async Task<UserResponseDto> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var dto = request.User;

            if (string.IsNullOrWhiteSpace(dto.Id))
                throw new ArgumentException("Id is required.");

            var entity = new UserEntity
            {
                Id = dto.Id.Trim(),
                FirstName = dto.FirstName?.Trim(),
                LastName = dto.LastName?.Trim(),
                TitleId = dto.TitleId,
                UserImageId = dto.UserImageId,
                StaffId = dto.StaffId,
                UserName = dto.UserName?.Trim(),
                NormalizedUserName = dto.NormalizedUserName?.Trim(),
                Email = dto.Email?.Trim(),
                NormalizedEmail = dto.NormalizedEmail?.Trim(),
                EmailConfirmed = dto.EmailConfirmed,
                PasswordHash = dto.PasswordHash,
                SecurityStamp = dto.SecurityStamp,
                ConcurrencyStamp = dto.ConcurrencyStamp,
                PhoneNumber = dto.PhoneNumber?.Trim(),
                PhoneNumberConfirmed = dto.PhoneNumberConfirmed,
                TwoFactorEnabled = dto.TwoFactorEnabled
            };

            await userRepository.AddAsync(entity);

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
