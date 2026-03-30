using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asset_Tracking.Application.Common.Dtos.Asset;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using Azure.Core;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Commands
{

    public record UpdateAssetCheckOutsCommand(int AssetCheckOutId, AssetCheckOutRequestDto CheckOut) : IRequest<bool>;
    public class UodateAssetCheckOutsHandler(IAssetCheckOutRepository checkOutRepository) : IRequestHandler<UpdateAssetCheckOutsCommand, bool>
    {
        public async Task<bool> Handle(
            UpdateAssetCheckOutsCommand request,
            CancellationToken cancellationToken)
        {
            var dto = request.CheckOut;

            if (dto.AssetCheckOutDate == default)
                throw new ArgumentException("Check-out date is required.", nameof(dto.AssetCheckOutDate));

            if (dto.AssetId <= 0)
                throw new ArgumentException("Valid AssetId is required.", nameof(dto.AssetId));

            if (dto.BuildingId <= 0)
                throw new ArgumentException("BuildingId is required.", nameof(dto.BuildingId));

            if (dto.FloorId <= 0)
                throw new ArgumentException("FloorId is required.", nameof(dto.FloorId));

            if (dto.RoomId <= 0)
                throw new ArgumentException("RoomId is required.", nameof(dto.RoomId));

            if (string.IsNullOrWhiteSpace(dto.CreatedBy))
                throw new ArgumentException("CreatedBy is required.", nameof(dto.CreatedBy));

            var assetCheckOutExist = await checkOutRepository.GetByIdAsync(request.AssetCheckOutId);

            var entity = new AssetCheckOutEntity
            {
                AssetCheckOutDate = dto.AssetCheckOutDate,
                DueDate = dto.DueDate,
                Notes = dto.Notes?.Trim(),
                DateCreated = DateTime.UtcNow,
                CreatedBy = dto.CreatedBy.Trim(),
                DateUpdated = dto.DateUpdated,
                UpdatedBy = dto.UpdatedBy?.Trim(),
                AssetId = dto.AssetId,
                StaffId = dto.StaffId?.Trim(),
                AssignedTo = dto.AssignedTo?.Trim(),
                SiteId = dto.SiteId,
                BuildingId = dto.BuildingId,
                FloorId = dto.FloorId,
                RoomId = dto.RoomId,
                RoomLocationDescription = dto.RoomLocationDescription?.Trim(),
                IsConfirmedEmailSent = dto.IsConfirmedEmailSent,
                EmailSentDate = dto.EmailSentDate,
                HasReceivedConfirmed = dto.HasReceivedConfirmed,
                HasReceivedConfirmedDate = dto.HasReceivedConfirmedDate,
                IsSMSSent = dto.IsSMSSent,
                SMSSentDate = dto.SMSSentDate
            };


            return await checkOutRepository.UpdateAsync(request.AssetCheckOutId, entity, cancellationToken);

        }
    }
}
