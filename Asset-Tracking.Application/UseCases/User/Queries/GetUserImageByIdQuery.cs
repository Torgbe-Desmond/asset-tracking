using Asset_Tracking.Application.Common.User;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.User.Queries
{

    public record GetUserImageByIdQuery(int Id)
      : IRequest<UserImageResponseDto>;

    public class GetUserImageByIdHandler(IUserImageRepository userImageRepository)
        : IRequestHandler<GetUserImageByIdQuery, UserImageResponseDto>
    {
        public async Task<UserImageResponseDto> Handle(GetUserImageByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0)
                throw new ArgumentException("Id is required.");

            var entity = await userImageRepository.GetByIdAsync(request.Id)
                ?? throw new ArgumentException("User image not found.");

            return new UserImageResponseDto
            {
                Id = entity.Id,
                Photo = entity.Photo
            };
        }
    }
}
