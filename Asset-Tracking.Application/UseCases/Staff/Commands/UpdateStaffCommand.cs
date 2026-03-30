using Asset_Tracking.Application.Common.Dtos.Staff;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Staff.Commands
{
    public record UpdateStaffCommand(
     string StaffId,
     StaffRequestDto Staff)
     : IRequest<bool>;

    public class UpdateStaffCommandHandler(IStaffRepository staffRepository)
    : IRequestHandler<UpdateStaffCommand, bool>
    {
       

        public async Task<bool> Handle(
            UpdateStaffCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await staffRepository.GetByIdAsync(request.StaffId);

            if (entity == null)
                throw new Exception("Staff not found");

            entity.TitleId = request.Staff.TitleId;
            entity.Surname = request.Staff.Surname;
            entity.OtherName = request.Staff.OtherName;
            entity.TechMail = request.Staff.TechMail;
            entity.SiteId = request.Staff.SiteId;
            entity.BuildingId = request.Staff.BuildingId;
            entity.FloorId = request.Staff.FloorId;
            entity.RoomId = request.Staff.RoomId;
            entity.HasRoom = request.Staff.HasRoom;
            entity.RoomLocationDescription = request.Staff.RoomLocationDescription;

            return await staffRepository.UpdateAsync(request.StaffId, entity, cancellationToken);
        }
    }

}
