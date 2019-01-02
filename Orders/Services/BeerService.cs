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

        public bool Delete(int id)
        {
            Beer Beer = _context.Beers.Find(id);
            if (Beer == null)
            {
                return false;
            }

            _context.Beers.Remove(Beer);
            _context.SaveChanges();

            return true;

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

        public void Post(Beer Beer)
        {
            _context.Beers.Add(Beer);
            _context.SaveChanges();
        }

        public bool Put(int id, Beer Beer)
        {
            if (_context.Beers.Where(a => a.BeerID == id).FirstOrDefault() == null)
            {
                return false;
            }

            Beer.BeerID = id;
            Beer oldBrew = _context.Beers.Where(a => a.BeerID == id).FirstOrDefault();
            _context.Entry(oldBrew).CurrentValues.SetValues(Beer);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeerExists(id))
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

    public interface IBeerService: IRepository<Beer>
    {
        IEnumerable<Beer> GetAllBeersById(int id);
    }
}