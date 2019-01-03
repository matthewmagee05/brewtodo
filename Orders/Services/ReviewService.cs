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

        public Review Delete(int id)
        {
            Review review = _context.Reviews.Find(id);
            if (review == null)
            {
                return null;
            }

            _context.Reviews.Remove(review);
            _context.SaveChanges();

            return review;

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

        public Review Post(Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
            return review;
        }

        public Review Put(Review review)
        {
            var foundReview = _context.Reviews.Find(review.ReviewID);
            if (foundReview == null)
            {
                return null;
            }
            foundReview.BreweryID = review.BreweryID;
            foundReview.Rating = review.Rating;
            foundReview.ReviewDescription = review.ReviewDescription;
            foundReview.UserID = review.ReviewID;

            _context.SaveChanges();

            return foundReview;

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