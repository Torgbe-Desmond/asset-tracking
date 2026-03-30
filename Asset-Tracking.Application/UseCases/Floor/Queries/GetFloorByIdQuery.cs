using Asset_Tracking.Application.Common.Dtos.Floor;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Floor.Queries
{


    public record GetFloorByIdQuery(int FloorId) : IRequest<FloorResponseDto?>;
    public class GetFloorByIdHandler(IFloorRepository floorRepository) : IRequestHandler<GetFloorByIdQuery, FloorResponseDto?>
    {
        public async Task<FloorResponseDto?> Handle(GetFloorByIdQuery request, CancellationToken cancellationToken)
        {

            var floor = await floorRepository.GetByIdAsync(request.FloorId,cancellationToken);

            if (floor == null) return null;

            return new FloorResponseDto
            {
                FloorId = floor.FloorId,
                FloorName = floor.FloorName,
                CreatedBy = floor.CreatedBy,
                UpdatedBy = floor.UpdatedBy

            };
        }


    }
}
