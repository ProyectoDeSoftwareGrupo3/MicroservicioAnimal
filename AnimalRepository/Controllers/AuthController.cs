using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Application.Exceptions;
using Application.Interfaces.ICurrentUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimalRepository.Controllers;

public class AuthController : Controller
{

    [Authorize]
    [HttpGet("me")]
    public IActionResult Me([FromServices] ICurrentUserService currentUser)
    {
        return Ok(new
        {
            currentUser.User,
            IsAdmin = currentUser.IsInRole("Administrador")
        });
    }
    [Authorize]
    [HttpGet("userId")]
    public IActionResult UserId([FromServices] ICurrentUserService currentUser)
    {
        return new JsonResult(currentUser.User.Id);
    }
    [Authorize]
    [HttpGet]
    [Route("TheRealUserId")]
    public IActionResult RealUserId()
    {
        try
        {
            // Extract user ID from the claims
        var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "uid");
        var userClaims = User.Claims;
        if (userIdClaim != null)
        {
            var userId = userIdClaim.Value;            
            return Ok(new { UserId = userId });
        }

        return Unauthorized();
        }
        catch
        {
            return new JsonResult(new ExceptionMessage());
        }
    }
}
