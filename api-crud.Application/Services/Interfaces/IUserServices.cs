using api_crud.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_crud.Application.Services.Interfaces
{
    public interface IUserServices
    {
        public IEnumerable<User> GetUsers();
        public User GetUsersById(int id);
        public Task<bool> AddUser(User model);
        public Task<bool> DeleteUser(int id);
        public Task<bool> UpdateUser(int id, User model);
    }
}
