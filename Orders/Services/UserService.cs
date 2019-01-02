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

        public bool Delete(int id)
        {
            User brewery = _context.Users.Find(id);
            if (brewery == null)
            {
                return false;
            }

            _context.Users.Remove(brewery);
            _context.SaveChanges();

            return true;

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

        public void Post(User brewery)
        {
            _context.Users.Add(brewery);
            _context.SaveChanges();
        }

        public bool Put(int id, User brewery)
        {
            if (_context.Users.Where(a => a.UserID == id).FirstOrDefault() == null)
            {
                return false;
            }

            brewery.UserID = id;
            User oldBrew = _context.Users.Where(a => a.UserID == id).FirstOrDefault();
            _context.Entry(oldBrew).CurrentValues.SetValues(brewery);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
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