﻿using SimpleAdmin.Services.Contracts;
using SimpleAdmin.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleAdmin.Services
{
    public class UserService : IUserService
    {
        public async Task<User> GetUser(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetUsers(long[] ids)
        {
            throw new NotImplementedException();
        }

        public async Task<(IEnumerable<User>, int)> GetUsers(string filter, int pageSize, int pageNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<long> CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteUser(long id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateUser(long id, User user)
        {
            throw new NotImplementedException();
        }
    }
}
