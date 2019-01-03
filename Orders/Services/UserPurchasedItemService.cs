using Microsoft.EntityFrameworkCore;
using System.Linq;
using Orders.Data;
using Orders.Models;
using Orders.Services.Interfaces;
using System;
using System.Collections.Generic;

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

        public UserPurchasedItem Delete(int id)
        {
            UserPurchasedItem brewery = _context.UserPurchasedItems.Find(id);
            if (brewery == null)
            {
                return null;
            }

            _context.UserPurchasedItems.Remove(brewery);
            _context.SaveChanges();

            return brewery;

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

        public UserPurchasedItem Post(UserPurchasedItem brewery)
        {
            _context.UserPurchasedItems.Add(brewery);
            _context.SaveChanges();
            return brewery;
        }

        public UserPurchasedItem Put(UserPurchasedItem brewery)
        {
            var foundUPI = _context.UserPurchasedItems.Find(brewery.UserPurchasedItemID);
            if (foundUPI == null)
            {
                return null;
            }
            foundUPI.BreweryID = brewery.BreweryID;
            foundUPI.PurchasedGrowler = brewery.PurchasedGrowler;
            foundUPI.PurchasedMug = brewery.PurchasedMug;
            foundUPI.PurchasedTShirt = brewery.PurchasedTShirt;
            foundUPI.TriedFood = brewery.TriedFood;
            foundUPI.UserID = brewery.UserID;

            _context.SaveChanges();

            return foundUPI;
        }

        public void Dispose()
        {
            ((IDisposable)_context).Dispose();
        }

        public IEnumerable<UserPurchasedItem> GetAllPurchasedItemsById(int id)
        {
            var itemsPurchased = _context.UserPurchasedItems.Where(r => r.UserPurchasedItemID == id).AsEnumerable();
            if(itemsPurchased == null){
                return null;
            }
            return itemsPurchased;
        }
    }

    public interface IUserPurchasedItemService: IRepository<UserPurchasedItem>
    {
        IEnumerable<UserPurchasedItem> GetAllPurchasedItemsById(int id);
    }
}