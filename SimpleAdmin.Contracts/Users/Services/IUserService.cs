using SimpleAdmin.Contracts.Users.DTO;
using SimpleAdmin.Contracts.Users.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleAdmin.Contracts.Users.Services
{
    public interface IUserService
    {
        Task<User> GetUser(long id);

        Task<IEnumerable<User>> GetUsers(long[] ids);

        Task<(IEnumerable<User>, int)> GetUsers(string filter, int pageSize, int pageNumber);

        Task<long> CreateUser(UserDto user);

        Task DeleteUser(long id);

        Task UpdateUser(long id, UserDto user);
    }
}
