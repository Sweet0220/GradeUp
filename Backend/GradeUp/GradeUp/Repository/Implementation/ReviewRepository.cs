using GradeUp.Entities;
using Microsoft.EntityFrameworkCore;

namespace GradeUp.Repository.Implementation
{
    public class ReviewRepository : IReviewRepository
    {
        private GradeUpContext _context;
        public ReviewRepository()
        { 
            _context = new GradeUpContext();
        }

        public Review getReviewById(long id)
        {
            return _context.Review.FirstOrDefault(r => r.id == id);
        }

        public List<Review> getReviewByIdUser(long id_user)
        {
            return _context.Review.Where(r => r.id_user == id_user).ToList<Review>();
        }

        public void addReview(Review review)
        {
            try
            {
                if (review != null)
                {
                    _context.Review.Add(review);
                    _context.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Invalid review informations.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while saving the entity changes.", ex);
            }
        }

        public void updateReview(Review review)
        {
            try
            {
                Review reviewToUpdate = _context.Review.FirstOrDefault(reviewToUpdate => reviewToUpdate.id == review.id);
                if (reviewToUpdate != null)
                {
                    //_context.Review.Update(reviewToUpdate);
                    reviewToUpdate.rating = review.rating;
                    reviewToUpdate.comment = review.comment;
                    reviewToUpdate.id_user= review.id_user;
                    _context.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Review information was not updated.");
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while saving changes in database.", ex);
            }
        }

        public void deleteReviewById(long id)
        {
            try
            {
                Review reviewToDelete = _context.Review.FirstOrDefault(t => t.id == id);
                if (reviewToDelete != null)
                {
                    _context.Review.Remove(reviewToDelete);
                    _context.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Review not found.");
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while saving changes in database.", ex);
            }
        }
        public void deleteReviewByIdUser(long id_user)
        {
            try
            {
                List<Review> reviewToDelete = _context.Review.Where(r => r.id_user == id_user).ToList<Review>();
                if (reviewToDelete != null)
                {
                    _context.Review.RemoveRange(reviewToDelete);
                    _context.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Review not found.");
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while saving changes in database.", ex);
            }
        }
    }
}
