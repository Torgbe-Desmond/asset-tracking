using Asset_Tracking.Application.Common.Asset;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Queries
{

    public record GetAssetSchedulesDetailsQuery(string ScheduleRepairId) : IRequest<ScheduleRepairDetailResponseDto>;

    public class GetAssetSchedulesRepairDetailsQueryHandler(IScheduleRepairRepository scheduleRepairRepository) : IRequestHandler<GetAssetSchedulesDetailsQuery, ScheduleRepairDetailResponseDto>
    {
        public async Task<ScheduleRepairDetailResponseDto> Handle(GetAssetSchedulesDetailsQuery request, CancellationToken cancellationToken)
        {


            if (request.ScheduleRepairId == null)
                throw new ArgumentNullException("ScheduleRepairId is required.", nameof(request.ScheduleRepairId));

            var schedule = await scheduleRepairRepository.GetByIdAsync(request.ScheduleRepairId);

            if (schedule == null)
                throw new KeyNotFoundException("No schedule found.");

            var dtos = new ScheduleRepairDetailResponseDto()
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
                //DateUpdated = schedule.DateUpdated,
                Asset = schedule.Asset != null ? new AssetDto
                {
                    AssetId = schedule.Asset.AssetId,
                    AssetName = schedule.Asset.AssetName ?? string.Empty,
                    AssetDescription = schedule.Asset.AssetDescription,
                    PurchaseFrom = schedule.Asset.PurchaseFrom,
                    PurchaseDate = schedule.Asset.PurchaseDate,
                    Cost = schedule.Asset.Cost,
                    Brand = schedule.Asset.Brand,
                    Model = schedule.Asset.Model,
                    SerialNumber = schedule.Asset.SerialNumber,
                    AssignedTo = schedule.Asset.AssignedTo,
                    HasWarranty = schedule.Asset.HasWarranty,
                    WarrantyDate = schedule.Asset.WarrantyDate,
                    AssetCategoryId = schedule.Asset.AssetId,
                    AssetStatusId = schedule.Asset.AssetId,
                    AssetImageId = schedule.Asset.AssetId,
                    SiteId = schedule.Asset.AssetId,
                    BuildingId = schedule.Asset.AssetId,
                    FloorId = schedule.Asset.FloorId,
                    RoomId = schedule.Asset.AssetId,
                    RoomLocationDescription = schedule.Asset.RoomLocationDescription,
                    AssetTagId = schedule.Asset.AssetTagId ?? string.Empty,
                    AssetConditionDescription = schedule.Asset.AssetConditionDescription,
                    IsAssetInGoodCondition = schedule.Asset.IsAssetInGoodCondition,
                    IsRepairRequired = schedule.Asset.IsRepairRequired,
                    //DateCreated = schedule.Asset.DateCreated,
                    CreatedBy = schedule.Asset.CreatedBy,
                    //DateUpdated = schedule.Asset.DateUpdated,
                } : null,

                RepairStatus = schedule.RepairStatus != null ? new RepairStatusResponseDto
                {
                    RepairStatusId = schedule.RepairStatus.RepairStatusId,
                    RepairStatusName = schedule.RepairStatus.RepairStatusName,
                } : null
        };

            return dtos;

        }


    }
}
