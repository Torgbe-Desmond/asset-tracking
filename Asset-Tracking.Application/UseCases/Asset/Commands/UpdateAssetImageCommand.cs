using Asset_Tracking.Application.Common.Dtos.Asset;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Commands
{


    public record UpdateAssetImageCommand(int AssetImageId,AssetImageRequestDto AssetImage) : IRequest<bool>;
    public class UpdateAssetImageHandler(IAssetImageRepository imageRepository) : IRequestHandler<UpdateAssetImageCommand, bool>
    {
        public async Task<bool> Handle(
            UpdateAssetImageCommand request,
            CancellationToken cancellationToken)
        {
            var dto = request.AssetImage;

            if (dto.PhotoFile == null)
                throw new ArgumentException("Photo file is required and cannot be empty.");

            // Optional: validate file type / size
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var extension = Path.GetExtension((dto.PhotoFile.Name).ToLowerInvariant());
            if (!allowedExtensions.Contains(extension))
                throw new ArgumentException("Invalid file type. Only JPG, JPEG, PNG, GIF allowed.");

            if (dto.PhotoFile.Length > 5 * 1024 * 1024) // 5MB limit example
                throw new ArgumentException("File size exceeds 5MB limit.");

            var existingEntity = await imageRepository.GetByIdAsync(request.AssetImageId, cancellationToken);
            if (existingEntity == null)
                throw new KeyNotFoundException($"AssetImage with ID {request.AssetImageId} not found.");

            // Read file to byte[]
            byte[] photoBytes;
            using (var memoryStream = new MemoryStream())
            {
                await dto.PhotoFile.CopyToAsync(memoryStream, cancellationToken);
                photoBytes = memoryStream.ToArray();
            }

            var entity = new AssetImageEntity
            {
                Photo = photoBytes,
            };

            return await imageRepository.UpdateAsync(request.AssetImageId, entity, cancellationToken);

           
        }
    }

}
