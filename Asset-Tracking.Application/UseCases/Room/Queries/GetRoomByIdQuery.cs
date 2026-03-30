using Asset_Tracking.Application.Common.Dtos.Room;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Room.Queries
{

    public record GetRoomByIdQuery(int RoomId) : IRequest<RoomResponseDto>;
    public class GetRoomByIdRoomHandler(IRoomRepository roomRepository) : IRequestHandler<GetRoomByIdQuery, RoomResponseDto>
    {
        public async Task<RoomResponseDto> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
        {

            var allRoom = await roomRepository.GetByIdAsync(request.RoomId);

            return new RoomResponseDto
            {
                RoomId = allRoom.RoomId,
                RoomName = allRoom.RoomName,
                //CreatedDate = allRoom.CreatedDate,
                CreatedBy = allRoom.CreatedBy,
                //UpdatedDate = allRoom.UpdatedDate,
                UpdatedBy = allRoom.UpdatedBy
            };
        }

    }
}
