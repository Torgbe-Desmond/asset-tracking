using Asset_Tracking.Application.Common.Role;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Role.Commands
{
    public record UpdateRoleCommand(string RoleId, RoleRequestDto Role)
       : IRequest<bool>;

    public class UpdateRoleHandler(IRoleRepository roleRepository)
        : IRequestHandler<UpdateRoleCommand, bool>
    {
        public async Task<bool> Handle(
            UpdateRoleCommand request,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.RoleId))
                throw new ArgumentException("RoleId is required.");

            var entity = await roleRepository.GetByIdAsync(request.RoleId);

            if (entity is null)
                throw new KeyNotFoundException("Role not found.");

            entity.Name = request.Role.Name;
            entity.NormalizedName = request.Role.NormalizedName;
            entity.ConcurrencyStamp = Guid.NewGuid().ToString();

            return await roleRepository.UpdateAsync(request.RoleId, entity);
        }
    }
}
