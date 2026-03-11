using Asset_Tracking.Application.Common.User;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.User.Queries
{

    public record GetAllUserImagesQuery(int Id)
     : IRequest<List<UserImageResponseDto>>;

    public class GetAllUserImagesHandler(IUserImageRepository userImageRepository)
        : IRequestHandler<GetAllUserImagesQuery, List<UserImageResponseDto>>
    {
        public async Task<List<UserImageResponseDto>> Handle(GetAllUserImagesQuery request, CancellationToken cancellationToken)
        {
            var allUserImages = await userImageRepository.GetAllAsync();

            var dtos = allUserImages.Select(allUserImage=>  new UserImageResponseDto
            {
                Id = allUserImage.Id,
                Photo = allUserImage.Photo
            }).ToList();

            return dtos;
        }
    }
}
