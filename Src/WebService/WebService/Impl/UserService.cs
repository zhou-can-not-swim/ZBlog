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

        public async Task<User> GetById(int id)
        {
            return await FindByCondition(b => b.Id == id).Include(b=>b.Blogs).FirstOrDefaultAsync();
        }

        public async Task<User> GetByUserName(string username)
        {
            return await FindByCondition(b => b.Username == username).FirstOrDefaultAsync();
        }
    }
}
