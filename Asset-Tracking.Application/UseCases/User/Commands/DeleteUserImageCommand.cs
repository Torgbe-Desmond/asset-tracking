using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.User.Commands
{

    public record DeleteUserImageCommand(int Id) : IRequest<bool>;
    public class DeleteUserImageHandler(IUserImageRepository userImageRepository) : IRequestHandler<DeleteUserImageCommand, bool>
    {
        public async Task<bool> Handle(DeleteUserImageCommand request, CancellationToken cancellationToken)
        {
            var staffExist = await userImageRepository.GetByIdAsync(request.Id);
            if (staffExist == null) return false;
            return await userImageRepository.DeleteAsync(request.Id, cancellationToken);

        }
    }
}
