using Microsoft.EntityFrameworkCore;
using System.Linq;
using Orders.Data;
using Orders.Models;
using Orders.Services.Interfaces;
using System;
using System.Collections.Generic;

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

        public UserBeerTried Delete(int id)
        {
            UserBeerTried userBeerTried = _context.UserBeersTried.Find(id);
            if (userBeerTried == null)
            {
                return null;
            }

            _context.UserBeersTried.Remove(userBeerTried);
            _context.SaveChanges();

            return userBeerTried;

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

        public UserBeerTried Post(UserBeerTried userBeerTried)
        {
            _context.UserBeersTried.Add(userBeerTried);
            _context.SaveChanges();
            return userBeerTried;
        }

        public UserBeerTried Put( UserBeerTried userBeerTried)
        {
            var foundUBT = _context.UserBeersTried.Find(userBeerTried.UserBeerTriedID);
            if (foundUBT == null)
            {
                return null;
            }
            foundUBT.BeerID = userBeerTried.BeerID;
            foundUBT.UserID = userBeerTried.UserID;

            _context.SaveChanges();

            return foundUBT;
        }

        public void Dispose()
        {
            ((IDisposable)_context).Dispose();
        }

        public IEnumerable<UserBeerTried> GetAllBeersTriedById(int id)
        {
            var beersTried = _context.UserBeersTried.Where(r => r.UserBeerTriedID == id).AsEnumerable();
            if(beersTried == null){
                return null;
            }
            return beersTried;
        }
    }

    public interface IUserBeerTriedService: IRepository<UserBeerTried>
    {
        IEnumerable<UserBeerTried> GetAllBeersTriedById(int id);
    }
}