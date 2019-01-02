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
        public bool Delete(int id)
        {
            Brewery brewery = _context.Breweries.Find(id);
            if (brewery == null)
            {
                return false;
            }

            _context.Breweries.Remove(brewery);
            _context.SaveChanges();

            return true;
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

        public void Post(Brewery brewery)
        {
            _context.Breweries.Add(brewery);
            _context.SaveChanges();
        }

        public bool Put(int id, Brewery brewery)
        {
            if (_context.Breweries.Where(a => a.BreweryID == id).FirstOrDefault() == null)
            {
                return false;
            }

            brewery.BreweryID = id;
            Brewery oldBrew = _context.Breweries.Where(a => a.BreweryID == id).FirstOrDefault();
            _context.Entry(oldBrew).CurrentValues.SetValues(brewery);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BreweryExists(id))
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

    public interface IBreweryService: IRepository<Brewery>
    {

    }
}