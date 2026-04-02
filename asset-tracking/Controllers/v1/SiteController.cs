using Asp.Versioning;
using Asset_Tracking.Application.Common.Dtos.Site;
using Asset_Tracking.Application.UseCases.Site.Commands;
using Asset_Tracking.Application.UseCases.Site.Queries;
using Asset_Tracking_Api.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Asset_Tracking_Api.Controllers.v1
{
    [Route("api/v{version:ApiVersion}/site")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiVersion("1.0")]
    public class SiteController(ISender send) : ControllerBase
    {
        /// <summary>
        /// Retrieves all sites.
        /// </summary>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<SiteResponseDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var result = await send.Send(new GetAllSitesQuery(), ct);

            var response = new ApiResponse<IEnumerable<SiteResponseDto>>
            {
                Data = result,
                StatusCode = StatusCodes.Status200OK
            };

            return Ok(response);
        }

        /// <summary>
        /// Retrieves a specific site by ID.
        /// </summary>
        [Authorize]
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ApiResponse<SiteResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id, CancellationToken ct)
        {
            var result = await send.Send(new GetSiteByIdQuery(id), ct);

            if (result == null)
            {
                return NotFound(new ApiResponse<ProblemDetails>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = $"Site with ID {id} not found."
                });
            }

            var response = new ApiResponse<SiteResponseDto>
            {
                Data = result,
                StatusCode = StatusCodes.Status200OK
            };

            return Ok(response);
        }

        /// <summary>
        /// Creates a new site.
        /// </summary>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<SiteResponseDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(SiteRequestDto request, CancellationToken ct)
        {
            var result = await send.Send(new AddSiteCommand(request), ct);

            var response = new ApiResponse<SiteResponseDto>
            {
                Data = result,
                StatusCode = StatusCodes.Status201Created
            };

            return CreatedAtAction(nameof(GetById), new { id = result.SiteId, version = "1.0" }, response);
        }

        /// <summary>
        /// Updates an existing site.
        /// </summary>
        [Authorize]
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, SiteRequestDto request, CancellationToken ct)
        {
            var success = await send.Send(new UpdateSiteCommand(id, request), ct);

            if (!success)
            {
                return NotFound(new ApiResponse<ProblemDetails>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = $"Site with ID {id} could not be found for update."
                });
            }

            return NoContent();
        }

        /// <summary>
        /// Delete an existing site.
        /// </summary>
        [Authorize]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            var success = await send.Send(new DeleteSiteCommand(id), ct);

            if (!success)
            {
                return NotFound(new ApiResponse<ProblemDetails>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = $"Site with ID {id} not found for deletion."
                });
            }

            return NoContent();
        }
    }
}