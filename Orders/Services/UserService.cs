using Microsoft.EntityFrameworkCore;
using System.Linq;
using Orders.Data;
using Orders.Models;
using Orders.Services.Interfaces;
using System;

namespace Orders.Services
{
    public class UserService: IUserService, IDisposable
    {
        private BreweryContext _context;

        public UserService(BreweryContext db = null)
        {
            _context = db ?? new BreweryContext();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Count(e => e.UserID == id) > 0;
        }

        public User Delete(int id)
        {
            User brewery = _context.Users.Find(id);
            if (brewery == null)
            {
                return null;
            }

            _context.Users.Remove(brewery);
            _context.SaveChanges();

            return brewery;

        }

        public IQueryable<User> Get()
        {
            return _context.Users;
        }

        public User Get(int id)
        {

            User brewery = _context.Users.Find(id);
            if (brewery == null)
            {
                return null;
            }
            return brewery;
        }

        public User Post(User brewery)
        {
            _context.Users.Add(brewery);
            _context.SaveChanges();
            return brewery;
        }

        public User Put(User user)
        {
            var foundUser = _context.Users.Find(user.UserID);
            if (foundUser == null)
            {
                return null;
            }
            foundUser.FirstName = user.FirstName;
            foundUser.IdentityID = user.IdentityID;
            foundUser.LastName = user.LastName;
            foundUser.ProfileImage = user.ProfileImage;
            foundUser.Username = user.Username;

            _context.SaveChanges();

            return foundUser;
        }

        public void Dispose()
        {
            ((IDisposable)_context).Dispose();
        }
    }
    public interface IUserService: IRepository<User>
    {

    }
}