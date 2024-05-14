using GradeUp.Entities;
using GradeUp.Repository;
using GradeUp.Repository.Implementation;

namespace GradeUp.Services
{
    public class ReviewService
    {
        private readonly IReviewRepository reviewRepository;
        public ReviewService()
        {
            reviewRepository = new ReviewRepository();
        }

        public Review getById(long id)
        {
            return reviewRepository.getReviewById(id);
        }

        public List<Review> getByIdUser(long id_user)
        {
            return reviewRepository.getReviewByIdUser(id_user);
        }

        public void add_review(Review review)
        {
            reviewRepository.addReview(review);
        }

        public void update_review(Review review)
        {
            reviewRepository.updateReview(review);
        }

        public void deleteById(long id)
        {
            reviewRepository.deleteReviewById(id);
        }

        public void deleteByIdUser(long id_user)
        {
            reviewRepository.deleteReviewByIdUser(id_user);
        }

    }
}
