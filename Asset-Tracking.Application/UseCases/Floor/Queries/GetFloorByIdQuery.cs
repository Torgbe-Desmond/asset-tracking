using Asset_Tracking.Application.Common.Floor;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Floor.Queries
{


    public record GetFloorByIdQuery(int FloorId) : IRequest<FloorResponseDto>;
    public class GetFloorByIdHandler(IFloorRepository floorRepository) : IRequestHandler<GetFloorByIdQuery, FloorResponseDto>
    {
        public async Task<FloorResponseDto> Handle(GetFloorByIdQuery request, CancellationToken cancellationToken)
        {

            var floor = await floorRepository.GetByIdAsync(request.FloorId,cancellationToken);

            return new FloorResponseDto
            {
                FloorId = floor.FloorId,
                FloorName = floor.FloorName,
                //CreatedDate = floor.CreatedDate,
                CreatedBy = floor.CreatedBy,
                //UpdatedDate = floor.UpdatedDate,
                UpdatedBy = floor.UpdatedBy

            };
        }


    }
}
