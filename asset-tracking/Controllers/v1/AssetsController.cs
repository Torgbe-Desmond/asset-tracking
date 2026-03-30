using System.Net.Mime;
using Asp.Versioning;
using Asset_Tracking.Application.Common.Dtos.Asset;
using Asset_Tracking.Application.UseCases.Asset.Commands;
using Asset_Tracking.Application.UseCases.Asset.Queries;
using Asset_Tracking_Api.Common.Models;
using Asset_Tracking_Api.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Asset_Tracking_Api.Controllers.v1
{
    [Route("api/v{version:ApiVersion}/assets")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiVersion("1.0")]
    public class AssetsController(ISender send) : ControllerBase
    {
        /// <summary>
        /// Retrieves all assets.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<AssetDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var result = await send.Send(new GetAllAssetsQuery(), ct);

            var response = new ApiResponse<IEnumerable<AssetDto>>
            {
                Data = result,
                StatusCode = StatusCodes.Status200OK
            };

            return Ok(response);
        }

        /// <summary>
        /// Retrieves a specific asset by ID.
        /// </summary>
        [HttpGet("{assetId:int}")]
        [ProducesResponseType(typeof(ApiResponse<AssetDetailDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int assetId, CancellationToken ct)
        {
            var result = await send.Send(new GetAssetByIdQuery(assetId), ct);

            if (result == null)
            {
                return NotFound(new ApiResponse<ProblemDetails>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = $"Asset with ID {assetId} not found."
                });
            }

            var response = new ApiResponse<AssetDetailDto>
            {
                Data = result,
                StatusCode = StatusCodes.Status200OK
            };

            return Ok(response);
        }

        /// <summary>
        /// Creates a new asset.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<AssetDetailResponseDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(AssetRequestDto request, CancellationToken ct)
        {
            var result = await send.Send(new AddAssetCommand(request), ct);

            var response = new ApiResponse<AssetDetailResponseDto>
            {
                Data = result,
                StatusCode = StatusCodes.Status201Created
            };

            return CreatedAtAction(nameof(GetById), new { assetId = result.AssetId, version = "1.0" }, response);
        }

        /// <summary>
        /// Updates an existing asset.
        /// </summary>
        [HttpPatch("{assetId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int assetId, AssetRequestDto request, CancellationToken ct)
        {
            var success = await send.Send(new UpdateAssetCommand(assetId, request), ct);

            if (!success)
            {
                return NotFound(new ApiResponse<ProblemDetails>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = $"Asset with ID {assetId} could not be found for update."
                });
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes an existing asset.
        /// </summary>
        [HttpDelete("{assetId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int assetId, CancellationToken ct)
        {
            var success = await send.Send(new DeleteAssetCommand(assetId), ct);

            if (!success)
            {
                return NotFound(new ApiResponse<ProblemDetails>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = $"Asset with ID {assetId} not found for deletion."
                });
            }

            return NoContent();
        }
    }
}