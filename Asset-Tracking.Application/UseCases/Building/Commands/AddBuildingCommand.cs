using Asset_Tracking.Application.Common.Dtos.Building;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Building.Commands
{
    public record AddBuildingCommand(BuildingRequestDto Building) : IRequest<BuildingResponseDto>;
  
    public class AddBuildingHandler(IBuildingRepository buildingRepository) : IRequestHandler<AddBuildingCommand, BuildingResponseDto>
    {
       
        public async Task<BuildingResponseDto> Handle(
            AddBuildingCommand request,
            CancellationToken cancellationToken)
        {
            var dto = request.Building;

            // Basic validation
            if (string.IsNullOrWhiteSpace(dto.CreatedBy))
                throw new ArgumentException("CreatedBy is required.");

            // Optional: enforce building name uniqueness or non-empty
            if (!string.IsNullOrWhiteSpace(dto.BuildingName))
            {
                dto.BuildingName = dto.BuildingName.Trim();
              
            }

            var entity = new BuildingEntity
            {
                BuildingName = dto.BuildingName,  
                CreatedDate = DateTime.UtcNow,
                CreatedBy = dto.CreatedBy.Trim(),
                UpdatedDate = dto.UpdatedDate,
                UpdatedBy = dto.UpdatedBy?.Trim()
            };

            await buildingRepository.AddAsync(entity, cancellationToken);

            return new BuildingResponseDto
            {
                BuildingId = entity.BuildingId,
                BuildingName = entity.BuildingName,
                //CreatedDate = entity.CreatedDate,
                CreatedBy = entity.CreatedBy,
                //UpdatedDate = entity.UpdatedDate,
                UpdatedBy = entity.UpdatedBy
            };
        }
    }
}
