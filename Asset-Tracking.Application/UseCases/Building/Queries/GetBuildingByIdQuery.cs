using Asset_Tracking.Application.Common.Dtos.Building;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Building.Queries
{
    public record GetBuildingByIdQuery(int Id) : IRequest<BuildingResponseDto?>;

    public class GetBuildingByIdHandler(IBuildingRepository _buildingRepository) : IRequestHandler<GetBuildingByIdQuery, BuildingResponseDto?>
    {
        public async Task<BuildingResponseDto?> Handle(GetBuildingByIdQuery request, CancellationToken cancellationToken)
        {
            var building = await _buildingRepository.GetByIdAsync(request.Id);

            if (building == null) return null;

            return new BuildingResponseDto
            {
                BuildingId = building.BuildingId,
                BuildingName = building.BuildingName,
                CreatedBy = building.CreatedBy,
                UpdatedBy = building.UpdatedBy
            };
        }
    }
}
