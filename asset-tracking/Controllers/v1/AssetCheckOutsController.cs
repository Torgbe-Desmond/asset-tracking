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
    [Route("api/v{version:ApiVersion}/asset-checkouts")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiVersion("1.0")]
    public class AssetCheckOutsController(ISender send) : ControllerBase
    {

        /// <summary>
        /// returns all existing asset checkouts
        /// </summary
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<AssetCheckOutResponseDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var result = await send.Send(new GetAllAssetCheckOutQuery(), ct);

            var response = new ApiResponse<IEnumerable<AssetCheckOutResponseDto>>
            {
                Data = result,
                StatusCode = StatusCodes.Status200OK
            };

            return Ok(response);

        }

        /// <summary>
        /// returns an existing asset checkouts by id
        /// </summary
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ApiResponse<AssetCheckOutResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id, CancellationToken ct)
        {
            var result = await send.Send(new GetAssetCheckOutByIdQuery(id), ct);

            if (result == null)
            {
                return NotFound(new ApiResponse<ProblemDetails>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = "Asset checkout not found."
                });
            }

            var response = new ApiResponse<AssetCheckoutDetailsDto>
            {
                Data = result,
                StatusCode = StatusCodes.Status200OK
            };

            return Ok(response);
        }

        /// <summary>
        /// create a new asset checkout
        /// </summary
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<AssetCheckOutResponseDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(AssetCheckOutRequestDto request, CancellationToken ct)
        {
            var result = await send.Send(new AddAssetCheckOutsCommand(request), ct);

            var response = new ApiResponse<AssetCheckOutResponseDto>
            {
                Data = result,
                StatusCode = StatusCodes.Status200OK
            };

            return CreatedAtAction(nameof(GetById), new { id = result.AssetCheckOutId, version = "1.0" }, response);
        }

        /// <summary>
        /// updates an existing asset checkout by id
        /// </summary
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, AssetCheckOutRequestDto request, CancellationToken ct)
        {
           
            var success = await send.Send(new UpdateAssetCheckOutsCommand(id, request), ct);

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

        /// <summary>
        /// deletes an existing asset checkout by id
        /// </summary
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {

            var success = await send.Send(new DeleteAssetCheckOutsCommand(id), ct);

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
