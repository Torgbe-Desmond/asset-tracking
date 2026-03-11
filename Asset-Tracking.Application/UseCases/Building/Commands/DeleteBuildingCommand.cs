using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Building.Commands
{
    public record DeleteBuildingCommand(int assetBuildingId) : IRequest<bool>;

    public class DeletBuildingHandler(IBuildingRepository buildingRepository) : IRequestHandler<DeleteBuildingCommand, bool>
    {
        public async Task<bool> Handle(DeleteBuildingCommand request, CancellationToken cancellationToken)
        {

            var buildingExist = await buildingRepository.GetByIdAsync(request.assetBuildingId);
            if (buildingExist == null) return false;
            return await buildingRepository.DeleteAsync(request.assetBuildingId, cancellationToken);

        }
    }
}
