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
}
