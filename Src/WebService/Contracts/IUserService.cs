using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IUserService:IBaseService<User>
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetById(int id);
    }
}
