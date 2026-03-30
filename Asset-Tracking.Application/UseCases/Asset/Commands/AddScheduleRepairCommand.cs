using Asset_Tracking.Application.Common.Dtos.Asset;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Commands
{
    public record AddScheduleRepairCommand(ScheduleRepairRequestDto ScheduleRepair) :IRequest<ScheduleRepairDetailResponseDto>;

    public class AddScheduleRepairHandler(IScheduleRepairRepository scheduleRepairRepository) : IRequestHandler<AddScheduleRepairCommand, ScheduleRepairDetailResponseDto>
    {
        public async Task<ScheduleRepairDetailResponseDto> Handle(AddScheduleRepairCommand request, CancellationToken cancellationToken)
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


            await scheduleRepairRepository.AddAsync(schedule);

            return new ScheduleRepairDetailResponseDto
            {
                ScheduleRepairId = schedule.ScheduleRepairId,
                RepairTitle = schedule.RepairTitle,
                Details = schedule.Details,
                RepairerName = schedule.RepairerName,
                RepairerContactNumber = schedule.RepairerContactNumber,
                Cost = schedule.Cost,
                DateCompleted = schedule.DateCompleted,
                RepairStatusId = schedule.RepairStatusId,
                AssetId = schedule.AssetId,
                IsScheduleApproved = schedule.IsScheduleApproved,
                CreatedBy = schedule.CreatedBy,
                //DateCreated = schedule.DateCreated,
                UpdateBy = schedule.UpdateBy,
                //DateUpdated = schedule.DateUpdated
            };



        }
    }


}
