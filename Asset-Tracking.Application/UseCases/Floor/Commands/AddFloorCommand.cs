using Asset_Tracking.Application.Common.Floor;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Floor.Commands
{

    public record AddFloorCommand(FloorRequestDto Floor) : IRequest<FloorResponseDto>;
    public class AddFloorHandler(IFloorRepository floorRepository) : IRequestHandler<AddFloorCommand, FloorResponseDto>
    {
        public async Task<FloorResponseDto> Handle(AddFloorCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Floor;

            if (string.IsNullOrWhiteSpace(dto.FloorName))
                throw new ArgumentException("FloorName is required.", nameof(dto.FloorName));

            if (string.IsNullOrWhiteSpace(dto.CreatedBy))
                throw new ArgumentException("CreatedBy is required.", nameof(dto.CreatedBy));

            if (dto.BuildingId <= 0)
                throw new ArgumentException("Valid BuildingId is required.", nameof(dto.BuildingId));

        
            var entity = new FloorEntity
            {
                FloorName = dto.FloorName.Trim(),
                CreatedDate = DateTime.UtcNow,
                CreatedBy = dto.CreatedBy.Trim(),
                UpdatedDate = dto.UpdatedDate,
                UpdatedBy = dto.UpdatedBy?.Trim()
            };

            await floorRepository.AddAsync(entity, cancellationToken);

            return new FloorResponseDto
            {
                FloorId = entity.FloorId,
                FloorName = entity.FloorName,
                //CreatedDate = entity.CreatedDate,
                CreatedBy = entity.CreatedBy,
                //UpdatedDate = entity.UpdatedDate,
                UpdatedBy = entity.UpdatedBy
            };
        }

       
    }
}
