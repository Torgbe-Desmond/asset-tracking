using Asset_Tracking.Application.Common.Dtos.Room;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Room.Commands
{
    public record AddRoomCommand(RoomRequestDto Room) : IRequest<RoomResponseDto>;
    public class AddRoomHandler(IRoomRepository roomRepository) : IRequestHandler<AddRoomCommand, RoomResponseDto>
    {
        public async Task<RoomResponseDto> Handle(AddRoomCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Room;

            // Basic validation
            if (string.IsNullOrWhiteSpace(dto.RoomName))
                throw new ArgumentException("RoomName is required.", nameof(dto.RoomName));

            if (string.IsNullOrWhiteSpace(dto.CreatedBy))
                throw new ArgumentException("CreatedBy is required.", nameof(dto.CreatedBy));

            if (dto.FloorId <= 0)
                throw new ArgumentException("Valid FloorId is required.", nameof(dto.FloorId));

            var entity = new RoomEntity
            {
                RoomName = dto.RoomName.Trim(),
                CreatedDate = DateTime.UtcNow,
                CreatedBy = dto.CreatedBy.Trim(),
                UpdatedDate = dto.UpdatedDate,
                UpdatedBy = dto.UpdatedBy?.Trim()
            };

            await roomRepository.AddAsync(entity, cancellationToken);

            return new RoomResponseDto
            {
                RoomId = entity.RoomId,
                RoomName = entity.RoomName,
                //CreatedDate = entity.CreatedDate,
                CreatedBy = entity.CreatedBy,
                //UpdatedDate = entity.UpdatedDate,
                UpdatedBy = entity.UpdatedBy
            };
        }

    }
}
