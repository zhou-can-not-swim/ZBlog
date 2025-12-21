using EF;
using Entities;
using Service;
using Service.Impl;

namespace WebService.Impl
{
    public class UserService : BaseService<User>,IUserService
    {
        public UserService(BlogDbContext dbContext) : base(dbContext)
        {
        }
    }
}
