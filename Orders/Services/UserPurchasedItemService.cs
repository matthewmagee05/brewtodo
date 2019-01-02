using Microsoft.EntityFrameworkCore;
using System.Linq;
using Orders.Data;
using Orders.Models;
using Orders.Services.Interfaces;
using System;

namespace Orders.Services
{
    public class UserPurchasedItemService: IUserPurchasedItemService, IDisposable
    {
        private BreweryContext _context;

        public UserPurchasedItemService(BreweryContext db = null)
        {
            _context = db ?? new BreweryContext();
        }

        private bool UserPurchasedItemExists(int id)
        {
            return _context.UserPurchasedItems.Count(e => e.UserPurchasedItemID == id) > 0;
        }

        public bool Delete(int id)
        {
            UserPurchasedItem brewery = _context.UserPurchasedItems.Find(id);
            if (brewery == null)
            {
                return false;
            }

            _context.UserPurchasedItems.Remove(brewery);
            _context.SaveChanges();

            return true;

        }

        public IQueryable<UserPurchasedItem> Get()
        {
            return _context.UserPurchasedItems;
        }

        public UserPurchasedItem Get(int id)
        {

            UserPurchasedItem brewery = _context.UserPurchasedItems.Find(id);
            if (brewery == null)
            {
                return null;
            }
            return brewery;
        }

        public void Post(UserPurchasedItem brewery)
        {
            _context.UserPurchasedItems.Add(brewery);
            _context.SaveChanges();
        }

        public bool Put(int id, UserPurchasedItem brewery)
        {
            if (_context.UserPurchasedItems.Where(a => a.UserPurchasedItemID == id).FirstOrDefault() == null)
            {
                return false;
            }

            brewery.UserPurchasedItemID = id;
            UserPurchasedItem oldBrew = _context.UserPurchasedItems.Where(a => a.UserPurchasedItemID == id).FirstOrDefault();
            _context.Entry(oldBrew).CurrentValues.SetValues(brewery);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserPurchasedItemExists(id))
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

    public interface IUserPurchasedItemService: IRepository<UserPurchasedItem>
    {

    }
}