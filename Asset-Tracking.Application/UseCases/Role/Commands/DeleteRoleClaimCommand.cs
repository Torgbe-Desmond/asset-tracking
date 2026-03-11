using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Role.Commands
{
    public record DeleteRoleClaimCommand(int roleClaimId) : IRequest<bool>;
    public class DeleteRoleClaimHandler(IRoleClaimsRepository roleClaimsRepository) : IRequestHandler<DeleteRoleClaimCommand, bool>
    {
        public async Task<bool> Handle(DeleteRoleClaimCommand request, CancellationToken cancellationToken)
        {

            var roleClaimExist = await roleClaimsRepository.GetByIdAsync(request.roleClaimId);
            if (roleClaimExist == null) return false;
            return await roleClaimsRepository.DeleteAsync(request.roleClaimId, cancellationToken);

        }
    }
}
