using Asp.Versioning;
using Asset_Tracking.Application.Common.Dtos.Building;
using Asset_Tracking.Application.UseCases.Building.Commands;
using Asset_Tracking.Application.UseCases.Building.Queries;
using Asset_Tracking_Api.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Asset_Tracking_Api.Controllers.v1
{
    [Route("api/v{version:ApiVersion}/building")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiVersion("1.0")]
    public class BuildingsController(ISender send) : ControllerBase
    {
        /// <summary>
        /// Retrieves all buildings.
        /// </summary>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<BuildingResponseDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var result = await send.Send(new GetAllBuildingsQuery(), ct);

            var response = new ApiResponse<IEnumerable<BuildingResponseDto>>
            {
                Data = result,
                StatusCode = StatusCodes.Status200OK
            };

            return Ok(response);
        }

        /// <summary>
        /// Retrieves a specific building by ID.
        /// </summary>
        [Authorize]
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ApiResponse<BuildingResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id, CancellationToken ct)
        {
            var result = await send.Send(new GetBuildingByIdQuery(id), ct);

            if (result == null)
            {
                return NotFound(new ApiResponse<ProblemDetails>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = $"Building with ID {id} not found."
                });
            }

            var response = new ApiResponse<BuildingResponseDto>
            {
                Data = result,
                StatusCode = StatusCodes.Status200OK
            };

            return Ok(response);
        }

        /// <summary>
        /// Creates a new building.
        /// </summary>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<BuildingResponseDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(BuildingRequestDto request, CancellationToken ct)
        {
            var result = await send.Send(new AddBuildingCommand(request), ct);

            var response = new ApiResponse<BuildingResponseDto>
            {
                Data = result,
                StatusCode = StatusCodes.Status201Created
            };

            return CreatedAtAction(nameof(GetById), new { id = result.BuildingId, version = "1.0" }, response);
        }

        /// <summary>
        /// Updates an existing building.
        /// </summary>
        [Authorize]
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, BuildingRequestDto request, CancellationToken ct)
        {
            var success = await send.Send(new UpdateBuildingCommand(id, request), ct);

            if (!success)
            {
                return NotFound(new ApiResponse<ProblemDetails>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = $"Building with ID {id} could not be found for update."
                });
            }

            return NoContent();
        }

        /// <summary>
        /// Delete an existing building.
        /// </summary>
        [Authorize]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            var success = await send.Send(new DeleteBuildingCommand(id), ct);

            if (!success)
            {
                return NotFound(new ApiResponse<ProblemDetails>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = $"Building with ID {id} not found for deletion."
                });
            }

            return NoContent();
        }
    }
}