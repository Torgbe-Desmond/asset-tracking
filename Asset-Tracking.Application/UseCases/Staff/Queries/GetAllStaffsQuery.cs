using Asset_Tracking.Application.Common.Dtos.Staff;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Staff.Queries
{
    public record GetAllStaffsQuery()
    : IRequest<List<StaffResponseDto>>;

    public class GetAllStaffsHandler(IStaffRepository staffRepository)
    : IRequestHandler<GetAllStaffsQuery, List<StaffResponseDto>>
    {
        public async Task<List<StaffResponseDto>> Handle(
            GetAllStaffsQuery request,
            CancellationToken cancellationToken)
        {

            var allStaffs = await staffRepository.GetAllAsync();

            var dtos = allStaffs.Select(allStaff=>  new StaffResponseDto
            {
                StaffId = allStaff.StaffId,
                TitleId = allStaff.TitleId,
                Surname = allStaff.Surname,
                OtherName = allStaff.OtherName,
                TechMail = allStaff.TechMail,
                SiteId = allStaff.SiteId,
                BuildingId = allStaff.BuildingId,
                FloorId = allStaff.FloorId,
                RoomId = allStaff.RoomId,
                HasRoom = allStaff.HasRoom,
                RoomLocationDescription = allStaff.RoomLocationDescription
            }).ToList();

            return dtos;
        }
    }
}
