using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Floor.Commands
{


    public record DeleteFloorCommand(int assetBuildingId) : IRequest<bool>;

    public class DeletBuildingHandler(IFloorRepository floorRepository) : IRequestHandler<DeleteFloorCommand, bool>
    {
        public async Task<bool> Handle(DeleteFloorCommand request, CancellationToken cancellationToken)
        {

            var floorExist = await floorRepository.GetByIdAsync(request.assetBuildingId);
            if (floorExist == null) return false;
            return await floorRepository.DeleteAsync(request.assetBuildingId, cancellationToken);

        }
    }
}
