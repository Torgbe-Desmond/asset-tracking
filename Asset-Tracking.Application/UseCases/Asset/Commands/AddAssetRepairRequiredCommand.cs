using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asset_Tracking.Application.Common.Asset;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Commands
{
    public record AddAssetRepairRequiredCommand(int AssetRepairId, AssetRepairRequestDto AssetRepair) : IRequest<AssetRepairDetailResponseDto>;

    public  class AddAssetRepairRequiredHandler(IAssetRepairRepository assetRepairRepository) : IRequestHandler<AddAssetRepairRequiredCommand, AssetRepairDetailResponseDto>
    {
        public async Task<AssetRepairDetailResponseDto> Handle(AddAssetRepairRequiredCommand request, CancellationToken cancellationToken)
        {
            var dto = request.AssetRepair;

            if(string.IsNullOrWhiteSpace(dto.RepairTitle))
                throw new ArgumentException("Repair title is required.");

            if(dto.Cost < 0)
                throw new ArgumentException("Cost cannot be negative.");

            if (string.IsNullOrWhiteSpace(dto.CreatedBy))
                throw new ArgumentException("Created by is required.");

            if(string.IsNullOrWhiteSpace(dto.Details))
                throw new ArgumentException("Asset details date is required.");

            if(dto.RepairStatusId < 0)
                throw new ArgumentException("Repair status Id by is required.");

            var repair = new AssetRepairEntity
            {
                RepairTitle = dto.RepairTitle.Trim(),
                Details = dto.Details.Trim(),
                RepairerName = dto.RepairerName?.Trim(),
                RepairerContactNumber = dto.RepairerContactNumber?.Trim(),
                Cost = dto.Cost,
                DateCompleted = dto.DateCompleted?.Trim(),
                RepairStatusId = dto.RepairStatusId,
                AssetId = dto.AssetId,
                AssetReceiveDate = dto.AssetReceiveDate,
                ReceivedBy = dto.ReceivedBy?.Trim(),
                CreatedBy = dto.CreatedBy,       
                DateCreated = DateTime.UtcNow,
                UpdateBy = dto.UpdatedBy,
                DateUpdated = dto.DateUpdated,

            };

            await assetRepairRepository.UpdateAsync(request.AssetRepairId, repair);

            return new AssetRepairDetailResponseDto()
            {
                AssetId = repair.AssetId,
                RepairTitle = repair.RepairTitle.Trim(),
                Details = repair.Details.Trim(),
                RepairerName = repair.RepairerName?.Trim(),
                RepairerContactNumber = repair.RepairerContactNumber?.Trim(),
                Cost = repair.Cost,
                DateCompleted = repair.DateCompleted?.Trim(),
                RepairStatusId = repair.RepairStatusId,
                AssetReceiveDate = repair.AssetReceiveDate,
                ReceivedBy = repair.ReceivedBy?.Trim(),
                CreatedBy = repair.CreatedBy,
                //DateCreated = repair.DateCreated,
                UpdateBy = repair.UpdateBy,
                //DateUpdated = repair.DateUpdated,
            };
        }

    }

}