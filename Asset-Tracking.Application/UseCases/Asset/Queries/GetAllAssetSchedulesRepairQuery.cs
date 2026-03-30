using Asset_Tracking.Application.Common.Dtos.Asset;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Queries
{

    public record GetAllAssetSchedulesRepairQuery() : IRequest<List<ScheduleRepairResponseDto>>;

    public class GetAllAssetSchedulesRepairHandler(IScheduleRepairRepository scheduleRepairRepository) : IRequestHandler<GetAllAssetSchedulesRepairQuery, List<ScheduleRepairResponseDto>>
    {
        public async Task<List<ScheduleRepairResponseDto>> Handle(GetAllAssetSchedulesRepairQuery request, CancellationToken cancellationToken)
        {
          
            var schedules =  await scheduleRepairRepository.GetAllAsync();

            var dtos = schedules.Select(schedule => new ScheduleRepairResponseDto
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
            }).ToList();

            return dtos;

        }

   
    }

}
