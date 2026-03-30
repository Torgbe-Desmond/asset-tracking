using System.Net.Mime;
using Asp.Versioning;
using Asset_Tracking.Application.Common.Dtos.RefreshToken;
using Asset_Tracking.Application.UseCases.RefreshToken.Commands;
using Asset_Tracking.Application.UseCases.RefreshToken.Queries;
using Asset_Tracking_Api.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Asset_Tracking_Api.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/refresh-tokens")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiVersion("1.0")]
    public class RefreshTokensController(ISender send) : ControllerBase
    {
        /// <summary>
        /// Gets a refresh token by its ID
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<RefreshTokenResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
            [FromRoute] int id,
            CancellationToken ct)
        {
            var result = await send.Send(new GetRefreshTokenByIdQuery(id), ct);

            if (result == null)
            {
                return NotFound(new ApiResponse<ProblemDetails>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = "Refresh token not found."
                });
            }

            var response = new ApiResponse<RefreshTokenResponseDto>
            {
                Data = result,
                StatusCode = StatusCodes.Status200OK
            };

            return Ok(response);
        }

        /// <summary>
        /// Creates a new refresh token
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<RefreshTokenResponseDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(
            [FromBody] RefreshTokenRequestDto request,
            CancellationToken ct)
        {
            var result = await send.Send(new AddRefreshTokenCommand(request), ct);

            var response = new ApiResponse<RefreshTokenResponseDto>
            {
                Data = result,
                StatusCode = StatusCodes.Status201Created,
                Message = "Refresh token created successfully."
            };

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.Id, version = "1.0" },
                response);
        }

        /// <summary>
        /// Updates an existing refresh token (usually for revocation or extension)
        /// </summary>   
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(
            [FromRoute] int id,
            [FromBody] RefreshTokenUpdateRequestDto request,
            CancellationToken ct)
        {
            var success = await send.Send(new UpdateRefreshTokenCommand(id, request), ct);

            if (!success)
            {
                return NotFound(new ApiResponse<ProblemDetails>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = $"Refresh token with ID {id} not found."
                });
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes a refresh token
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(
            [FromRoute] int id,
            CancellationToken ct)
        {
            await send.Send(new DeleteRefreshTokenCommand(id), ct);
            return NoContent();
        }
    }
}

