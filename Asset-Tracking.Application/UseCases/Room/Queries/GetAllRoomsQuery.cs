using Asset_Tracking.Application.Common.Dtos.Room;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Room.Queries
{


    public record GetAllRoomsQuery() : IRequest<List<RoomResponseDto>>;
    public class GetAllRoomsRoomHandler(IRoomRepository roomRepository) : IRequestHandler<GetAllRoomsQuery, List<RoomResponseDto>>
    {
        public async Task<List<RoomResponseDto>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
        {
          
            var allRooms =  await roomRepository.GetAllAsync();

            var dtos = allRooms.Select(allRoom => new RoomResponseDto
            {
                RoomId = allRoom.RoomId,
                RoomName = allRoom.RoomName,
                //CreatedDate = allRoom.CreatedDate,
                CreatedBy = allRoom.CreatedBy,
                //UpdatedDate = allRoom.UpdatedDate,
                UpdatedBy = allRoom.UpdatedBy
            }).ToList();

            return dtos;
        }

    }
}
