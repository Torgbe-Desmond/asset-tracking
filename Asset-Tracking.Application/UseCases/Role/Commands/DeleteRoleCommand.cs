using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Role.Commands
{

    public record DeleteRoleCommand(string roleId) : IRequest<bool>;
    public class DeleteRoleHandler(IRoleRepository roleRepository) : IRequestHandler<DeleteRoleCommand, bool>
    {
        public async Task<bool> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {

            var roleExist = await roleRepository.GetByIdAsync(request.roleId);
            if (roleExist == null) return false;
            return await roleRepository.DeleteAsync(request.roleId, cancellationToken);

        }
    }
}
