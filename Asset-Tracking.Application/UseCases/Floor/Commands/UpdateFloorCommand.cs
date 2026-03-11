using Asset_Tracking.Application.Common.Floor;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Floor.Commands
{
    public record UpdateFloorCommand(int FloorId, FloorRequestDto Floor) : IRequest<bool>;
    public class UpdateFloorHandler(IFloorRepository floorRepository) : IRequestHandler<UpdateFloorCommand, bool>
    {
        public async Task<bool> Handle(UpdateFloorCommand request, CancellationToken cancellationToken)
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
            
            return await floorRepository.UpdateAsync(request.FloorId ,entity, cancellationToken);
        }

        
    }
}
