using Application.Interfaces.Services;
using Domain.Models;
using Infrastructure.Services.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly UserApiClient _userApiClient;

        public UserService(UserApiClient userApiClient)
        {
            _userApiClient = userApiClient;
        }

        public async Task<List<GetUserResponse>> GetUsers()
        {
            return await _userApiClient.GetUsers();
        }
    }
}
