using Microsoft.EntityFrameworkCore;
using System.Linq;
using Orders.Data;
using Orders.Models;
using Orders.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Orders.Services
{
    public class BeerService: IBeerService, IDisposable
    {
        private BreweryContext _context;

        public BeerService(BreweryContext db = null)
        {
            _context = db ?? new BreweryContext();
        }

        private bool BeerExists(int id)
        {
            return _context.Beers.Count(e => e.BeerID == id) > 0;
        }

        public Beer Delete(int id)
        {
            Beer beer = _context.Beers.Find(id);
            if (beer == null)
            {
                return null;
            }

            _context.Beers.Remove(beer);
            _context.SaveChanges();

            return beer;

        }

        public IQueryable<Beer> Get()
        {
            return _context.Beers;
        }

        public IEnumerable<Beer> GetAllBeersById(int id){
            var beers = _context.Beers.Where(r => r.BreweryID == id).AsEnumerable();
            if(beers == null){
                return null;
            }
            return beers;
        }

        public Beer Get(int id)
        {

            Beer Beer = _context.Beers.Find(id);
            if (Beer == null)
            {
                return null;
            }
            return Beer;
        }

        public Beer Post(Beer Beer)
        {
            _context.Beers.Add(Beer);
            _context.SaveChanges();
            return Beer;
        }

        public Beer Put(Beer beer)
        {
            var foundBeer = _context.Beers.Find(beer.BeerID);
            if (foundBeer == null)
            {
                return null;
            }
            foundBeer.ABV = beer.ABV;
            foundBeer.BeerName = beer.BeerName;
            foundBeer.BeerTypeID = beer.BeerTypeID;
            foundBeer.BreweryID = beer.BreweryID;
            foundBeer.Description = beer.Description;
            _context.SaveChanges();

           return foundBeer;
        }


        public void Dispose()
        {
            ((IDisposable)_context).Dispose();
        }
    }

    public interface IBeerService: IRepository<Beer>
    {
        IEnumerable<Beer> GetAllBeersById(int id);
    }
}