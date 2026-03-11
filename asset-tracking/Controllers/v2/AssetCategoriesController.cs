using Asp.Versioning;
using Asset_Tracking.Application.Common.Asset;
using Asset_Tracking.Application.UseCases.Asset.Commands;
using Asset_Tracking.Application.UseCases.Asset.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Asset_Tracking_Api.Controllers.v2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/asset-categories")]
    [ApiVersion("2.0")]
    public class AssetCategoriesController(ISender send) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
            => Ok(await send.Send(new GetAllAssetCategoriesQuery(), ct));

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken ct)
            => Ok(await send.Send(new GetAssetCategoryByIdQuery(id), ct));

        [HttpPost]
        public async Task<IActionResult> Create(
           AssetCategoryRequestDto request,
           CancellationToken ct)
        {
            var result = await send.Send(new AddAssetCategoryCommand(request), ct);

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.AssetCategoryId, version = "1.0" },
                result);
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> Update(
            int id,
            AssetCategoryRequestDto request,
            CancellationToken ct)
        {
            await send.Send(new UpdateAssetCategoryCommand(id, request), ct);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(
           int id,
           CancellationToken ct)
        {
            await send.Send(new DeleteAssetCategoryCommand(id), ct);
            return NoContent();
        }
    }
}
