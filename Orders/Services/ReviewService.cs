using Microsoft.EntityFrameworkCore;
using System.Linq;
using Orders.Data;
using Orders.Models;
using Orders.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Orders.Services
{
    public class ReviewService: IReviewService, IDisposable
    {
        private BreweryContext _context;

        public ReviewService(BreweryContext db = null)
        {
            _context = db ?? new BreweryContext();
        }

        private bool ReviewExists(int id)
        {
            return _context.Reviews.Count(e => e.ReviewID == id) > 0;
        }

        public bool Delete(int id)
        {
            Review review = _context.Reviews.Find(id);
            if (review == null)
            {
                return false;
            }

            _context.Reviews.Remove(review);
            _context.SaveChanges();

            return true;

        }

        public IQueryable<Review> Get()
        {
            return _context.Reviews;
        }

        public IEnumerable<Review> GetAllReviewsById(int id){
            var reviews = _context.Reviews.Where(r => r.BreweryID == id).AsEnumerable();
            if(reviews == null){
                return null;
            }
            return reviews;
        }
        public Review Get(int id)
        {

            Review review = _context.Reviews.Find(id);
            if (review == null)
            {
                return null;
            }
            return review;
        }

        public void Post(Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
        }

        public bool Put(int id, Review review)
        {
            if (_context.Reviews.Where(a => a.ReviewID == id).FirstOrDefault() == null)
            {
                return false;
            }

            review.ReviewID = id;
            Review oldReview = _context.Reviews.Where(a => a.ReviewID == id).FirstOrDefault();
            _context.Entry(oldReview).CurrentValues.SetValues(review);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(id))
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
    public interface IReviewService: IRepository<Review>
    {
        IEnumerable<Review> GetAllReviewsById(int id);
    }
}