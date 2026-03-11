using Asset_Tracking.Application.Common.Building;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Building.Commands
{

    public record UpdateBuildingCommand(int BuildingId, BuildingRequestDto Building) : IRequest<bool>;

    public class UpdateBuildingHandler(IBuildingRepository buildingRepository) : IRequestHandler<UpdateBuildingCommand, bool>
    {

        public async Task<bool> Handle(UpdateBuildingCommand request, CancellationToken cancellationToken)
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

            return await buildingRepository.UpdateAsync(request.BuildingId, entity, cancellationToken);

        }    
       
    }
}
