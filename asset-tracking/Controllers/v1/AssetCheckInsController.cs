using System.Collections.Generic;
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
    [Route("api/v{version:ApiVersion}/asset-checkins")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiVersion("1.0")]
    public class AssetCheckInsController(ISender send) : ControllerBase
    {
        /// <summary>
        /// returns all asset checkins
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<AssetCheckInResponseDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var result = await send.Send(new GetAllAssetCheckInQuery(), ct);

            var response = new ApiResponse<IEnumerable<AssetCheckInResponseDto>>
            {
                Data = result,
                StatusCode = StatusCodes.Status200OK,
            };
            return Ok(response);
        }

        /// <summary>
        /// returns asset checkins by id
        /// </summary>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ApiResponse<AssetCheckInDetailsResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id, CancellationToken ct)
        {
            var result = await send.Send(new GetAllAssetCheckInByIdQuery(id), ct);

            if (result == null)
            {
                return NotFound(new ApiResponse<ProblemDetails>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = "Asset checkin not found."
                });
            }

            var response = new ApiResponse<AssetCheckInDetailsResponseDto>
            {
                Data = result,
                StatusCode = StatusCodes.Status200OK
            };

            return Ok(response);
        }

        /// <summary>
        /// create a new asset checkins
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<AssetCheckInDetailsResponseDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(AssetCheckInRequestDto request, CancellationToken ct)
        {
            var result = await send.Send(new AddAssetCheckInsCommand(request), ct);

            var response = new ApiResponse<AssetCheckInResponseDto>
            {
                Data = result,
                StatusCode = StatusCodes.Status201Created
            };

            return CreatedAtAction(nameof(GetById), new { id = result.AssetCheckInId, version = "1.0" }, response);
        }

        /// <summary>
        /// updates an existing asset checkin by id
        /// </summary
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, AssetCheckInRequestDto request, CancellationToken ct)
        {
           
            var success = await send.Send(new UpdateAssetCheckInsCommand(id, request), ct);

            if (!success)
            {
                return NotFound(new ApiResponse<ProblemDetails>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = $"Asset checkin with ID {id} could not be found for update."
                });
            }

            return NoContent();
        }


        /// <summary>
        /// deletes an existing asset checkin by id
        /// </summary
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
        
            var success = await send.Send(new DeleteAssetCheckInsCommand(id), ct);

            if (!success)
            {
                return NotFound(new ApiResponse<ProblemDetails>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = $"Asset checkout with ID {id} not found for deletion."
                });
            }

            return NoContent();
        }

    }

}
