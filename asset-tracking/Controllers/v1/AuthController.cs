using Asp.Versioning;
using Asset_Tracking.Application.Common.Dtos.Asset;
using Asset_Tracking.Application.Common.Dtos.Auth;
using Asset_Tracking.Application.Common.Dtos.User;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using Asset_Tracking_Api.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

[ApiController]
[Route("api/v{version:apiVersion}/auth")]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
[ApiVersion("1.0")]
public class AuthController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IJwtService _jwt;
    public AuthController(UserManager<ApplicationUser> userManager,
                          SignInManager<ApplicationUser> signInManager,
                          RoleManager<IdentityRole> roleManager, 
                          IJwtService jwt)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _jwt = jwt;      
    }

    /// <summary>
    /// Register a new user
    /// </summary>
    [HttpPost("register")]
    [ProducesResponseType(typeof(ApiResponse<AuthResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        var user = new ApplicationUser
        {
            UserName = dto.Email,
            Email = dto.Email
        };

        var result = await _userManager.CreateAsync(user, dto.Password);

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        // Optionally assign a role
        if (!string.IsNullOrEmpty(dto.Role) && await _roleManager.RoleExistsAsync(dto.Role))
        {
            await _userManager.AddToRoleAsync(user, dto.Role);
        }

        string token = _jwt.GenerateToken(user);

        return Ok(new AuthResponse(token, new UserDto(user.Id, user.UserName, user.Email)));
    }

    /// <summary>
    /// Login a user
    /// </summary>
    [HttpPost("login")]
    [ProducesResponseType(typeof(ApiResponse<AuthResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);

        if (user == null)
            return Unauthorized(new { Message = "Invalid email or password" });

        // Use the user object we just found to sign in
        var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);

        if (!result.Succeeded)
            return Unauthorized(new { Message = "Invalid email or password" });

        string token = _jwt.GenerateToken(user);

        return Ok(new AuthResponse(token, new UserDto(user.Id, user.UserName, user.Email)));
    }
}

