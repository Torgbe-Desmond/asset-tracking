using Asp.Versioning;
using Asset_Tracking.Application.Common.Dtos.Staff;
using Asset_Tracking.Application.UseCases.Staff.Commands;
using Asset_Tracking.Application.UseCases.Staff.Queries;
using Asset_Tracking_Api.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Asset_Tracking_Api.Controllers.v1
{
    [Route("api/v{version:ApiVersion}/staff")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiVersion("1.0")]
    public class StaffController(ISender send) : ControllerBase
    {
        /// <summary>
        /// Retrieves all staff members.
        /// </summary>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<StaffResponseDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var result = await send.Send(new GetAllStaffsQuery(), ct);

            var response = new ApiResponse<IEnumerable<StaffResponseDto>>
            {
                Data = result,
                StatusCode = StatusCodes.Status200OK
            };

            return Ok(response);
        }

        /// <summary>
        /// Retrieves a specific staff member by ID.
        /// </summary>
        [Authorize]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<StaffResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(string id, CancellationToken ct)
        {
            var result = await send.Send(new GetStaffByIdQuery(id), ct);

            if (result == null)
            {
                return NotFound(new ApiResponse<ProblemDetails>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = $"Staff member with ID {id} not found."
                });
            }

            var response = new ApiResponse<StaffResponseDto>
            {
                Data = result,
                StatusCode = StatusCodes.Status200OK
            };

            return Ok(response);
        }

        /// <summary>
        /// Creates a new staff member.
        /// </summary>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<StaffResponseDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(StaffRequestDto request, CancellationToken ct)
        {
            var result = await send.Send(new AddStaffCommand(request), ct);

            var response = new ApiResponse<StaffResponseDto>
            {
                Data = result,
                StatusCode = StatusCodes.Status201Created
            };

            return CreatedAtAction(nameof(GetById), new { id = result.StaffId, version = "1.0" }, response);
        }

        /// <summary>
        /// Updates an existing staff member.
        /// </summary>
        [Authorize]
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(string id, StaffRequestDto request, CancellationToken ct)
        {
            var success = await send.Send(new UpdateStaffCommand(id, request), ct);

            if (!success)
            {
                return NotFound(new ApiResponse<ProblemDetails>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = $"Staff member with ID {id} could not be found for update."
                });
            }

            return NoContent();
        }

        /// <summary>
        /// Delete an existing staff member.
        /// </summary>
        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id, CancellationToken ct)
        {
            var success = await send.Send(new DeleteStaffCommand(id), ct);

            if (!success)
            {
                return NotFound(new ApiResponse<ProblemDetails>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = $"Staff member with ID {id} not found for deletion."
                });
            }

            return NoContent();
        }
    }
}