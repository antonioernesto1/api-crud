using api_crud.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_crud.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetUsers();
        public User GetUserById(int id);
    }
}
