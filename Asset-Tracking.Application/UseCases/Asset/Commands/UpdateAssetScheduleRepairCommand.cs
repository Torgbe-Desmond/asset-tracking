using Asset_Tracking.Application.Common.Asset;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Commands
{

    public record UpdateAssetScheduleRepairCommand(string ScheduleRepairId ,ScheduleRepairRequestDto ScheduleRepair) : IRequest<bool>;

    public class UpdateAssetScheduleRepairHandler(IScheduleRepairRepository scheduleRepairRepository) : IRequestHandler<UpdateAssetScheduleRepairCommand, bool>
    {
        public async Task<bool> Handle(UpdateAssetScheduleRepairCommand request, CancellationToken cancellationToken)
        {
            var dto = request.ScheduleRepair;

            if (string.IsNullOrWhiteSpace(dto.RepairTitle))
                throw new ArgumentException("Repair title is required.");

            if (dto.Cost < 0)
                throw new ArgumentException("Cost cannot be negative.");

            if (string.IsNullOrWhiteSpace(dto.CreatedBy))
                throw new ArgumentException("Created by is required.");

            if (string.IsNullOrWhiteSpace(dto.Details))
                throw new ArgumentException("Asset details date is required.");

            if (dto.RepairStatusId < 0)
                throw new ArgumentException("Repair status Id by is required.");

            var existingSchedule = await scheduleRepairRepository.GetByIdAsync(request.ScheduleRepairId);

            if (existingSchedule == null)
                throw new KeyNotFoundException("Schedule repair not found.");

            var schedule = new ScheduleRepairEntity
            {
                RepairTitle = dto.RepairTitle.Trim(),
                Details = dto.Details.Trim(),
                RepairerName = dto.RepairerName?.Trim(),
                RepairerContactNumber = dto.RepairerContactNumber?.Trim(),
                Cost = dto.Cost,
                DateCompleted = dto.DateCompleted?.Trim(),
                RepairStatusId = dto.RepairStatusId,
                AssetId = dto.AssetId,
                IsScheduleApproved = dto.IsScheduleApproved,
                CreatedBy = dto.CreatedBy.Trim(),
                DateCreated = DateTime.UtcNow,
                UpdateBy = dto.UpdateBy?.Trim(),
                DateUpdated = dto.DateUpdated
            };


            return await scheduleRepairRepository.UpdateAsync(request.ScheduleRepairId,schedule);

        }
    }
}
