using System.Net.Mime;
using Asp.Versioning;
using Asset_Tracking.Application.Common.Asset;
using Asset_Tracking.Application.UseCases.Asset.Commands;
using Asset_Tracking.Application.UseCases.Asset.Queries;
using Asset_Tracking_Api.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Asset_Tracking_Api.Controllers.v1
{
    [Route("api/v{version:ApiVersion}/asset-event-history")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiVersion("1.0")]
    public class AssetEventHistoryController(ISender send) : ControllerBase
    {

        /// <summary>
        /// returns am existing asset disposal by id
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<AssetEventHistoryResponseDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var result = await send.Send(new GetAllAssetEventHistoryQuery(), ct);

            var response = new ApiResponse<IEnumerable<AssetEventHistoryResponseDto>>
            {
                Data = result,
                StatusCode = StatusCodes.Status200OK
            };

            return Ok(response);
        }

        /// <summary>
        /// returns am existing asset event history by id
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<AssetEventHistoryDetailsResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(string id, CancellationToken ct)
        {
            var result = await send.Send(new GetAssetEventHistoryByIdQuery(id), ct);

            if (result == null)
            {
                return NotFound(new ApiResponse<ProblemDetails>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = $"Asset event history with ID {id} not found."
                });
            }

            var response = new ApiResponse<AssetEventHistoryDetailsResponseDto>
            {
                Data = result,
                StatusCode = StatusCodes.Status200OK
            };

            return Ok(response);
        }

        /// <summary>
        /// creates a new asset event history 
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<AssetEventHistoryResponseDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(AssetEventHistoryRequestDto request, CancellationToken ct)
        {
            var result = await send.Send(new AddAssetEventHistoryCommand(request), ct);

            var response = new ApiResponse<AssetEventHistoryResponseDto>
            {
                Data = result,
                StatusCode = StatusCodes.Status201Created
            };

            return CreatedAtAction(nameof(GetById), new { id = result.AssetEventHistoryId, version = "1.0" }, response);
        }

        /// <summary>
        /// updates am existing asset event history by id
        /// </summary>
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(string id, AssetEventHistoryRequestDto request, CancellationToken ct)
        {
            var success = await send.Send(new UpdateAssetEventHistoryCommand(id, request), ct);

            if (!success)
            {
                return NotFound(new ApiResponse<ProblemDetails>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = $"Asset event history with ID {id} could not be found for update."
                });
            }

            return NoContent();
        }

        /// <summary>
        /// deletes am existing asset event history by id
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id, CancellationToken ct)
        {
            var success = await send.Send(new DeleteAssetEventHistoryCommand(id), ct);

            if (!success)
            {
                return NotFound(new ApiResponse<ProblemDetails>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = $"Asset event history with ID {id} not found for deletion."
                });
            }

            return NoContent();
        }
    }
}