using Asp.Versioning;
using Asset_Tracking.Application.Common.Dtos.Asset;
using Asset_Tracking.Application.UseCases.Asset.Commands;
using Asset_Tracking.Application.UseCases.Asset.Queries;
using Asset_Tracking_Api.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Asset_Tracking_Api.Controllers.v1
{
    [Route("api/v{version:ApiVersion}/asset-image")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiVersion("1.0")]
    public class AssetImageController(ISender send) : ControllerBase
    {
        /// <summary>
        /// return all existing asset images history 
        /// </summary>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<AssetImageResponseDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var result = await send.Send(new GetAllAssetImageQuery(), ct);

            var response = new ApiResponse<IEnumerable<AssetImageResponseDto>>
            {
                Data = result,
                StatusCode = StatusCodes.Status200OK
            };

            return Ok(response);
        }

        /// <summary>
        /// returns am existing asset event image by id
        /// </summary>
        [Authorize]
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ApiResponse<AssetImageResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id, CancellationToken ct)
        {
            var result = await send.Send(new GetAssetImageByIdQuery(id), ct);

            if (result == null)
            {
                return NotFound(new ApiResponse<ProblemDetails>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = $"Asset image with ID {id} not found."
                });
            }

            var response = new ApiResponse<AssetImageResponseDto>
            {
                Data = result,
                StatusCode = StatusCodes.Status200OK
            };

            return Ok(response);
        }

        /// <summary>
        /// creates a new asset event image
        /// </summary>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<AssetImageResponseDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(AssetImageRequestDto request, CancellationToken ct)
        {
            var result = await send.Send(new AddAssetImageCommand(request), ct);

            var response = new ApiResponse<AssetImageResponseDto>
            {
                Data = result,
                StatusCode = StatusCodes.Status201Created
            };

            return CreatedAtAction(nameof(GetById), new { id = result.AssetImageId, version = "1.0" }, response);
        }

        /// <summary>
        /// updates am existing asset event image by id
        /// </summary>
        [Authorize]
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, AssetImageRequestDto request, CancellationToken ct)
        {
            var success = await send.Send(new UpdateAssetImageCommand(id, request), ct);

            if (!success)
            {
                return NotFound(new ApiResponse<ProblemDetails>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = $"Asset image with ID {id} could not be found for update."
                });
            }

            return NoContent();
        }

        /// <summary>
        /// deletes am existing asset event image by id
        /// </summary>
        [Authorize]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            var success = await send.Send(new DeleteAssetImageCommand(id), ct);

            if (!success)
            {
                return NotFound(new ApiResponse<ProblemDetails>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = $"Asset image with ID {id} not found for deletion."
                });
            }

            return NoContent();
        }
    }
}