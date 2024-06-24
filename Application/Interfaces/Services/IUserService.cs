using Domain.Models;

namespace Application.Interfaces.Services;

public interface IUserService
{
    Task<List<GetUserResponse>> GetUsers();
}
