using Asp.Versioning;
using Asset_Tracking.Application.Common.Dtos.Role;
using Asset_Tracking.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

[ApiController]
[Route("api/v{version:apiVersion}/roles")]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
[ApiVersion("1.0")]

public class RolesController : ControllerBase
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public RolesController(RoleManager<IdentityRole> roleManager,
                           UserManager<ApplicationUser> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }

    // Create a new role
    [Authorize]
    [HttpPost("create")]
    public async Task<IActionResult> CreateRole([FromBody] string roleName)
    {
        if (await _roleManager.RoleExistsAsync(roleName))
            return BadRequest("Role already exists.");

        var result = await _roleManager.CreateAsync(new IdentityRole(roleName));

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return Ok($"Role '{roleName}' created.");
    }

    // Assign role to a user
    [Authorize]
    [HttpPost("assign")]
    public async Task<IActionResult> AssignRole([FromBody] AssignRoleDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if (user == null)
            return NotFound("User not found.");

        if (!await _roleManager.RoleExistsAsync(dto.Role))
            return BadRequest("Role does not exist.");

        await _userManager.AddToRoleAsync(user, dto.Role);
        return Ok($"Role '{dto.Role}' assigned to {user.Email}");
    }

    // List all roles
    [Authorize]
    [HttpGet]
    public IActionResult ListRoles()
    {
        var roles = _roleManager.Roles;
        return Ok(roles);
    }
}

