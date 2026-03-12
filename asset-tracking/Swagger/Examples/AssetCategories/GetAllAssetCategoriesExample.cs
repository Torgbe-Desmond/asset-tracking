//using Asset_Tracking.Application.Common.Asset;
//using Asset_Tracking_Api.Common.Models;
//using Swashbuckle.AspNetCore.Filters;

//namespace Asset_Tracking_Api.Swagger.Examples.AssetCategories
//{
//    public class GetAllAssetCategoriesExample
//     : IExamplesProvider<ApiResponse<IEnumerable<AssetCategoryResponseDto>>>
//    {
//        public ApiResponse<IEnumerable<AssetCategoryResponseDto>> GetExamples()
//        {
//            return new ApiResponse<IEnumerable<AssetCategoryResponseDto>>
//            {
//                StatusCode = 200,
//                Data = new List<AssetCategoryResponseDto>
//            {
//                new AssetCategoryResponseDto
//                {
//                    AssetCategoryId = 1,
//                    AssetCategoryName = "Electronics",
//                    CreatedBy = "admin",
//                    UpdatedBy = null
//                },
//                new AssetCategoryResponseDto
//                {
//                    AssetCategoryId = 2,
//                    AssetCategoryName = "Furniture",
//                    CreatedBy = "admin",
//                    UpdatedBy = "manager"
//                },
//                new AssetCategoryResponseDto
//                {
//                    AssetCategoryId = 3,
//                    AssetCategoryName = "Vehicles",
//                    CreatedBy = "system",
//                    UpdatedBy = "admin"
//                }
//            }
//            };
//        }
//    }
//}
