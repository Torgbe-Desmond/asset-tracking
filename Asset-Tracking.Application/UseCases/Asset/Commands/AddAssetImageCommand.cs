using Asset_Tracking.Application.Common.Asset;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Commands
{
    public record AddAssetImageCommand(AssetImageRequestDto AssetImage) : IRequest<AssetImageResponseDto>;
    public class AddAssetImageHandler(IAssetImageRepository imageRepository) : IRequestHandler<AddAssetImageCommand, AssetImageResponseDto>
    {
        public async Task<AssetImageResponseDto> Handle(
            AddAssetImageCommand request,
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

            await imageRepository.AddAsync(entity, cancellationToken);

            return new AssetImageResponseDto
            {
                AssetImageId = entity.AssetImageId,
                Photo = entity.Photo,          
            };
        }
    }




}