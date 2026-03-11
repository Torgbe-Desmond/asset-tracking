using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Staff.Commands
{


    public record DeleteStaffCommand(string StaffId) : IRequest<bool>;
    public class DeleteStaffHandler(IStaffRepository staffRepository) : IRequestHandler<DeleteStaffCommand, bool>
    {
        public async Task<bool> Handle(DeleteStaffCommand request, CancellationToken cancellationToken)
        {

            var staffExist = await staffRepository.GetByIdAsync(request.StaffId);
            if (staffExist == null) return false;
            return await staffRepository.DeleteAsync(request.StaffId, cancellationToken);

        }
    }
}
