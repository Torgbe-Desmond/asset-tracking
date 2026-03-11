using Asset_Tracking.Application.Common.Asset;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Commands
{


    public record UpdateAssetRepairCommand(int AssetRepairId ,AssetRepairRequestDto AssetRepair) : IRequest<bool>;
    public class UpdateAssetRepairHandler(IAssetRepairRepository assetRepairRepository) : IRequestHandler<UpdateAssetRepairCommand, bool>
    {
        public async Task<bool> Handle(UpdateAssetRepairCommand request, CancellationToken cancellationToken)
        {
            var dto = request.AssetRepair;
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
            
            var assetRepairRepositoryExist = await assetRepairRepository.GetByIdAsync(request.AssetRepairId);

            if(assetRepairRepositoryExist == null)
                throw new KeyNotFoundException("Asset repair record not found.");

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

            return await assetRepairRepository.UpdateAsync(request.AssetRepairId, repair);
        }
    }
}
