using Asset_Tracking.Application.Common.Staff;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Staff.Commands
{
    public record AddStaffCommand(StaffRequestDto Staff)
      : IRequest<StaffResponseDto>;


    public class AddStaffCommandHandler(IStaffRepository staffRepository)
    : IRequestHandler<AddStaffCommand, StaffResponseDto>
    {
    
        public async Task<StaffResponseDto> Handle(
            AddStaffCommand request,
            CancellationToken cancellationToken)
        {
            var entity = new StaffEntity
            {
                StaffId = request.Staff.StaffId,
                TitleId = request.Staff.TitleId,
                Surname = request.Staff.Surname,
                OtherName = request.Staff.OtherName,
                TechMail = request.Staff.TechMail,
                SiteId = request.Staff.SiteId,
                BuildingId = request.Staff.BuildingId,
                FloorId = request.Staff.FloorId,
                RoomId = request.Staff.RoomId,
                HasRoom = request.Staff.HasRoom,
                RoomLocationDescription = request.Staff.RoomLocationDescription
            };

            await staffRepository.AddAsync(entity, cancellationToken);

            return new StaffResponseDto
            {
                StaffId = entity.StaffId,
                TitleId = entity.TitleId,
                Surname = entity.Surname,
                OtherName = entity.OtherName,
                TechMail = entity.TechMail,
                SiteId = entity.SiteId,
                BuildingId = entity.BuildingId,
                FloorId = entity.FloorId,
                RoomId = entity.RoomId,
                HasRoom = entity.HasRoom,
                RoomLocationDescription = entity.RoomLocationDescription
            };
        }
    }
}
