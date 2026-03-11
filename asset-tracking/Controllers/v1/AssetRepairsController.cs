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
    [Route("api/v{version:ApiVersion}/asset-repairs")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiVersion("1.0")]
    public class AssetRepairsController(ISender send) : ControllerBase
    {
        /// <summary>
        /// Retrieves all asset repairs.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<AssetRepairDetailResponseDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var result = await send.Send(new GetAllAssetRepairsQuery(), ct);

            var response = new ApiResponse<IEnumerable<AssetRepairDetailResponseDto>>
            {
                Data = result,
                StatusCode = StatusCodes.Status200OK
            };

            return Ok(response);
        }

        /// <summary>
        /// Retrieves a specific asset repair by ID.
        /// </summary>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ApiResponse<AssetRepairDetailResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id, CancellationToken ct)
        {
            var result = await send.Send(new GetAssetRepairByIdQuery(id), ct);

            if (result == null)
            {
                return NotFound(new ApiResponse<ProblemDetails>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = $"Asset repair with ID {id} not found."
                });
            }

            var response = new ApiResponse<AssetRepairDetailResponseDto>
            {
                Data = result,
                StatusCode = StatusCodes.Status200OK
            };

            return Ok(response);
        }

        /// <summary>
        /// Creates a new asset repair.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<AssetRepairDetailResponseDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(AssetRepairRequestDto request, CancellationToken ct)
        {
            var result = await send.Send(new AddAssetRepairCommand(request), ct);

            var response = new ApiResponse<AssetRepairDetailResponseDto>
            {
                Data = result,
                StatusCode = StatusCodes.Status201Created
            };

            return CreatedAtAction(nameof(GetById), new { id = result.AssetRepairId, version = "1.0" }, response);
        }

        /// <summary>
        /// Updates an existing asset repair.
        /// </summary>
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, AssetRepairRequestDto request, CancellationToken ct)
        {
            var success = await send.Send(new UpdateAssetRepairCommand(id, request), ct);

            if (!success)
            {
                return NotFound(new ApiResponse<ProblemDetails>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = $"Asset repair with ID {id} could not be found for update."
                });
            }

            return NoContent();
        }

        /// <summary>
        /// Delete an existing asset repair.
        /// </summary>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            var success = await send.Send(new DeleteAssetRepairsCommand(id), ct);

            if (!success)
            {
                return NotFound(new ApiResponse<ProblemDetails>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = $"Asset repair with ID {id} not found for deletion."
                });
            }

            return NoContent();
        }
    }
}