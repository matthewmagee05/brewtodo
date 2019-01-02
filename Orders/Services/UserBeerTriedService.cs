using Microsoft.EntityFrameworkCore;
using System.Linq;
using Orders.Data;
using Orders.Models;
using Orders.Services.Interfaces;
using System;

namespace Orders.Services
{
    public class UserBeerTriedService: IUserBeerTriedService, IDisposable
    {
        private BreweryContext _context;

        public UserBeerTriedService(BreweryContext db = null)
        {
            _context = db ?? new BreweryContext();
        }

        private bool UserBeerTriedExists(int id)
        {
            return _context.UserBeersTried.Count(e => e.UserBeerTriedID == id) > 0;
        }

        public bool Delete(int id)
        {
            UserBeerTried UserBeerTried = _context.UserBeersTried.Find(id);
            if (UserBeerTried == null)
            {
                return false;
            }

            _context.UserBeersTried.Remove(UserBeerTried);
            _context.SaveChanges();

            return true;

        }

        public IQueryable<UserBeerTried> Get()
        {
            return _context.UserBeersTried;
        }

        public UserBeerTried Get(int id)
        {

            UserBeerTried UserBeerTried = _context.UserBeersTried.Find(id);
            if (UserBeerTried == null)
            {
                return null;
            }
            return UserBeerTried;
        }

        public void Post(UserBeerTried UserBeerTried)
        {
            _context.UserBeersTried.Add(UserBeerTried);
            _context.SaveChanges();
        }

        public bool Put(int id, UserBeerTried UserBeerTried)
        {
            if (_context.UserBeersTried.Where(a => a.UserBeerTriedID == id).FirstOrDefault() == null)
            {
                return false;
            }

            UserBeerTried.UserBeerTriedID = id;
            UserBeerTried oldBrew = _context.UserBeersTried.Where(a => a.UserBeerTriedID == id).FirstOrDefault();
            _context.Entry(oldBrew).CurrentValues.SetValues(UserBeerTried);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserBeerTriedExists(id))
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

    public interface IUserBeerTriedService: IRepository<UserBeerTried>
    {

    }
}