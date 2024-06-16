using System.Security.Claims;
using Application.Interfaces.ICurrentUser;
using Microsoft.AspNetCore.Http;

namespace Application.UseCases;
public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;

        var id = _httpContextAccessor.HttpContext.User.Claims
           .FirstOrDefault(q => q.Type == "uid")
           .Value;

        var userName = _httpContextAccessor.HttpContext.User.Claims
        .FirstOrDefault(q => q.Type == ClaimTypes.NameIdentifier)
        .Value;

        User = new CurrentUser(id, userName);
    }

    public CurrentUser User { get; }

    public bool IsInRole(string roleName) =>
        _httpContextAccessor.HttpContext!.User.IsInRole(roleName);
}