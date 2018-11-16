using SimpleAdmin.Common.Validation;
using SimpleAdmin.Contracts.Users.DTO;
using SimpleAdmin.Contracts.Users.Models;
using SimpleAdmin.Contracts.Users.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleAdmin.Services
{
    public class UserService : IUserService
    {
        public virtual async Task<User> GetUser(long id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<User>> GetUsers(long[] ids)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<(IEnumerable<User>, int)> GetUsers(string filter, int pageSize, int pageNumber)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<long> CreateUser([Valid] UserDto user)
        {
            throw new NotImplementedException();
        }

        public virtual async Task DeleteUser(long id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task UpdateUser(long id, [Valid] UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
