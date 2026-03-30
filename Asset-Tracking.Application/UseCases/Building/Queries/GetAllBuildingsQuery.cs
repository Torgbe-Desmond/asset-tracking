using Asset_Tracking.Application.Common.Dtos.Building;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Building.Queries
{
    public record GetAllBuildingsQuery() : IRequest<List<BuildingResponseDto>>;

    public class GetAllBuildingsHandler(IBuildingRepository buildingRepository) : IRequestHandler<GetAllBuildingsQuery, List<BuildingResponseDto>>
    {
        public async Task<List<BuildingResponseDto>> Handle(
            GetAllBuildingsQuery request,
            CancellationToken cancellationToken)
        {
            

           var buildings =  await buildingRepository.GetAllAsync(cancellationToken);

            var dtos = buildings.Select(building =>  new BuildingResponseDto
            {
                BuildingId = building.BuildingId,
                BuildingName = building.BuildingName,
                //CreatedDate = building.CreatedDate,
                CreatedBy = building.CreatedBy,
                //UpdatedDate = building.UpdatedDate,
                UpdatedBy = building.UpdatedBy
            }).ToList();

            return dtos;
        }
    }
}
