using Asset_Tracking.Application.Common.Asset;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Commands
{
    public record AddRepairStatusCommand(RepairStatusRequestDto RepairStatus)
       : IRequest<RepairStatusResponseDto>;

    public class AddRepairStatusHandler(IRepairStatusRepository repairStatusRepository)
        : IRequestHandler<AddRepairStatusCommand, RepairStatusResponseDto>
    {
        public async Task<RepairStatusResponseDto> Handle(
            AddRepairStatusCommand request,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.RepairStatus.RepairStatusName))
                throw new ArgumentException("Repair status name is required.");

            var entity = new RepairStatusEntity
            {
                RepairStatusName = request.RepairStatus.RepairStatusName,
           
            };

            await repairStatusRepository.AddAsync(entity);

            return new RepairStatusResponseDto
            {
                RepairStatusId = entity.RepairStatusId,
                RepairStatusName = entity.RepairStatusName,
            };
        }
    }
}
