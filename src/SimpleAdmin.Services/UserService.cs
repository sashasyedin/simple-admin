using SimpleAdmin.Common.Tx;
using SimpleAdmin.Common.Validation;
using SimpleAdmin.Contracts.Users.DTO;
using SimpleAdmin.Contracts.Users.Models;
using SimpleAdmin.Contracts.Users.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace SimpleAdmin.Services
{
    public class UserService : IUserService
    {
        [Transactional(TransactionScopeOption.Suppress)]
        public virtual async Task<User> GetUser(long id)
        {
            throw new NotImplementedException();
        }

        [Transactional(TransactionScopeOption.Suppress)]
        public virtual async Task<IEnumerable<User>> GetUsers(long[] ids)
        {
            throw new NotImplementedException();
        }

        [Transactional(TransactionScopeOption.Suppress)]
        public virtual async Task<(IEnumerable<User>, int)> GetUsers(string filter, int pageSize, int pageNumber)
        {
            throw new NotImplementedException();
        }

        [Transactional]
        public virtual async Task<long> CreateUser([Valid] UserDto user)
        {
            throw new NotImplementedException();
        }

        [Transactional]
        public virtual async Task DeleteUser(long id)
        {
            throw new NotImplementedException();
        }

        [Transactional]
        public virtual async Task UpdateUser(long id, [Valid] UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
