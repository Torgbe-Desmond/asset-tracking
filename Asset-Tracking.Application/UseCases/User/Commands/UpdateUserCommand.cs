using Asset_Tracking.Application.Common.User;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.User.Commands
{
    public record UpdateUserCommand(string Id, UserUpdateRequestDto User)
          : IRequest<UserResponseDto>;

    public class UpdateUserHandler(IUserRepository userRepository)
        : IRequestHandler<UpdateUserCommand, UserResponseDto>
    {
        public async Task<UserResponseDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var dto = request.User;

            if (string.IsNullOrWhiteSpace(dto.Id))
                throw new ArgumentException("Id is required.");

            var entity = await userRepository.GetByIdAsync(dto.Id)
                ?? throw new ArgumentException("User not found.");

            entity.FirstName = dto.FirstName?.Trim();
            entity.LastName = dto.LastName?.Trim();
            entity.TitleId = dto.TitleId;
            entity.UserImageId = dto.UserImageId;
            entity.StaffId = dto.StaffId;
            entity.UserName = dto.UserName?.Trim();
            entity.NormalizedUserName = dto.NormalizedUserName?.Trim();
            entity.Email = dto.Email?.Trim();
            entity.NormalizedEmail = dto.NormalizedEmail?.Trim();
            entity.EmailConfirmed = dto.EmailConfirmed;
            entity.PasswordHash = dto.PasswordHash;
            entity.SecurityStamp = dto.SecurityStamp;
            entity.ConcurrencyStamp = dto.ConcurrencyStamp;
            entity.PhoneNumber = dto.PhoneNumber?.Trim();
            entity.PhoneNumberConfirmed = dto.PhoneNumberConfirmed;
            entity.TwoFactorEnabled = dto.TwoFactorEnabled;

            await userRepository.UpdateAsync(request.Id, entity);

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
