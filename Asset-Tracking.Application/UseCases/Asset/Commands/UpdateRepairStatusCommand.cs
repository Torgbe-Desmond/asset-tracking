using Asset_Tracking.Application.Common.Asset;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Commands
{
    public record UpdateRepairStatusCommand(
         int RepairStatusId,
         string RepairStatusName
       )
         : IRequest<bool>;

    public class UpdateRepairStatusHandler(IRepairStatusRepository repairStatusRepository)
        : IRequestHandler<UpdateRepairStatusCommand, bool>
    {
        public async Task<bool> Handle(
            UpdateRepairStatusCommand request,
            CancellationToken cancellationToken)
        {
            if (request.RepairStatusId <= 0)
                throw new ArgumentException("RepairStatusId is required.");

            var entity = await repairStatusRepository.GetByIdAsync(request.RepairStatusId);

            if (entity is null)
                throw new KeyNotFoundException("Repair status not found.");

            entity.RepairStatusName = request.RepairStatusName;

            return await repairStatusRepository.UpdateAsync(request.RepairStatusId,entity, cancellationToken);

            
        }
    }
}
