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
    [Route("api/v{version:ApiVersion}/asset-disposals")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiVersion("1.0")]
    public class AssetDisposalsController(ISender send) : ControllerBase
    {
        /// <summary>
        /// returns all existing asset disposals
        /// </summary
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<AssetDisposeResponseDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var result = await send.Send(new GetAllAssetDisposeQuery(), ct);

            var response = new ApiResponse<IEnumerable<AssetDisposeResponseDto>>
            {
                Data = result,
                StatusCode = StatusCodes.Status200OK
            };

            return Ok(response);
        }

        /// <summary>
        /// returns am existing asset disposal by id
        /// </summary
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ApiResponse<AssetDisposeResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id, CancellationToken ct)
        {
            var result = await send.Send(new GetAssetDisposeByIdQuery(id), ct);

            if (result == null)
            {
                return NotFound(new ApiResponse<ProblemDetails>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = $"Asset disposal with ID {id} not found."
                });
            }

            var response = new ApiResponse<AssetDisposeResponseDto>
            {
                Data = result,
                StatusCode = StatusCodes.Status200OK
            };

            return Ok(response);
        }

        /// <summary>
        /// creates a new asset disposals
        /// </summary
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<AssetDisposeResponseDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(AssetDisposeRequestDto request, CancellationToken ct)
        {
            var result = await send.Send(new AddAssetDisposeCommand(request), ct);

            var response = new ApiResponse<AssetDisposeResponseDto>
            {
                Data = result,
                StatusCode = StatusCodes.Status201Created
            };

            return CreatedAtAction(nameof(GetById), new { id = result.AssetDisposeId, version = "1.0" }, response);
        }


        /// <summary>
        /// updates am existing asset disposal by id
        /// </summary
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, AssetDisposeRequestDto request, CancellationToken ct)
        {
            var success = await send.Send(new UpdateAssetDisposeCommand(id, request), ct);

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
        /// deletes am existing asset disposal by id
        /// </summary
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            var success = await send.Send(new DeleteAssetDisposeCommand(id), ct);

            if (!success)
            {
                return NotFound(new ApiResponse<ProblemDetails>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = $"Asset disposal with ID {id} not found for deletion."
                });
            }

            return NoContent();
        }
    }
}