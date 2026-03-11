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
    [Route("api/v{version:ApiVersion}/asset-maintenance")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiVersion("1.0")]
    public class AssetMaintenanceController(ISender send) : ControllerBase

    {   /// <summary>
        /// return all existing asset maintenaces 
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<AssetMaintenanceResponseDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var result = await send.Send(new GetAllAssetMaintenanceQuery(), ct);

            var response = new ApiResponse<IEnumerable<AssetMaintenanceResponseDto>>
            {
                Data = result,
                StatusCode = StatusCodes.Status200OK
            };

            return Ok(response);
        }

        /// <summary>
        /// return an existing asset maintenace
        /// </summary>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ApiResponse<AssetMaintenanceResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id, CancellationToken ct)
        {
            var result = await send.Send(new GetAssetMaintenanceByIdQuery(id), ct);

            if (result == null)
            {
                return NotFound(new ApiResponse<ProblemDetails>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = $"Asset maintenance record with ID {id} not found."
                });
            }

            var response = new ApiResponse<AssetMaintenanceResponseDto>
            {
                Data = result,
                StatusCode = StatusCodes.Status200OK
            };

            return Ok(response);
        }

        /// <summary>
        /// create a new asset maintenace
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<AssetMaintenanceResponseDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(AssetMaintenanceRequestDto request, CancellationToken ct)
        {
            var result = await send.Send(new AddAssetMaintenanceCommand(request), ct);

            var response = new ApiResponse<AssetMaintenanceResponseDto>
            {
                Data = result,
                StatusCode = StatusCodes.Status201Created
            };

            return CreatedAtAction(nameof(GetById), new { id = result.AssetMaintenanceId, version = "1.0" }, response);
        }

        /// <summary>
        /// update an existing asset maintenace
        /// </summary>
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, AssetMaintenanceRequestDto request, CancellationToken ct)
        {
            var success = await send.Send(new UpdateAssetMaintenanceCommand(id, request), ct);

            if (!success)
            {
                return NotFound(new ApiResponse<ProblemDetails>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = $"Asset maintenance record with ID {id} could not be found for update."
                });
            }

            return NoContent();
        }

        /// <summary>
        /// delete an existing asset maintenace
        /// </summary>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            var success = await send.Send(new DeleteAssetMaintenanceCommand(id), ct);

            if (!success)
            {
                return NotFound(new ApiResponse<ProblemDetails>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = $"Asset maintenance record with ID {id} not found for deletion."
                });
            }

            return NoContent();
        }
    }
}