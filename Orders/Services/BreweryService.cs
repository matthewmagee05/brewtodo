using Microsoft.EntityFrameworkCore;
using System.Linq;
using Orders.Data;
using Orders.Models;
using Orders.Services.Interfaces;
using System;

namespace Orders.Services
{
    public class BreweryService : IBreweryService, IDisposable
    {
        private BreweryContext _context;
        public BreweryService(BreweryContext db = null)
        {
            _context = db ?? new BreweryContext();
        }

         private bool BreweryExists(int id)
        {
            return _context.Breweries.Count(e => e.BreweryID == id) > 0;
        }
        public Brewery Delete(int id)
        {
            Brewery brewery = _context.Breweries.Find(id);
            if (brewery == null)
            {
                return null;
            }

            _context.Breweries.Remove(brewery);
            _context.SaveChanges();

            return brewery;
        }

        public IQueryable<Brewery> Get()
        {
            return _context.Breweries;
        }

        public Brewery Get(int id)
        {
            Brewery brewery = _context.Breweries.Find(id);
            if (brewery == null)
            {
                return null;
            }
            return brewery;
        }

        public Brewery Post(Brewery brewery)
        {
            _context.Breweries.Add(brewery);
            _context.SaveChanges();
            return brewery;
        }

        public Brewery Put(Brewery brewery)
        {
            var foundBrewery = _context.Breweries.Find(brewery.BreweryID);
            if (foundBrewery == null)
            {
                return null;
            }
            foundBrewery.BusinessHours = brewery.BusinessHours;
            foundBrewery.Description = brewery.Description;
            foundBrewery.HasFood = brewery.HasFood;
            foundBrewery.HasGrowler = brewery.HasGrowler;
            foundBrewery.HasMug = brewery.HasMug;
            foundBrewery.HasTShirt = brewery.HasTShirt;
            foundBrewery.ImageURL = brewery.ImageURL;
            foundBrewery.Name = brewery.Name;
            foundBrewery.PhoneNumber = brewery.PhoneNumber;
            foundBrewery.StateID = brewery.StateID;
            foundBrewery.Address = brewery.Address;
            foundBrewery.ZipCode = brewery.ZipCode;

            _context.SaveChanges();

            return foundBrewery;
        }

        public void Dispose()
        {
            ((IDisposable)_context).Dispose();
        }
    }

    public interface IBreweryService: IRepository<Brewery>
    {

    }
}