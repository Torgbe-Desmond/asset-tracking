using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Commands
{
    public record DeleteAssetScheduleRepairCommand(string assetCategoryId) : IRequest<bool>;

    public class DeleteAssetScheduleRepairHandler(IScheduleRepairRepository scheduleRepairRepository) : IRequestHandler<DeleteAssetScheduleRepairCommand, bool>
    {
        public async Task<bool> Handle(DeleteAssetScheduleRepairCommand request, CancellationToken cancellationToken)
        {

            var assetExist = await scheduleRepairRepository.GetByIdAsync(request.assetCategoryId);
            if (assetExist == null) return false;
            return await scheduleRepairRepository.DeleteAsync(request.assetCategoryId, cancellationToken);

        }
    }
}
