using Asset_Tracking.Application.Common.Dtos.Asset;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Queries
{
    public record GetAllAssetsQuery() : IRequest<List<AssetDto>>;
    public class GetAllAssetsHandler(IAssetRepository assetRepository) : IRequestHandler<GetAllAssetsQuery, List<AssetDto>>
    {
      public async  Task<List<AssetDto>> Handle(GetAllAssetsQuery request, CancellationToken cancellationToken)

        {
            var assets = await assetRepository.GetAllAsync(cancellationToken);



            var dtos = assets.Select(asset => new AssetDto
            {
                AssetId = asset.AssetId,
                AssetName = asset.AssetName ?? string.Empty,
                AssetDescription = asset.AssetDescription,
                PurchaseFrom = asset.PurchaseFrom,
                PurchaseDate = asset.PurchaseDate,
                Cost = asset.Cost,
                Brand = asset.Brand,
                Model = asset.Model,
                SerialNumber = asset.SerialNumber,  
                AssignedTo = asset.AssignedTo,
                HasWarranty = asset.HasWarranty,
                WarrantyDate = asset.WarrantyDate,
                AssetCategoryId = asset.AssetCategoryId,
                AssetStatusId = asset.AssetStatusId,
                AssetImageId = asset.AssetImageId,         
                SiteId = asset.SiteId,
                BuildingId = asset.BuildingId,
                FloorId = asset.FloorId,
                RoomId = asset.RoomId,
                RoomLocationDescription = asset.RoomLocationDescription,
                AssetTagId = asset.AssetTagId ?? string.Empty,
                AssetConditionDescription = asset.AssetConditionDescription,
                IsAssetInGoodCondition = asset.IsAssetInGoodCondition,
                IsRepairRequired = asset.IsRepairRequired,
                //DateCreated = asset.DateCreated,
                CreatedBy = asset.CreatedBy,
                //DateUpdated = asset.DateUpdated,
            }).ToList();

            return dtos;
        }

    }
}

