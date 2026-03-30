using System.Net.Mime;
using Asp.Versioning;
using Asset_Tracking.Application.Common.Dtos.User;
using Asset_Tracking.Application.UseCases.User.Commands;
using Asset_Tracking.Application.UseCases.User.Queries;
using Asset_Tracking_Api.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Asset_Tracking.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/user-image")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiVersion("1.0")]
    public class UserImageController(ISender send) : ControllerBase
    {
        /// <summary>
        /// returns all user images
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<UserImageResponseDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var result = await send.Send(new GetAllUserImagesQuery(), ct);

            var response = new ApiResponse<IEnumerable<UserImageResponseDto>>
            {
                Data = result,
                StatusCode = StatusCodes.Status200OK
            };

            return Ok(response);
        }

        /// <summary>
        /// returns user image by id
        /// </summary>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ApiResponse<UserImageResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id, CancellationToken ct)
        {
            var result = await send.Send(new GetUserImageByIdQuery(id), ct);

            if (result == null)
            {
                return NotFound(new ApiResponse<ProblemDetails>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = "User image not found."
                });
            }

            var response = new ApiResponse<UserImageResponseDto>
            {
                Data = result,
                StatusCode = StatusCodes.Status200OK
            };

            return Ok(response);
        }

        /// <summary>
        /// Creates a new user image
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<UserImageResponseDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(
           UserImageRequestDto request,
           CancellationToken ct)
        {
            var result = await send.Send(new AddUserImageCommand(request), ct);

            var response = new ApiResponse<UserImageResponseDto>
            {
                Data = result,
                StatusCode = StatusCodes.Status201Created,
                Message = "User image created successfully."
            };

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.UserImageId, version = "1.0" },
                response);
        }

        /// <summary>
        /// updates an existing asset category by id
        /// </summary>
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(
            int id,
            UserImageUpdateRequestDto request,
            CancellationToken ct)
        {
            var success = await send.Send(new UpdateUserImageCommand(id, request), ct);

            if (!success)
            {
                return NotFound(new ApiResponse<ProblemDetails>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = $"User image with ID {id} could not be found for update."
                });
            }

            return NoContent();
        }

        /// <summary>
        /// deletes an existing user image
        /// </summary>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(
           int id,
           CancellationToken ct)
        {
            await send.Send(new DeleteUserImageCommand(id), ct);
            return NoContent();
        }
    }
}
