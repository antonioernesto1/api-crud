using api_crud.Application.Services.Interfaces;
using api_crud.Data;
using api_crud.Data.Repositories.Interfaces;
using api_crud.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_crud.Application.Services
{
    public class UserServices : IUserServices
    {
        private readonly AppDbContext _context;
        private readonly IUserRepository _repository;

        public UserServices(AppDbContext context, IUserRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        public async Task<bool> AddUser(User model)
        {
            try
            {
                _context.Add(model);
                if(await _context.SaveChangesAsync() > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                var user = _repository.GetUserById(id);
                if (user == null) return false;
                _context.Remove(user);
                if (await _context.SaveChangesAsync() > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public IEnumerable<User> GetUsers()
        {
            try
            {
                var users = _repository.GetUsers();
                if (users.Count() == 0) return null;
                return users;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }            
        }

        public User GetUsersById(int id)
        {
            try
            {
                var user = _repository.GetUserById(id);
                if (user == null) return null;
                return user;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> UpdateUser(int id, User model)
        {
            try
            {
                var user = _repository.GetUserById(id);
                if (user == null) return false;

                model.Id = id;
                _context.Entry(user).State = EntityState.Detached;
                _context.Entry(model).State = EntityState.Modified;
                if (await _context.SaveChangesAsync() > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
