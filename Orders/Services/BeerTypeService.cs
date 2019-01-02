using Microsoft.EntityFrameworkCore;
using System.Linq;
using Orders.Data;
using Orders.Models;
using Orders.Services.Interfaces;
using System;

namespace Orders.Services
{
    public class BeerTypeService : IBeerTypeService, IDisposable
    {
        private BreweryContext _context;

        public BeerTypeService(BreweryContext db = null)
        {
            _context = db ?? new BreweryContext();
        }

        private bool BeerTypeExists(int id)
        {
            return _context.BeerTypes.Count(e => e.BeerTypeID == id) > 0;
        }

        public bool Delete(int id)
        {
            BeerType BeerType = _context.BeerTypes.Find(id);
            if (BeerType == null)
            {
                return false;
            }

            _context.BeerTypes.Remove(BeerType);
            _context.SaveChanges();

            return true;

        }

        public IQueryable<BeerType> Get()
        {
            return _context.BeerTypes;
        }

        public BeerType Get(int id)
        {

            BeerType BeerType = _context.BeerTypes.Find(id);
            if (BeerType == null)
            {
                return null;
            }
            return BeerType;
        }

        public void Post(BeerType BeerType)
        {
            _context.BeerTypes.Add(BeerType);
            _context.SaveChanges();
        }

        public bool Put(int id, BeerType BeerType)
        {
            if (_context.BeerTypes.Where(a => a.BeerTypeID == id).FirstOrDefault() == null)
            {
                return false;
            }

            BeerType.BeerTypeID = id;
            BeerType oldBrew = _context.BeerTypes.Where(a => a.BeerTypeID == id).FirstOrDefault();
            _context.Entry(oldBrew).CurrentValues.SetValues(BeerType);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeerTypeExists(id))
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

    public interface IBeerTypeService: IRepository<BeerType>
    {

    }
}