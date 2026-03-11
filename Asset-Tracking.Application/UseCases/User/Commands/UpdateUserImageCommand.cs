using Asset_Tracking.Application.Common.User;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.User.Commands
{
    public record UpdateUserImageCommand(int Id, UserImageUpdateRequestDto UserImage)
          : IRequest<UserImageResponseDto>;

    public class UpdateUserImageHandler(IUserImageRepository userImageRepository)
        : IRequestHandler<UpdateUserImageCommand, UserImageResponseDto>
    {
        public async Task<UserImageResponseDto> Handle(UpdateUserImageCommand request, CancellationToken cancellationToken)
        {
            var dto = request.UserImage;

            if (dto.PhotoFile == null)
                throw new ArgumentException("Photo file is required and cannot be empty.");

            // Optional: validate file type / size
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var extension = Path.GetExtension(dto.PhotoFile.Name.ToLowerInvariant());
            if (!allowedExtensions.Contains(extension))
                throw new ArgumentException("Invalid file type. Only JPG, JPEG, PNG, GIF allowed.");

            if (dto.PhotoFile.Length > 5 * 1024 * 1024) // 5MB limit example
                throw new ArgumentException("File size exceeds 5MB limit.");

            // Read file to byte[]
            byte[] photoBytes;
            using (var memoryStream = new MemoryStream())
            {
                await dto.PhotoFile.CopyToAsync(memoryStream, cancellationToken);
                photoBytes = memoryStream.ToArray();
            }

            var entity = new UserImageEntity
            {
                Photo = photoBytes,
            };

            await userImageRepository.UpdateAsync(request.Id, entity);

            return new UserImageResponseDto
            {
                Id = entity.Id,
                Photo = entity.Photo
            };
        }
    }
}
