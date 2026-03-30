using Asset_Tracking.Application.Common.Dtos.Staff;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Staff.Queries
{

    public record GetStaffByIdQuery(string StaffId)
    : IRequest<StaffResponseDto?>;

    public class GetStaffByIdHandler(IStaffRepository staffRepository)
    : IRequestHandler<GetStaffByIdQuery, StaffResponseDto?>
    {
        public async Task<StaffResponseDto?> Handle(
            GetStaffByIdQuery request,
            CancellationToken cancellationToken)
        {

            var staffExist  = await staffRepository.GetByIdAsync(request.StaffId, cancellationToken);

            if (staffExist == null) return null;

            return new StaffResponseDto
            {
                StaffId = staffExist.StaffId,
                TitleId = staffExist.TitleId,
                Surname = staffExist.Surname,
                OtherName = staffExist.OtherName,
                TechMail = staffExist.TechMail,
                SiteId = staffExist.SiteId,
                BuildingId = staffExist.BuildingId,
                FloorId = staffExist.FloorId,
                RoomId = staffExist.RoomId,
                HasRoom = staffExist.HasRoom,
                RoomLocationDescription = staffExist.RoomLocationDescription
            };
        }
    }
}
