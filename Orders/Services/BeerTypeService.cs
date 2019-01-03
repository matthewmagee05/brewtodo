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

        public BeerType Delete(int id)
        {
            BeerType beerType = _context.BeerTypes.Find(id);
            if (beerType == null)
            {
                return null;
            }

            _context.BeerTypes.Remove(beerType);
            _context.SaveChanges();

            return beerType;

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

        public BeerType Post(BeerType BeerType)
        {
            _context.BeerTypes.Add(BeerType);
            _context.SaveChanges();
            return BeerType;
        }


        public BeerType Put(BeerType beerType)
        {
            var foundBeerType = _context.BeerTypes.Find(beerType.BeerTypeID);
            if (foundBeerType == null)
            {
                return null;
            }
            foundBeerType.BeerTypeID = beerType.BeerTypeID;
            foundBeerType.BeerTypeName = beerType.BeerTypeName;
            _context.SaveChanges();

            return foundBeerType;
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