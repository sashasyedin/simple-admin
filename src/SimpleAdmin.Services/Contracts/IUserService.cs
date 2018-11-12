using SimpleAdmin.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleAdmin.Services.Contracts
{
    public interface IUserService
    {
        Task<User> GetUser(long id);

        Task<IEnumerable<User>> GetUsers(long[] ids);

        Task<(IEnumerable<User>, int)> GetUsers(string filter, int pageSize, int pageNumber);

        Task<long> CreateUser(User user);

        Task DeleteUser(long id);

        Task UpdateUser(long id, User user);
    }
}
