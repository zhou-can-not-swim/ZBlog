using Common;
using EF;
using Entities;
using Microsoft.EntityFrameworkCore;
using Service;
using Service.Impl;

namespace WebService.Impl
{
    public class UserService : BaseService<User>,IUserService
    {
        public UserService(BlogDbContext dbContext) : base(dbContext)
        {
        }

        //得到所有用户
        public async Task<List<User>> GetAllUsers()
        {
            List<User> users = await FindAll().ToListAsync();
            return users;
        }
    }
}
