using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Room.Commands
{
  
    public record DeleteRoomCommand(int roomId) : IRequest<bool>;
    public class DeleteRoleHandler(IRoomRepository roomRepository) : IRequestHandler<DeleteRoomCommand, bool>
    {
        public async Task<bool> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {

            var roomExist = await roomRepository.GetByIdAsync(request.roomId);
            if (roomExist == null) return false;
            return await roomRepository.DeleteAsync(request.roomId, cancellationToken);

        }
    }
}

