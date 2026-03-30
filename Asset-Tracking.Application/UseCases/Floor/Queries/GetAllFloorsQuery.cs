using Asset_Tracking.Application.Common.Dtos.Floor;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Floor.Queries
{

    public record GetAllFloorsQuery() : IRequest<List<FloorResponseDto>>;
    public class GetAllFloorsHandler(IFloorRepository floorRepository) : IRequestHandler<GetAllFloorsQuery, List<FloorResponseDto>>
    {
        public async Task<List<FloorResponseDto>> Handle(GetAllFloorsQuery request, CancellationToken cancellationToken)
        {
          
            var allFloors  = await floorRepository.GetAllAsync();

            var dtos = allFloors.Select(floor=>  new FloorResponseDto
            {
                FloorId = floor.FloorId,
                FloorName = floor.FloorName,
                //CreatedDate = floor.CreatedDate,
                CreatedBy = floor.CreatedBy,
                //UpdatedDate = floor.UpdatedDate,
                UpdatedBy = floor.UpdatedBy

            }).ToList();

            return dtos;
        }


    }
}
