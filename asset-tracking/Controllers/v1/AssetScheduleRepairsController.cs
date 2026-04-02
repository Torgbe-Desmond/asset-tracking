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
    [Route("api/v{version:ApiVersion}/asset-schedule-repairs")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiVersion("1.0")]
    public class AssetScheduleRepairsController(ISender send) : ControllerBase
    {
        /// <summary>
        /// Retrieves all scheduled asset repairs.
        /// </summary>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<ScheduleRepairResponseDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var result = await send.Send(new GetAllAssetSchedulesRepairQuery(), ct);

            var response = new ApiResponse<IEnumerable<ScheduleRepairResponseDto>>
            {
                Data = result,
                StatusCode = StatusCodes.Status200OK
            };

            return Ok(response);
        }

        /// <summary>
        /// Retrieves a specific scheduled asset repair by ID.
        /// </summary>
        [Authorize]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<ScheduleRepairDetailResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(string id, CancellationToken ct)
        {
            var result = await send.Send(new GetAssetSchedulesDetailsQuery(id), ct);

            if (result == null)
            {
                return NotFound(new ApiResponse<ProblemDetails>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = $"Scheduled repair with ID {id} not found."
                });
            }

            var response = new ApiResponse<ScheduleRepairDetailResponseDto>
            {
                Data = result,
                StatusCode = StatusCodes.Status200OK
            };

            return Ok(response);
        }

        /// <summary>
        /// Creates a new scheduled asset repair.
        /// </summary>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<ScheduleRepairDetailResponseDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(ScheduleRepairRequestDto request, CancellationToken ct)
        {
            var result = await send.Send(new AddScheduleRepairCommand(request), ct);

            var response = new ApiResponse<ScheduleRepairDetailResponseDto>
            {
                Data = result,
                StatusCode = StatusCodes.Status201Created
            };

            return CreatedAtAction(nameof(GetById), new { id = result.ScheduleRepairId, version = "1.0" }, response);
        }

        /// <summary>
        /// Updates an existing scheduled asset repair.
        /// </summary>
        [Authorize]
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(string id, ScheduleRepairRequestDto request, CancellationToken ct)
        {
            var success = await send.Send(new UpdateAssetScheduleRepairCommand(id, request), ct);

            if (!success)
            {
                return NotFound(new ApiResponse<ProblemDetails>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = $"Scheduled repair with ID {id} could not be found for update."
                });
            }

            return NoContent();
        }

        /// <summary>
        /// Delete an existing asset repair.
        /// </summary>
        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id, CancellationToken ct)
        {
            var success = await send.Send(new DeleteAssetScheduleRepairCommand(id), ct);

            if (!success)
            {
                return NotFound(new ApiResponse<ProblemDetails>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = $"Scheduled repair with ID {id} not found for deletion."
                });
            }

            return NoContent();
        }
    }
}