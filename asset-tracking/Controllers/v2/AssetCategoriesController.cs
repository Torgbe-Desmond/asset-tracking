using System.Net.Mime;
using Asp.Versioning;
using Asset_Tracking.Application.Common.Dtos.Asset;
using Asset_Tracking.Application.UseCases.Asset.Commands;
using Asset_Tracking.Application.UseCases.Asset.Queries;
using Asset_Tracking_Api.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Asset_Tracking_Api.Controllers.v2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/asset-categories")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiVersion("2.0")]
    public class AssetCategoriesController(ISender send) : ControllerBase
    {
        /// <summary>
        /// returns all asset categories
        /// </summary>
        /// <response code="200">Returns the requested category.</response>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<AssetCategoryResponseDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var result = await send.Send(new GetAllAssetCategoriesQuery(), ct);

            var response = new ApiResponse<IEnumerable<AssetCategoryResponseDto>>
            {
                Data = result,
                StatusCode = StatusCodes.Status200OK
            };

            return Ok(response);
        }

        /// <summary>
        /// returns asset category by id
        /// </summary>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ApiResponse<AssetCategoryResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id, CancellationToken ct)
        {
            var result = await send.Send(new GetAssetCategoryByIdQuery(id), ct);

            if (result == null)
            {
                return NotFound(new ApiResponse<ProblemDetails>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = "Asset category not found."
                });
            }

            var response = new ApiResponse<AssetCategoryResponseDto>
            {
                Data = result,
                StatusCode = StatusCodes.Status200OK
            };

            return Ok(response);
        }

        /// <summary>
        /// Creates a new asset category
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<AssetCategoryResponseDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(
           AssetCategoryRequestDto request,
           CancellationToken ct)
        {
            var result = await send.Send(new AddAssetCategoryCommand(request), ct);

            var response = new ApiResponse<AssetCategoryResponseDto>
            {
                Data = result,
                StatusCode = StatusCodes.Status201Created,
                Message = "Category created successfully."
            };

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.AssetCategoryId, version = "1.0" },
                response);
        }

        /// <summary>
        /// updates an existing asset category by id
        /// </summary>
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(
            int id,
            AssetCategoryRequestDto request,
            CancellationToken ct)
        {
            var success = await send.Send(new UpdateAssetCategoryCommand(id, request), ct);

            if (!success)
            {
                return NotFound(new ApiResponse<ProblemDetails>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = $"Asset disposal with ID {id} could not be found for update."
                });
            }

            return NoContent();
        }

        /// <summary>
        /// deletes an existing asset category
        /// </summary>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(
           int id,
           CancellationToken ct)
        {
            await send.Send(new DeleteAssetCategoryCommand(id), ct);
            return NoContent();
        }
    }

}
